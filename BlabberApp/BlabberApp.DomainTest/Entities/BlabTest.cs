using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlabberApp.Domain.Entities;

namespace BlabberApp.DomainTest.Entities
{
    [TestClass]
    public class BlabTest
    {
        //Attributes
        private Blab harness;


        //Constructor
        public BlabTest()
        {
            this.harness = new Blab();
        }

        [TestMethod]
        public void TestSetGetMessage()
        {
            //Arrange
            string expected = "This is just a test. If this weren't a test, then this wouldn't be here, would it?";
            this.harness.Message = "This is just a test. If this weren't a test, then this wouldn't be here, would it?";

            //Act
            string actual = this.harness.Message;

            //Assert
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void TestId()
        {
            //Arrange
            Guid expected = this.harness.Id;

            //Act
            Guid actual = this.harness.Id;

            //Assert
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void TestDTTM()
        {
            //Arrange
            Blab Expected = new Blab();

            //Act
            Blab Actual = new Blab();

            //Assert
            Assert.AreEqual(Expected.DTTM.ToString(), Actual.DTTM.ToString());
        }
    }
}
