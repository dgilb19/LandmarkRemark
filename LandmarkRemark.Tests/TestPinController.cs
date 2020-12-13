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
    public class TestPinController
    {
        
        public IConfiguration Configuration { get; }

        [TestMethod]
        public async Task TestGetpinAsync() // Q? does this not work as I am mocking the context? 
        {
            // Arrange
            var mockSet = new Mock<DbSet<Pin>>();
            var mockContext = new Mock<userContext>();
            mockContext.Setup(m => m.Pin).Returns(mockSet.Object);
            var service = new PinsController(mockContext.Object);
            
            //Act
            await service.GetPin(1);

            // Verify
            mockSet.Verify(m => m.Add(It.IsAny<Pin>()), Times.Once());

        }
        
        [TestMethod]
        public async Task TestPutPinAsync() // Not implemented in application
        {
            // Arrange
            var mockSet = new Mock<DbSet<Pin>>();
            var mockContext = new Mock<userContext>();
            var mockUserDbSet = GetQueryableMockPinDbSet();
            mockContext.Setup(m => m.Pin).Returns(mockUserDbSet.Object);
            var service = new PinsController(mockContext.Object);
            var model = new Pin
            {
                PinId = 1,
                UserId = 1,
                Longitude = 152,
                Latitudes = -28,
                Note = "note"
            };

            //Act
            // Breaks on 'EntityState.Modified', unsure as to why, function works when state is ignored.
            var response = await service.PutPin(model.PinId, model) as HttpStatusCodeResult; //Unsure why this does not work.

            //Verify
            Assert.IsNotNull(response);
            Assert.AreEqual((int)HttpStatusCode.OK, response.StatusCode);
        }
        
        [TestMethod]
        public async Task TestPostPinAsync() 
        {
            // Arrange
            var mockSet = new Mock<DbSet<Pin>>();
            var mockContext = new Mock<userContext>();
            mockContext.Setup(m => m.Pin).Returns(mockSet.Object);
            var service = new PinsController(mockContext.Object);
            var model = new Pin
            {
                PinId = 1,
                UserId = 1,
                Longitude = 152,
                Latitudes = -28,
                Note = "note"
            };

            //Act
            await service.PostPin(model);

            //Verify
            mockSet.Verify(m => m.Add(It.IsAny<Pin>()), Times.Once());

        }
        
        [TestMethod]
        public async Task TestDeletePinAsync()  // This should fail?
        {
            // Arrange
            var mockSet = new Mock<DbSet<Pin>>();
            var mockContext = new Mock<userContext>();
            var mockUserDbSet = GetQueryableMockPinDbSet();
            mockContext.Setup(m => m.Pin).Returns(mockUserDbSet.Object);
            var service = new PinsController(mockContext.Object);
            var model = new Pin
            {
                PinId = 1,
                UserId = 1,
                Longitude = 152,
                Latitudes = -28,
                Note = "note"
            };

            //Act
            await service.DeletePin(model.PinId);

            //Verify
            //mockSet.Verify(m => m.Add(It.IsAny<Pin>()), Times.Once());

        }

        private static Mock<DbSet<Pin>> GetQueryableMockPinDbSet()
        {
            var data = new List<Pin> {
                CreateTestPin(1, 1, 152, -28, "lots of words"),
                CreateTestPin(2, 1, 155, -28, "Second pin"),
                CreateTestPin(3, 1, 153, -28, "more pins")
            };

            var mockDocumentDbSet = new Mock<DbSet<Pin>>();
            mockDocumentDbSet.As<IQueryable<Pin>>().Setup(m => m.Provider).Returns(data.AsQueryable().Provider);
            mockDocumentDbSet.As<IQueryable<Pin>>().Setup(m => m.Expression).Returns(data.AsQueryable().Expression);
            mockDocumentDbSet.As<IQueryable<Pin>>().Setup(m => m.ElementType).Returns(data.AsQueryable().ElementType);
            mockDocumentDbSet.As<IQueryable<Pin>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            mockDocumentDbSet.Setup(m => m.Add(It.IsAny<Pin>())).Callback<Pin>(data.Add);
            return mockDocumentDbSet;
        }
        private static Pin CreateTestPin(int pinId, int userId, decimal longitude, decimal latitude, string note)
        {
            return new Pin
            {

                PinId = pinId,
                UserId = userId,
                Longitude = longitude,
                Latitudes = latitude,
                Note = note
            };
        }
    }

 
}
