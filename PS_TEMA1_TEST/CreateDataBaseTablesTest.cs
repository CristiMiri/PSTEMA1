using NUnit.Framework.Legacy;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEMA1_PS.Model.Repositories;

namespace PS_TEMA1_TEST
{
    [TestFixture]
    public class CreateDataBaseTablesTest
    {
        private Repository repository;
        [SetUp]
        public void SetUp()
        {
            repository = new Repository();
        }
        [Test, Order(1)]
        public void DropTableUtilizatorTest()
        {
            string query = @"DROP TABLE IF EXISTS participanti;
                            DROP TABLE IF EXISTS prezentari;
                            DROP TABLE IF EXISTS utilizatori;
                            DROP TABLE IF EXISTS conferinte;
                            ";
            bool result = repository.ExecuteNonQuery(query);
            ClassicAssert.IsTrue(result);
        }

        [Test, Order(2)]
        public void CreateTableConferinteTest()
        {

            // Arrange
            string query = @"CREATE TABLE Conferinte (
                            id SERIAL PRIMARY KEY,
                            titlu VARCHAR(100),
                            locatie VARCHAR(100),
                            data DATE
                            );";
            // Act
            bool result = repository.ExecuteNonQuery(query);

            // Assert
            ClassicAssert.IsTrue(result);
        }
        [Test, Order(3)]
        public void CreateTablePrezentariTest()
        {
            // Arrange
            string query = @"CREATE TABLE Prezentari (
                            id SERIAL PRIMARY KEY,
                            titlu VARCHAR(100),
                            autor VARCHAR(100),
                            descriere TEXT,
                            data DATE,
                            ora TIME,
                            sectiune VARCHAR(50), 
                            id_conferinta INTEGER REFERENCES Conferinte(id) -- Reference to the Conferinte table
                            );";
            // Act
            bool result = repository.ExecuteNonQuery(query);

            // Assert
            ClassicAssert.IsTrue(result);
        }
        [Test, Order(4)]
        public void CreateTableParticipantiTest()
        {

            // Arrange
            string query = @"CREATE TABLE participanti (
                            id SERIAL PRIMARY KEY,
                            nume VARCHAR(255),
                            email VARCHAR(255),
                            telefon VARCHAR(20),
                            id_prezentare INTEGER REFERENCES Prezentari(id),
                            UNIQUE(email, id_prezentare)
                            );";
            // Act
            bool result = repository.ExecuteNonQuery(query);

            // Assert
            ClassicAssert.IsTrue(result);
        }
        [Test, Order(5)]
        public void CreateTableUtilizatorTest()
        {

            // Arrange

            string query = @"
                    CREATE TABLE utilizatori (
                    id SERIAL PRIMARY KEY,
                    nume VARCHAR(255),
                    email VARCHAR(255) UNIQUE,
                    parola VARCHAR(255),
                    user_type VARCHAR(50),
                    telefon VARCHAR(20)
                    );";
            // Act
            bool result = repository.ExecuteNonQuery(query);

            // Assert
            ClassicAssert.IsTrue(result);
        }
    }
}
