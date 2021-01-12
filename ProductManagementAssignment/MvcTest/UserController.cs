using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mvc.Controllers;
using System.Web.Mvc;
using System.Linq;

namespace MvcProjectTests
{
    [TestClass]
    public class UserControllerTests
    {
        [TestMethod]
        public void Login()
        {

            //Arrange
            UserController controller = new UserController();

            //Act

            ViewResult result = controller.Login() as ViewResult;

            //Assert

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Index()
        {
            

            //Arrange
            UserController controller = new UserController();

            //Act
            ViewResult result = controller.Index() as ViewResult;

            //Assert
            Assert.IsNotNull(result);

        }
    }
}
