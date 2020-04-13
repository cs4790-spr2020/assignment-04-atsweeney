using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BlabberApp.Domain.Entities;
using BlabberApp.Services.Interfaces;


namespace BlabberApp.Client.Pages
{
    public class RegisterModel : PageModel
    {
        //Attributes
        private readonly iUserService _serviceUser;


        //Constructor
        public RegisterModel(iUserService userService)
        {
            this._serviceUser = userService;
        }


        //Methods
        public void OnGet()
        {
            //Unused
        }

        public void OnPost()
        {
            var email = Request.Form["emailaddress"];

            try
            {
                this._serviceUser.AddNewUser(email);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
    }
}
