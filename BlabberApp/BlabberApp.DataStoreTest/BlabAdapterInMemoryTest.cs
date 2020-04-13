using System;
using System.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlabberApp.DataStore.Adapters;
using BlabberApp.DataStore.Plugins;
using BlabberApp.Domain.Entities;

namespace BlabberApp.DataStoreTest
{
    [TestClass]
    public class BlabAdapter_InMemory_UnitTests
    {
        //Attributes
         private BlabAdapter _harness;


        //Constructor
         public BlabAdapter_InMemory_UnitTests()
        {
            this._harness = new BlabAdapter(new InMemory());
        }


        //Methods
        [TestMethod]
        public void Canary()
        {
            Assert.AreEqual(true, true);
        }

        [TestMethod]
        public void Add_Blab_GetByUserId_Success()
        {
            //Arrange
            string email = "user1@example.com";
            Blab expected = new Blab(new User(email));
            expected.Message = "This is a test. This is only a test. If this weren't a test, then this wouldn't be here, would it?";
            this._harness.Add(expected);

            //Act
            ArrayList blabs = this._harness.GetByUserId(email) as ArrayList;
            Blab actual = (Blab)blabs[0];

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Add_Blab_GetByUserId_Fail01()
        {
            //Arrange
            Blab expected = null;

            //Act
            var ex = Assert.ThrowsException<ArgumentNullException>(() => this._harness.Add(expected));

            //Assert
            Assert.AreEqual("Entity is null", ex.ParamName.ToString());
        }

        [TestMethod]
        public void Add_Blab_GetByUserId_Fail02()
        {
            //Arrange
            string email = "user2@example.com";
            Blab expected = new Blab(new User(email));
            this._harness.Add(expected);

            //Act
            var ex = Assert.ThrowsException<ArgumentNullException>(() => this._harness.GetByUserId(""));

            //Assert
            Assert.AreEqual("userId is null", ex.ParamName.ToString());
        }

        [TestMethod]
        public void Add_Blab_GetById_Success()
        {
            //Arrange
            string email = "user3@example.com";
            Blab expected = new Blab(new User(email));
            this._harness.Add(expected);

            //Act
            Blab actual = (Blab)this._harness.GetById(expected.Id);

            //Assert
            Assert.AreEqual(expected.Id, actual.Id);
        }

        [TestMethod]
        public void Remove_Blab_Success()
        {
            //Arrange
            string email = "user4@example.com";
            Blab Test = new Blab(new User(email));
            this._harness.Add(Test);

            //Act
            this._harness.Remove(Test);

            //Assert
            Assert.IsNull(this._harness.GetById(Test.Id));
        }

        [TestMethod]
        public void Remove_Blab_Fail()
        {
            //Arrange and Act
            Blab expected = null;

            //Assert
            Assert.ThrowsException<ArgumentNullException>(() => this._harness.Remove(expected));
        }

        [TestMethod]
        public void Update_Blab_Success()
        {
            //Arrange
            string message = "Hello, I'm a Blab!";
            Blab Test = new Blab(message);
            this._harness.Add(Test);

            //Act
            string NewMessage = "I'm a new Blab!";
            Test.Message = NewMessage;
            this._harness.Update(Test);

            //Assert
            Assert.AreEqual(NewMessage, this._harness.GetById(Test.Id).Message);
        }

        [TestMethod]
        public void GetAll_Blab_Success()
        {
            //Arrange & Act
            var AllTheBlabs = this._harness.GetAll();
            ArrayList blabs = (ArrayList)AllTheBlabs;

            //Assert
            Assert.IsTrue(AllTheBlabs is IEnumerable);
            Assert.IsTrue(blabs.Count > 0);
        }
    }
}
