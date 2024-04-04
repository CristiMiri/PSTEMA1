using NUnit.Framework.Legacy;
using PS_TEMA1.Model;
using PS_TEMA1.Model.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEMA1_PS.Model.Repositories;


namespace PS_TEMA1_TEST
{
    [TestFixture]
    public class UtilizatoriRepositoryTest
    {
        private Repository repository;
        private UtilizatorRepository utilizatorRepository;

        [SetUp]
        public void SetUp()
        {
            repository = new Repository();
            utilizatorRepository = new UtilizatorRepository();
        }
        [Test, Order(1)]
        public void AddUtilizatorTest()
        {
            Utilizator utilizator = new Utilizator();
            utilizator.Nume = "Test";
            utilizator.Email = "@mail.com";
            utilizator.Parola = "parola";
            utilizator.UserType = UserType.PARTICIPANT;
            utilizator.Telefon = "1234567890";
            // Act
            bool result = utilizatorRepository.addUtilizator(utilizator);
            // Assert
            ClassicAssert.IsTrue(result);
            
        }

        [Test, Order(2)]
        public void UpdateUtilizatorTest()
        {
            Utilizator utilizator = utilizatorRepository.GetUtilizatorbyEmailandParola("@mail.com", "parola");
            // Act            
            utilizator.Nume = "Test2";
            bool updateResult = utilizatorRepository.updateUtilizator(utilizatorRepository.GetUtilizatorbyEmailandParola("@mail.com", "parola"));
            // Assert
            ClassicAssert.IsTrue(updateResult);

        }

        [Test]
        public void DeleteUtilizatorTest()
        {
            Utilizator utilizator = utilizatorRepository.GetUtilizatorbyEmailandParola("@mail.com", "parola");
            bool result = utilizatorRepository.deleteUtilizator(utilizator.Id);
            // Assert
            ClassicAssert.IsTrue(result);

        }
    }
}
