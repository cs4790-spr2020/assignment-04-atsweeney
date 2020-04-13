using System;
using System.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlabberApp.DataStore.Adapters;
using BlabberApp.DataStore.Plugins;
using BlabberApp.Domain.Entities;
using BlabberApp.Services.Entities;

namespace BlabberApp.ServicesTest
{
    [TestClass]
    public class UserServiceTest
    {
        //Attributes
        private UserServiceFactory harness;


        //Constructor
        public UserServiceTest()
        {
            this.harness = new UserServiceFactory();
        }


        //Methods
        [TestMethod]
        public void Canary()
        {
            Assert.AreEqual(true, true);
        }

        [TestMethod]
        public void GetAllEmptyTest()
        {
            //Arrange
            UserService userService = this.harness.CreateUserService();
            ArrayList expected = new ArrayList();

            //Act
            IEnumerable actual = userService.GetAll();

            //Assert
            Assert.AreEqual(expected.Count, (actual as ArrayList).Count);
        }

        [TestMethod]
        public void AddNewUserSuccessTest()
        {
            //Arrange
            string email = "user@example.com";

            UserService userService = this.harness.CreateUserService();
            User expected = userService.CreateUser(email);
            userService.AddNewUser(email);

            //Act
            User actual = (User)userService.FindUser(email);

            //Assert
            Assert.AreEqual(expected.Email, actual.Email);
        }
    }
}