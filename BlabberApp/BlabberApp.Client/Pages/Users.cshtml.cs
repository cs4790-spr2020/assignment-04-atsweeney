using System;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BlabberApp.Services.Interfaces;

namespace BlabberApp.Client.Pages
{
    public class UsersModel : PageModel
    {
        //Attributes
        private readonly iUserService _serviceUser;


        //Constructor
        public UsersModel(iUserService userService)
        {
            this._serviceUser = userService;
        }


        //Methods
        public void OnGet()
        {
            //Unused
        }
    }
}
