using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pride_.Domain
{
    public class Patient : User
    {
        [Required]
        public DateTime BirthDate { get; set; }
    }
}
