using System;
using BlabberApp.Domain.Interfaces;

namespace BlabberApp.Domain.Entities
{
    public class Blab : iEntity
    {
        //Properties
        public Guid Id { get; set; }

        public DateTime DTTM { get; set; }

        public string Message { get; set; }

        public User User { get; set; }


        //Constructors
        public Blab()
        {
            this.Id = Guid.NewGuid();
            this.User = new User();
            this.Message = "";
            this.DTTM = DateTime.Now;
        }

        public Blab(string message)
        {
            this.Id = Guid.NewGuid();
            this.User = new User();
            this.Message = message;
            this.DTTM = DateTime.Now;
        }

        public Blab(User user)
        {
            this.Id = Guid.NewGuid();
            this.User = user;
            this.Message = "";
            this.DTTM = DateTime.Now;
        }

        public Blab(string message, User user)
        {
            this.Id = Guid.NewGuid();
            this.User = user;
            this.Message = message;
            this.DTTM = DateTime.Now;
        }


        //Methods
        public bool IsValid()
        {
            if(this.Id == null)
            {
                throw new ArgumentNullException("Id", "null Id");
            }

            if(this.DTTM == null)
            {
                throw new ArgumentNullException("DTTM", "null DTTM");
            }

            if(this.Message == null)
            {
                throw new ArgumentNullException("Message", "null Message");
            }

            if(this.User == null)
            {
                throw new ArgumentNullException("User", "null User");
            }

            return true;
        }
    }
}