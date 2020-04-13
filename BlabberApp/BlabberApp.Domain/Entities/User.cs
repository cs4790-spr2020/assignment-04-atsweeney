using System;
using System.Net.Mail;
using BlabberApp.Domain.Interfaces;

namespace BlabberApp.Domain.Entities
{
    public class User : iEntity
    {
        //Properties
        public Guid Id { get; set; }

        public DateTime RegisterDTTM { get; set; }

        public DateTime LastLoginDTTM { get; set; }

        public string Email {get; private set; }


        //Constrcutors
        public User()
        {
            this.Id = Guid.NewGuid();
        }

        public User(string email)
        {
            this.Id = Guid.NewGuid();
            this.ChangeEmail(email);
        }


        //Methods
        public void ChangeEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email) || email.Length > 50)
            {
                throw new FormatException("Invalid email");
            }

            try 
            {
                MailAddress m = new MailAddress(email);
            }
            catch(FormatException)
            {
                throw new FormatException("Invalid email");
            }

            this.Email = email;
        }

        public bool IsValid()
        {
            if(this.Id == null)
            {
                throw new ArgumentNullException("Id", "null Id");
            }

            if(this.Email == null)
            {
                throw new ArgumentNullException("Email", "null Email");
            }

            if(this.Email.ToString() == "")
            {
                throw new FormatException("Invalid email");
            }

            if(this.LastLoginDTTM == null)
            {
                throw new ArgumentNullException("LastLoginDTTM", "null LastLoginDTTM");
            }

            if(this.RegisterDTTM == null)
            {
                throw new ArgumentNullException("RegisterDTTM", "null RegisterDTTM");
            }

            return true;
        }
    }
}