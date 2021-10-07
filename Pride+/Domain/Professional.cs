using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pride_.Domain
{
    public class Professional : User
    {
        [Required]
        public string Register { get; set; }
        [Required]
        public virtual ProfessionalType ProfessionalType { get; set; }
        [Required]
        public string Speciality { get; set; }
        public string HealthInsurance { get; set; }
    }
}
