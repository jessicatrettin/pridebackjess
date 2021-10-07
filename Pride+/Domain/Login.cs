using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pride_.Domain
{
    public class Login : User
    {
        [Required]
        public string UserType { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
