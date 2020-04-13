using System.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlabberApp.DataStore.Adapters;
using BlabberApp.DataStore.Plugins;
using BlabberApp.Domain.Entities;

namespace BlabberApp.DataStoreTest
{
    [TestClass]
    public class UserAdapter_MySql_UnitTests
    {
        //Attributes
         private UserAdapter _harness;


        //Constructor
         public UserAdapter_MySql_UnitTests()
        {
            this._harness = new UserAdapter(new MySqlUser());
        }


        //Methods
        [TestMethod]
        public void Canary()
        {
            Assert.AreEqual(true, true);
        }

        [TestMethod]
        public void TestAddAndGetByIdUser()
        {
            //Arrange
            User user = new User("user2000@example.com");
            this._harness.Add(user);

            //Act
            User actual = this._harness.GetById(user.Id);
            
            //Assert
            Assert.AreEqual(user.Email, actual.Email);
        }

         [TestMethod]
        public void TestGetByEmail()
        {
            //Arrange
            User user = new User("user2001@example.com");
            this._harness.Add(user);

            //Act
            User actual = this._harness.GetByEmail(user.Email);
            
            //Assert
            Assert.AreEqual(user.Id, actual.Id);
        }

        [TestMethod]
        public void TestGetAllUsers()
        {
            //Arrange & Act
            ArrayList allUsers = this._harness.GetAll() as ArrayList;

            //Assert
            Assert.IsTrue(allUsers.Count > 0);
        }

        [TestMethod]
        public void TestRemoveUser()
        {
            //Arrange
            User user = new User("user2002@example.com");
            this._harness.Add(user);

            //Act
            this._harness.Remove(user);
            
            //Assert
            Assert.IsNull(this._harness.GetById(user.Id));
        }

        [TestMethod]
        public void TestUpdateUser()
        {
            //Arrange
            string Email = "user2003@example.com";
            User Test = new User(Email);
            this._harness.Add(Test);

            //Act
            Test.ChangeEmail("newUser2003@example.com");
            this._harness.Update(Test);

            //Assert
            Assert.AreEqual("newUser2003@example.com", this._harness.GetById(Test.Id));
        }
    }
}
