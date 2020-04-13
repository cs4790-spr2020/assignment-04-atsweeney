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
    public class FeedModel : PageModel
    {
        //Attributes
        private readonly iBlabService _serviceBlab;

        private readonly iUserService _serviceUser;


        //Constructor
        public FeedModel(iBlabService blabService, iUserService userService)
        {
            this._serviceBlab = blabService;
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
            var message = Request.Form["message"];

            try
            {
                User user = this._serviceUser.FindUser(email);
                Blab blab = this._serviceBlab.CreateBlab(message, user);

                this._serviceBlab.AddBlab(blab);
            }
            catch(Exception ex)
            {
                throw new Exception("FeedModel::OnPost: " + ex.ToString());
            }
        }
    }
}
