using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CarPark.Models.RequestModel.Account
{
    public class LoginModel
    {
        [Required(ErrorMessage ="zorunlu")]
        public string UserName { get; set; }


        [PasswordPropertyText]
        [Required(ErrorMessage = "zorunlu")]
        public string Password { get; set; }

    }
}
