using Castle.Core.Configuration;
using LandmarkRemark.ClientApp.src.app.Controllers;
using LandmarkRemark.Data;
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
        public async Task TestPutUserAsync() // Q? does this not work as I am mocking the context? 
        {
            // Arrange
            var mockSet = new Mock<DbSet<User>>();
            var mockContext = new Mock<userContext>();
            //mockContext.Setup(options => options.UseSqlServer(Configuration.GetConnectionString("userContext")));
            mockContext.Setup(m => m.User).Returns(mockSet.Object);
            var service = new userController(mockContext.Object);
           // var model = new User

            //Act
            //await service.Putuser(1);

            //Verify
            mockSet.Verify(m => m.Add(It.IsAny<User>()), Times.Once());

        }
    }
}
