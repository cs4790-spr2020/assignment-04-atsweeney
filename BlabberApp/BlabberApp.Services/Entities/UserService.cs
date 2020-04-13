using System;
using System.Collections;
using BlabberApp.DataStore.Adapters;
using BlabberApp.Domain.Entities;
using BlabberApp.Services.Interfaces;

namespace BlabberApp.Services.Entities
{
    public class UserService : iUserService
    {
        //Attributes
        private readonly UserAdapter _adapter;


        //Constructor
        public UserService(UserAdapter adapter)
        {
            this._adapter = adapter;
        }


        //Methods
        public void AddNewUser(string email)
        {
            try
            {
                this._adapter.Add(CreateUser(email));
            }
            catch(Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public User CreateUser(string email)
        {
            return new User(email);
        }

        public User FindUser(string email)
        {
            return this._adapter.GetByEmail(email);
        }

        public IEnumerable GetAll()
        {
            return this._adapter.GetAll();
        }
    }
}