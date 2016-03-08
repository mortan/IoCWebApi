using System.Collections.Generic;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IoCWebApi;
using IoCWebApi.Controllers;
using IoCWebApi.Services;
using Moq;

namespace IoCWebApi.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            var repositoryMock = new Mock<IDataRepository>();
            repositoryMock.Setup(x => x.GetAllPersons()).Returns(new List<string> { "Depra" });

            // Arrange
            HomeController controller = new HomeController(repositoryMock.Object);

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Home Page", result.ViewBag.Title);
        }
    }
}
