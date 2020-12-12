/*using LandmarkRemark.ClientApp.src.app.Controllers;
using LandmarkRemark.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;

namespace LandmarkRemark.Tests
{
    [TestClass]
    public class TestUserController3
    {
        [TestMethod]
        [System.Obsolete]
        public void TestGetUser3()
        {
            *//* Arrange *//*
            var userController = new Mock<userController>();

            var userMock = new Mock<userContext>();
            userMock.Setup(u => u.ToListAsync()).Returns(true);

            var contextMock = new Mock<HttpContext>();
            contextMock.SetupGet(c => c.User);//.Returns(userMock.Object);

            var controllerContextMock = new Mock<userController>();
            controllerContextMock.ExpectGet(con => con.HttpContext).Returns(contextMock.Object);

            //_userController.userContext = controllerContextMock.Object;
            *//* userController.userController = controllerContextMock.Object;
             var result = userController.Index();
             userMock.Verify(p => p.IsInRole("admin"));*//*
            Assert.IsNotNull(controllerContextMock); //AreEqual(((ViewResult)result).ViewName, "Index");

        }
    }

}
*/