using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace VueJSSocialNetwork.Web.ViewModels
{
    public class RegistrationViewModel
    {
        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Username { get; set; }

        public int Age { get; set; }

        public string Photo { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }
    }
}
