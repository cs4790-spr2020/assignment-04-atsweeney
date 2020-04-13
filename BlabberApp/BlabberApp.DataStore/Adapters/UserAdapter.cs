using System;
using System.Collections;
using BlabberApp.DataStore.Interfaces;
using BlabberApp.Domain.Entities;

namespace BlabberApp.DataStore.Adapters
{
    public class UserAdapter
    {
        //Attributes
        private iUserPlugin plugin;


        //Constructor
        public UserAdapter(iUserPlugin plugin) 
        {
            this.plugin = plugin;
        }


        //Methods
        public void Add(User user)
        {
            this.plugin.Create(user);
        }

        public void Remove(User user)
        {
            this.plugin.Delete(user);
        }

        public void Update(User user)
        {
            this.plugin.Update(user);
        }

        public IEnumerable GetAll()
        {
            return this.plugin.ReadAll();
        }

        public User GetById(Guid Id)
        {
            return (User)this.plugin.ReadById(Id);
        }

        public User GetByEmail(string email)
        {
            return (User)this.plugin.ReadByUserEmail(email);
        }
    }
}