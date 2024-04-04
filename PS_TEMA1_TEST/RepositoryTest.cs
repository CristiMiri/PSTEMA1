using NUnit.Framework;
using Npgsql;

using System;
using System.Data;

using TEMA1_PS.Model.Repositories;
using NUnit.Framework.Legacy;
namespace PS_TEMA1_TEST
{
    [TestFixture]

    public class RepositoryTests
    {
        private Repository repository;

        [SetUp]
        public void SetUp()
        {
            repository = new Repository();
        }

        [Test,Order(1)]
        public void OpenConnectionTest()
        {
            // Act
            repository.OpenConnection();
            // Assert
            ClassicAssert.AreEqual(ConnectionState.Open, repository.Connection.State);
        }

        [Test,Order(2)]
        public void CloseConnectionTest()
        {
            // Arrange
            repository.OpenConnection();
            // Act
            repository.CloseConnection();
            // Assert
            ClassicAssert.AreEqual(ConnectionState.Closed, repository.Connection.State);
        }

        [Test,Order(3)]
        public void ExecuteNonQueryTest()
        {
            // Arrange
            
            string queryInsert = @"INSERT INTO utilizatori (nume, email, user_type, telefon, parola) 
                                   VALUES ('test', 'test@test.com', 'testType', '12345', 'testPass')";          
            // Act
            bool insertResult = repository.ExecuteNonQuery(queryInsert);

            
            string queryDelete = "DELETE FROM utilizatori WHERE email = 'test@test.com'";
            bool deleteResult = repository.ExecuteNonQuery(queryDelete);

            // Assert
            ClassicAssert.IsTrue(insertResult, "Insert operation failed.");
            ClassicAssert.IsTrue(deleteResult, "Delete operation failed.");
        }


        [Test,Order(4)]
        public void ExecuteQueryTest()
        {
            // Arrange
            string queryInsert = @"INSERT INTO utilizatori (id, nume, email, parola, user_type, telefon) 
                                   VALUES (1, 'test', 'test@test.com', 'test', 'test', '1234567890');";
            repository.ExecuteNonQuery(queryInsert);

            string selectQuery = "SELECT * FROM utilizatori WHERE id = 1;"; 

            // Act
            DataTable result = repository.ExecuteQuery(selectQuery);

            // Assert
            ClassicAssert.IsNotNull(result);
            ClassicAssert.AreEqual(1, result.Rows.Count);                         
            ClassicAssert.AreEqual(1, Convert.ToInt32(result.Rows[0]["id"]));
            ClassicAssert.AreEqual("test", result.Rows[0]["nume"].ToString());
            ClassicAssert.AreEqual("test@test.com", result.Rows[0]["email"].ToString());
            ClassicAssert.AreEqual("test", result.Rows[0]["parola"].ToString());
            ClassicAssert.AreEqual("test", result.Rows[0]["user_type"].ToString());
            ClassicAssert.AreEqual("1234567890", result.Rows[0]["telefon"].ToString());
        }

    }
}