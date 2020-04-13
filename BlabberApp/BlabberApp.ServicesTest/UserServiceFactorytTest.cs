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
    public class UserServiceFactoryTest
    {
        //Attributes
        private UserServiceFactory harness;


        //Constructor
        public UserServiceFactoryTest()
        {
            this.harness = new UserServiceFactory();
        }


        //Methods
        [TestMethod]
        public void BuildAdapterPluginTest()
        {
            //Arrange and Act
            UserAdapter userAdapter = this.harness.CreateUserAdapter();

            //Assert
            Assert.IsTrue(userAdapter is UserAdapter);
        }

        [TestMethod]
        public void BuildServiceAdapterPluginTest()
        {
            //Arrange and Act
            UserService userService = this.harness.CreateUserService();

            //Assert
            Assert.IsTrue(userService is UserService);
        }
    }
}