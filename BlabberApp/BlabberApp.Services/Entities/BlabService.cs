using System;
using System.Collections;
using BlabberApp.DataStore.Adapters;
using BlabberApp.Domain.Entities;
using BlabberApp.Services.Interfaces;

namespace BlabberApp.Services.Entities
{
    public class BlabService : iBlabService
    {
        //Attributes
        private readonly BlabAdapter _adapter;


        //Constructor
        public BlabService(BlabAdapter adapter)
        {
            this._adapter = adapter;
        }


        //Methods
        public void AddBlab(string message, string email)
        {
            this._adapter.Add(CreateBlab(message, email));
        }

        public void AddBlab(Blab blab)
        {
            this._adapter.Add(blab);
        }

        public Blab CreateBlab(string message, string email)
        {
            return new Blab(new User(email));
        }

        public Blab CreateBlab(string message, User user)
        {
            return new Blab(message, user);
        }

        public IEnumerable FindUserBlabs(string email)
        {
            return this._adapter.GetByUserId(email);
        }

        public IEnumerable GetAll()
        {
            return this._adapter.GetAll();
        }
    }
}