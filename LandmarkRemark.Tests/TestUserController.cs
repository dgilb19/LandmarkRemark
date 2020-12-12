using Castle.Core.Configuration;
using LandmarkRemark.ClientApp.src.app.Controllers;
using LandmarkRemark.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace LandmarkRemark.Tests
{
    [TestClass]
    public class TestUserController
    {
        
        public IConfiguration Configuration { get; }

        [TestMethod]
        public async Task TestGetUserAsync()
        {
            // Arrange
            var mockSet = new Mock<DbSet<User>>();
            var mockContext = new Mock<userContext>();
            //mockContext.Setup(options => options.UseSqlServer(Configuration.GetConnectionString("userContext")));
            mockContext.Setup(m => m.User).Returns(mockSet.Object);

            var service = new userController(mockContext.Object);
            await service.Getuser(1);

            mockSet.Verify(m => m.Add(It.IsAny<User>()), Times.Once());

        }

        private static Mock<DbSet<User>> GetQueryableMockUserDbSet()
        {
            var data = new List<User> { getUser() };

            var mockDocumentDbSet = new Mock<DbSet<User>>();
            mockDocumentDbSet.As<IQueryable<User>>().Setup(m => m.Provider).Returns(data.AsQueryable().Provider);
            mockDocumentDbSet.As<IQueryable<User>>().Setup(m => m.Expression).Returns(data.AsQueryable().Expression);
            mockDocumentDbSet.As<IQueryable<User>>().Setup(m => m.ElementType).Returns(data.AsQueryable().ElementType);
            mockDocumentDbSet.As<IQueryable<User>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            mockDocumentDbSet.Setup(m => m.Add(It.IsAny<User>())).Callback<User>(data.Add);
            return mockDocumentDbSet;
        }

        private static User getUser()
        {
            return new User
            {
                Id = 1,
                Username = "Dan",
                Password = "pass"

            };
        }
    }
}
