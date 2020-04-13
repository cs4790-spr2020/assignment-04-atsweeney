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
    public class BlabServiceTest
    {
        //Attributes
        private BlabServiceFactory harness;


        //Constructor
        public BlabServiceTest()
        {
            this.harness = new BlabServiceFactory();
        }


        //Methods
        [TestMethod]
        public void TestCanary()
        {
            Assert.AreEqual(true, true);
        }

        [TestMethod]
        public void GetAllEmptyTest()
        {
            //Arrange
            BlabService blabService = this.harness.CreateBlabService();
            ArrayList expected = new ArrayList();

            //Act
            IEnumerable actual = blabService.GetAll();

            //Assert
            Assert.AreEqual(expected.Count, (actual as ArrayList).Count);
        }

        [TestMethod]
        public void AddNewBlabSuccessTest()
        {
            //Arrange
            string email = "user@example.com";
            string message = "This is just a test. This is only a test. If this weren't a test, then this wouldn't be here would it?";

            BlabService blabService = this.harness.CreateBlabService();
            Blab blab = blabService.CreateBlab(message, email);
            blabService.AddBlab(blab);

            //Act
            Blab actual = (Blab)blabService.FindUserBlabs(email)[0];

            //Assert
            Assert.AreEqual(blab.message, actual.message);
        }
    }
}