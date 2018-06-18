using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ZespolRProject.Models
{
    public class UserLogin
    {

        [Required(AllowEmptyStrings = false, ErrorMessage = "Email ID required")]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Password required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        public bool isEditor { get; set; }
    }
}