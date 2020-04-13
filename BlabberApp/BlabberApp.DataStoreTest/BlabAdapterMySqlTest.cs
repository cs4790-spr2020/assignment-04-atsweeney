using System.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlabberApp.DataStore.Adapters;
using BlabberApp.DataStore.Plugins;
using BlabberApp.Domain.Entities;

namespace BlabberApp.DataStoreTest
{
    [TestClass]
    public class BlabAdapter_MySql_UnitTests
    {
        //Attributes
         private BlabAdapter _harness;


        //Constructor
         public BlabAdapter_MySql_UnitTests()
        {
            this._harness = new BlabAdapter(new MySqlBlab());
        }


        //Methods
        [TestMethod]
        public void Canary()
        {
            Assert.AreEqual(true, true);
        }

        [TestMethod]
        public void TestAddAndGetByUserIdBlab()
        {
            //Arrange
            string email = "unique@example.com";
            Blab blab = new Blab("Now is the time for blabs...", new User(email));
            this._harness.Add(blab);

            //Act
            ArrayList actual = (ArrayList)_harness.GetByUserId(email);
            
            //Assert
            Assert.AreEqual(1, actual.Count);
        }

         [TestMethod]
        public void TestGetById()
        {
            //Arrange
            string email = "user1@example.com";
            Blab expected = new Blab("Now is the time for blabs...", new User(email));
            this._harness.Add(expected);

            //Act
            Blab actual = this._harness.GetById(expected.Id);
            
            //Assert
            Assert.AreEqual(expected.Id, actual.Id);
        }

        [TestMethod]
        public void TestGetAllBlabs()
        {
            //Arrange & Act
            ArrayList allBlabs = this._harness.GetAll() as ArrayList;

            //Assert
            Assert.IsTrue(allBlabs.Count > 0);
        }

        [TestMethod]
        public void TestRemoveBlab()
        {
            //Arrange
            string email = "anotheruser@example.com";
            Blab blab = new Blab("Now is the time for blabs...", new User(email));
            this._harness.Add(blab);

            //Act
            this._harness.Remove(blab);
            
            //Assert
            Assert.IsNull(this._harness.GetById(blab.Id));
        }

        [TestMethod]
        public void TestUpdateBlab()
        {
            //Arrange
            string email = "mindChanger@example.com";
            Blab blab = new Blab("Now is the time for blabs...", new User(email));
            this._harness.Add(blab);

            //Act
            blab.Message = "I've been updated!";
            this._harness.Update(blab);
            
            //Assert
            Assert.AreEqual("I've been updated!", this._harness.GetById(blab.Id));
        }
    }
}
