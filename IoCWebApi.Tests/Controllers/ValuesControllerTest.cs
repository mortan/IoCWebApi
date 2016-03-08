using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IoCWebApi;
using IoCWebApi.Controllers;
using IoCWebApi.Services;
using Moq;

namespace IoCWebApi.Tests.Controllers
{
    [TestClass]
    public class ValuesControllerTest
    {
        private Mock<IDataRepository> repositoryMock;

        [TestInitialize]
        public void SetUp()
        {
            repositoryMock = new Mock<IDataRepository>();
            repositoryMock.Setup(x => x.GetAllPersons()).Returns(new List<string> { "Depra" });
        }

        [TestMethod]
        public void Get()
        {
            // Arrange
            ValuesController controller = new ValuesController(repositoryMock.Object);

            // Act
            IEnumerable<string> result = controller.Get();

            // Assert

            // Wir testen das Verhalten der SUT anhand unseres gemockten IDataRepository's!
            // Implementierte Interface-Methoden sind virtual, deshalb kann ein Mocking-Framework auch entsprechende
            // Überschreibungen für uns generieren. => vermeidet eine unkontrollierbare Anzahl von Müllklassen in unseren Testprojekten (die natürlich auch gewartet werden müssen...)
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count());
            Assert.AreEqual("Depra", result.ElementAt(0));

            // Außerdem erlaubt uns ein vernünftiges Mocking-Framework Verhalten zu verifizieren, d. h. z. B. zu überprüfen ob und wie oft gewisse Methoden aufgerufen wurden!
            repositoryMock.Verify(x => x.Authenticate(), Times.Once);
        }
    }
}
