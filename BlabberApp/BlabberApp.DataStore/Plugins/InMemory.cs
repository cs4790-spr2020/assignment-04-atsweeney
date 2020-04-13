using System;
using System.Collections;
using BlabberApp.DataStore.Interfaces;
using BlabberApp.Domain.Entities;
using BlabberApp.Domain.Interfaces;

namespace BlabberApp.DataStore.Plugins
{
    public class InMemory : iBlabPlugin, iUserPlugin
    {
        //Attributes
        private ArrayList buffer;


        //Constructor
        public InMemory()
        {
            this.buffer = new ArrayList();
        }


        //Methods
        public void Create(iEntity obj)
        {
            this.buffer.Add(obj);
        }

        public IEnumerable ReadAll()
        {
            return this.buffer;
        }

        public iEntity ReadById(Guid Id)
        {
            foreach(iEntity obj in this.buffer)
            {
                if(Id.Equals(obj.Id))
                {
                    return obj;
                }
            }
            return null;
        }

        public void Update(iEntity obj)
        {
            this.Delete(obj);
            this.Create(obj);
        }
        
        public void Delete(iEntity obj)
        {
            this.buffer.Remove(obj);
        }

        public IEnumerable ReadByUserId(string Id)
        {
            return null;
        }

        public iEntity ReadByUserEmail(string email)
        {
            foreach(User user in this.buffer)
            {
                if(user.Email.Equals(email))
                {
                    return user;
                }
            }
            return null;
        }
    }
}
