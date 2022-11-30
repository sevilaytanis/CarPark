using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CarPark.Models.RequestModel.Account
{
    public class RegisterCreateModel
    {
        [Required(ErrorMessage ="zorunlu")]
        public string UserName { get; set; }

        [EmailAddress(ErrorMessage ="format düzgün değil")]
        [Required(ErrorMessage = "zorunlu")]
        public string Email { get; set; }

        [PasswordPropertyText]
        [Required(ErrorMessage = "zorunlu")]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage ="Uyuşmuyor")]
        [PasswordPropertyText]
        [Required(ErrorMessage = "zorunlu")]
        public string ConfirmPassword { get; set; }
    }
}
