using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarPark.User.Models
{
    public class UserCreateRequestModel
    {
        [Required(ErrorMessage = "{0} is Required")]
        [DisplayName("NameSurname")]
        public string nameSurname { get; set; }

        [Required(ErrorMessage = "{0} is Required")]
        [DisplayName("JobTitle")]
        public string jobTitle { get; set; }

    }
}
