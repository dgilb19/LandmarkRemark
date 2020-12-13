using Castle.Core.Configuration;
using LandmarkRemark.ClientApp.src.app.Controllers;
using LandmarkRemark.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;
using Xunit;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace LandmarkRemark.Tests
{
    [TestClass]
    public class TestUserController
    {
        
        public IConfiguration Configuration { get; }

        [TestMethod]
        public async Task TestGetUserAsync() // Q? does this not work as I am mocking the context? 
        {
            // Arrange
            var mockSet = new Mock<DbSet<User>>();
            var mockContext = new Mock<userContext>();
            //mockContext.Setup(options => options.UseSqlServer(Configuration.GetConnectionString("userContext")));
            mockContext.Setup(m => m.User).Returns(mockSet.Object);
            var service = new userController(mockContext.Object);
            
            //Act
            await service.Getuser(1);

            // Verify
            mockSet.Verify(m => m.Add(It.IsAny<User>()), Times.Once());

        }
        
        [TestMethod]
        public async Task TestPutUserAsync() 
        {
            // Arrange
            var mockSet = new Mock<DbSet<User>>();
            var mockContext = new Mock<userContext>();
            var mockUserDbSet = GetQueryableMockUserDbSet();
            mockContext.Setup(m => m.User).Returns(mockUserDbSet.Object);
            var service = new userController(mockContext.Object);
            var model = new User
            {
                Id = 1,
                Username = "exampleUsername",
                Password = "test"
            };

            //Act
            // Breaks on 'EntityState.Modified', unsure as to why, function works when state is ignored.
            var response = await service.Putuser(model.Id, model) as HttpStatusCodeResult; //Unsure why this does not work.

            //Verify
            Assert.IsNotNull(response);
            Assert.AreEqual((int)HttpStatusCode.OK, response.StatusCode);
        }
        
        [TestMethod]
        public async Task TestPostUserAsync()
        {
            // Arrange
            var mockSet = new Mock<DbSet<User>>();
            var mockContext = new Mock<userContext>();
            //mockContext.Setup(options => options.UseSqlServer(Configuration.GetConnectionString("userContext")));
            mockContext.Setup(m => m.User).Returns(mockSet.Object);
            var service = new userController(mockContext.Object);
            var model = new User
            {
                Id = 1,
                Username = "exampleUsername",
                Password = "test"
            };

            //Act
            await service.Postuser(model);

            //Verify
            mockSet.Verify(m => m.Add(It.IsAny<User>()), Times.Once());

        }
        
        [TestMethod]
        public async Task TestDeleteuserAsync() // Unsure why this does not work, the users should be created under the context?
                                                // possibility due to not waiting for await?
        {
            // Arrange
            var mockSet = new Mock<DbSet<User>>();
            var mockContext = new Mock<userContext>();
            var mockUserDbSet = GetQueryableMockUserDbSet();
            mockContext.Setup(m => m.User).Returns(mockUserDbSet.Object);
            //mockContext.Setup(m => m.User).Returns(mockSet.Object);
            var service = new userController(mockContext.Object);
            var model = new User
            {
                Id = 1002,
                Username = "exampleUsername",
                Password = "test"
            };

            //Act
            await service.Deleteuser(model.Id);

            //Verify
            mockSet.Verify(m => m.Add(It.IsAny<User>()), Times.Once());

        }

        private static Mock<DbSet<User>> GetQueryableMockUserDbSet()
        {
            var data = new List<User> { 
                CreateTestUser (1, "Username", "Password"),
                CreateTestUser(1002, "Daniel", "passyy"),
                CreateTestUser(1003, "Greg", "Safepassword1@")
            };

            var mockDocumentDbSet = new Mock<DbSet<User>>();
            mockDocumentDbSet.As<IQueryable<User>>().Setup(m => m.Provider).Returns(data.AsQueryable().Provider);
            mockDocumentDbSet.As<IQueryable<User>>().Setup(m => m.Expression).Returns(data.AsQueryable().Expression);
            mockDocumentDbSet.As<IQueryable<User>>().Setup(m => m.ElementType).Returns(data.AsQueryable().ElementType);
            mockDocumentDbSet.As<IQueryable<User>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            mockDocumentDbSet.Setup(m => m.Add(It.IsAny<User>())).Callback<User>(data.Add);
            return mockDocumentDbSet;
        }
        private static User CreateTestUser(int userId, string userName, string userPass)
        {
            return new User
            {
                Id = userId,
                Username = userName,
                Password = userPass
            };
        }
    }

 
}
