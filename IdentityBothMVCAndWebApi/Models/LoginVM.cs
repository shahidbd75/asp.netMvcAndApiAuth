using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IdentityBothMVCAndWebApi.Models
{
    public class LoginVM
    {
        [Required]
        public string UserName { get; set; }
        [DataType(DataType.Password)]
        [MinLength(5, ErrorMessage = "Password minimum length 5 digit")]
        public string Password { get; set; }
    }
    public class RegisterVM
    {
        [Required]
        public string UserName { get; set; }
        [DataType(DataType.Password)]
        [MinLength(5,ErrorMessage="Password minimum length 5 digit")]
        public string Password { get; set; }
    }
}