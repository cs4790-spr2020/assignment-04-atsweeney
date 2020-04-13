using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlabberApp.Domain.Entities;

namespace BlabberApp.DomainTest.Entities
{
    [TestClass]
    public class UserTest
    {
        [TestMethod]
        public void TestSetGetEmail_Success()
        {
            //Arrange
            User harness = new User();
            string expected = "foobar@example.com";
            harness.ChangeEmail("foobar@example.com");

            //Act
            string actual = harness.Email.ToString();

            //Assert
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void TestSetGetEmail_Fail01()
        {
            //Arrange
            User harness = new User();

            //Act
            var ex = Assert.ThrowsException<FormatException>(() => harness.ChangeEmail("Foobar"));

            //Assert
            Assert.AreEqual("Invalid email", ex.Message.ToString());
        }

        [TestMethod]
        public void TestSetGetEmail_Fail02()
        {
            //Arrange
            User harness = new User();

            //Act
            var ex = Assert.ThrowsException<FormatException>(() => harness.ChangeEmail("example.com"));

            //Assert
            Assert.AreEqual("Invalid email", ex.Message.ToString());
        }

        [TestMethod]
        public void TestSetGetEmail_Fail03()
        {
            //Arrange
            User harness = new User();

            //Act
            var ex = Assert.ThrowsException<FormatException>(() => harness.ChangeEmail("foobar.example"));

            //Assert
            Assert.AreEqual("Invalid email", ex.Message.ToString());
        }

        [TestMethod]
        public void TestId()
        {
            //Arrange
            User harness = new User();
            Guid expected = harness.Id;

            //Act
            Guid actual = harness.Id;

            //Assert
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void TestGetSetRegisterDTTM()
        {
            //Arrange
            User expected = new User();
            expected.RegisterDTTM = DateTime.Now;

            //Act
            User actual = new User();
            actual.RegisterDTTM = DateTime.Now;

            //Assert
            Assert.AreEqual(expected.RegisterDTTM.ToString(), actual.RegisterDTTM.ToString());
        }

        [TestMethod]
        public void TestGetSetLastLoginDTTM()
        {
            //Arrange
            User expected = new User();
            expected.LastLoginDTTM = DateTime.Now;

            //Act
            User actual = new User();
            actual.LastLoginDTTM = DateTime.Now;

            //Assert
            Assert.AreEqual(expected.LastLoginDTTM.ToString(), actual.LastLoginDTTM.ToString());
        }
    }
}