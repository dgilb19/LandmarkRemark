/*using LandmarkRemark.ClientApp.src.app.Controllers;
using LandmarkRemark.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace LandmarkRemark.Tests
{
    [TestClass]
    public class TestUserController2
    {
        [TestMethod]
        public void TestGetUser2()
        {
            var id = 1;
            var username = "Daniel";
            var password = "Password";
            var userTestData = new List<User>() { new User { 
                Id = id,
                Username = username,
                Password = password              
            } };
            var _user = MockDbSet(userTestData);
            //IQueryable<User> userss = new List<User> { new User { Id = 0 } }.AsQueryable();

            // Arrange
            var userContextMock = new Mock<userContext>();
            var usersMock = new Mock<DbSet<User>>();
            usersMock.Setup(x => x.Add(It.IsAny<User>())).Returns((User user) => _user);
            userContextMock.Setup(x => x.User).Returns(usersMock.Object);

        }

        public void testController()
        {
            // Arrange
            var manager = new MyEntityManager(contextGenerator);
            var entity = manager.GetMyEntity();
            entity.Name = "TEST UPDATE";
            manager.SaveMyEntity(entity);
            var entitySaved = manager.GetMyEntity();
            Assert.NotNull(entity);
        }
        public void Setup()
        {
            var id = 1;
            var userTestData = new List<User>() { new User { Id = id } };
            userTestData.Add(new Domain.Entity
            {
                Id = 1,
                Name = "TEST NAME"
            });
            var myDbMoq = new Mock<IMyDbContext>();
            myDbMoq.Setup(p => p.Entities).Returns(DbContextMock.GetQueryableMockDbSet<Domain.Entity>(entities));
            myDbMoq.Setup(p => p.SaveChanges()).Returns(1);
            var moq = new Mock<IDbContextGenerator>();
            moq.Setup(p => p.GenerateMyDbContext()).Returns(myDbMoq.Object);
            contextGenerator = moq.Object;
        }

        Mock<DbSet<T>> MockDbSet<T>(IEnumerable<T> list) where T : class, new()
        {
            IQueryable<T> queryableList = list.AsQueryable();
            Mock<DbSet<T>> dbSetMock = new Mock<DbSet<T>>();
            dbSetMock.As<IQueryable<T>>().Setup(x => x.Provider).Returns(queryableList.Provider);
            dbSetMock.As<IQueryable<T>>().Setup(x => x.Expression).Returns(queryableList.Expression);
            dbSetMock.As<IQueryable<T>>().Setup(x => x.ElementType).Returns(queryableList.ElementType);
            dbSetMock.As<IQueryable<T>>().Setup(x => x.GetEnumerator()).Returns(() => queryableList.GetEnumerator());
            *//*            dbSetMock.Setup(x => x.Create()).Returns(new T());*//*

            return dbSetMock;
        }
    }
}
*/