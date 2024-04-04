using NUnit.Framework.Legacy;
using PS_TEMA1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEMA1_PS.Model.Repositories;

namespace PS_TEMA1_TEST
{
    [TestFixture]

    public class ConferintaRepositoryTest
    {
        private Repository repository;
        private ConferintaRepository conferintaRepository;

        [SetUp]
        public void SetUp()
        {
            repository = new Repository();
            conferintaRepository = new ConferintaRepository();
        }
        [Test, Order(1)]
        public void AddConferintaTest()
        {
            Conferinta conferinta = new Conferinta();
            conferinta.Locatie = "Bucuresti";
            conferinta.Data = "2020-12-12";
            conferinta.Titlu = "Test";
            // Act
            bool result = conferintaRepository.AddConferinta(conferinta);
            // Assert
            ClassicAssert.IsTrue(result);
            
        }

        [Test, Order(2)]
        public void UpdateConferintaTest()
        {
            Conferinta conferinta = conferintaRepository.GetConferinte().Last();
            // Act            
            conferinta.Locatie = "Iasi";
            bool updateResult = conferintaRepository.UpdateConferinta(conferinta);
            // Assert
            ClassicAssert.IsTrue(updateResult);

        }

        [Test,Order(3) ]
        public void DeleteConferintaTest()
        {
            Conferinta conferinta = conferintaRepository.GetConferinte().Last();
            bool result = conferintaRepository.DeleteConferinta(conferinta.Id);
            // Assert
            ClassicAssert.IsTrue(result);
        }
    }
}
