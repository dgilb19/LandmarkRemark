using LandmarkRemark.ClientApp.src.app.Controllers;
using LandmarkRemark.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace LandmarkRemark.Tests
{
    [TestClass]
    public class TestUserController
    {
        [TestMethod]
       /* public void TestGetUser()
        {*/
            // Arrange
        /*    var mockController = new Mock<userController>();
            mockController.Setup(controller => controller.ListAsync());
            var controller = new userContext(userContext.Object);

            var function = new userController()
*/

            // Act


            // Assert
  
        //}

 /*       [TestMethod]
        public void TestPutUser()
        {
            var mockuserContext = new Mock<userContext>();
            var _userContext = new userContext(mockuserContext.Object);

            var controller = new userController(_userContext);
            var result = (OkObjectResult)controller.GetFoo();
            Assert.AreEqual(200, result.StatusCode);

            dynamic resultModel = DynamicExtensions.ToDynamic(result.Value);

            Assert.AreEqual("The Quick Brown Fox Jumped Over The Lazy Dog", resultModel.Text);
        }
*/
        public void TestGetUser()
        {
            // Arrange
            var id = 1;
            var userTestData = new List<User>() { new User { Id = id } };
            var _user = MockDbSet(userTestData);

            var dbContext = new Mock<userContext>();
            dbContext.Setup(m => m.User).Returns(_user.Object);

            var controller = new userController(dbContext.Object);

            // Act
            var results = controller.Getuser(id);

            // Assert
         


        }
        Mock<DbSet<T>> MockDbSet<T>(IEnumerable<T> list) where T : class, new()
        {
            IQueryable<T> queryableList = list.AsQueryable();
            Mock<DbSet<T>> dbSetMock = new Mock<DbSet<T>>();
            dbSetMock.As<IQueryable<T>>().Setup(x => x.Provider).Returns(queryableList.Provider);
            dbSetMock.As<IQueryable<T>>().Setup(x => x.Expression).Returns(queryableList.Expression);
            dbSetMock.As<IQueryable<T>>().Setup(x => x.ElementType).Returns(queryableList.ElementType);
            dbSetMock.As<IQueryable<T>>().Setup(x => x.GetEnumerator()).Returns(() => queryableList.GetEnumerator());
/*            dbSetMock.Setup(x => x.Create()).Returns(new T());*/

            return dbSetMock;
        }
    }

}
