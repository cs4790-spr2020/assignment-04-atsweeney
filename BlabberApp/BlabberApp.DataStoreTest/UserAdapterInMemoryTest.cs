using System.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlabberApp.DataStore.Adapters;
using BlabberApp.DataStore.Plugins;
using BlabberApp.Domain.Entities;

namespace BlabberApp.DataStoreTest
{
    [TestClass]
    public class UserAdapter_InMemory_UnitTests
    {
        //Attributes
         private UserAdapter _harness;


        //Constructor
         public UserAdapter_InMemory_UnitTests()
        {
            this._harness = new UserAdapter(new InMemory());
        }


        //Methods
        [TestMethod]
        public void Canary()
        {
            Assert.AreEqual(true, true);
        }

        [TestMethod]
        public void Add_User_GetById()
        {
            //Arrange
            string Email = "user1000@example.com";
            User Expected = new User(Email);
            this._harness.Add(Expected);

            //Act
            User Actual = (User)this._harness.GetById(Expected.Id);

            //Assert
            Assert.AreEqual(Expected.Email, Actual.Email);
        }

        [TestMethod]
        public void Add_User_GetByEmail()
        {
            //Arrange
            string Email = "user1001@example.com";
            User Expected = new User(Email);
            this._harness.Add(Expected);

            //Act
            User Actual = (User)this._harness.GetByEmail(Expected.Email);

            //Assert
            Assert.AreEqual(Expected.Email, Actual.Email);
        }

        [TestMethod]
        public void Remove_User()
        {
            //Arrange
            string Email = "user1002@example.com";
            User Test = new User(Email);
            this._harness.Add(Test);

            //Act
            this._harness.Remove(Test);

            //Assert
            Assert.IsNull(this._harness.GetById(Test.Id));
        }

        [TestMethod]
        public void Update_User()
        {
            //Arrange
            string Email = "user1003@example.com";
            User Test = new User(Email);
            this._harness.Add(Test);

            //Act
            Test.ChangeEmail("newUser1003@example.com");
            this._harness.Update(Test);

            //Assert
            Assert.AreEqual("newUser1003@example.com", this._harness.GetById(Test.Id));
        }

        [TestMethod]
        public void GetAll_User_Success()
        {
            //Arrange & Act
            var AllTheUsers = this._harness.GetAll();
            ArrayList users = (ArrayList)AllTheUsers;

            //Assert
            Assert.IsTrue(AllTheUsers is IEnumerable);
        }
    }
}
