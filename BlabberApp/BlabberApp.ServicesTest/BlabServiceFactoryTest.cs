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
    public class BlabServiceFactoryTest
    {
        //Attributes
        private BlabServiceFactory harness;


        //Constructor
        public BlabServiceFactoryTest()
        {
            this.harness = new BlabServiceFactory();
        }


        //Methods
        [TestMethod]
        public void Canary()
        {
            Assert.AreEqual(true, true);
        }

        [TestMethod]
        public void BuildAdapterPluginTest()
        {
            //Arrange and Act
            BlabAdapter blabAdapter = this.harness.CreateBlabAdapter();

            //Assert
            Assert.IsTrue(blabAdapter is BlabAdapter);
        }

        [TestMethod]
        public void BuildServiceAdapterPluginTest()
        {
            //Arrange and Act
            BlabService blabService = this.harness.CreateBlabService();

            //Assert
            Assert.IsTrue(blabService is BlabService);
        }
    }
}
