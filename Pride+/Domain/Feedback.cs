using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pride_.Domain
{
    public class Feedback : Professional
    {
        [MaxLength(5), MinLength(1)]
        public int Grade { get; set; }

        [MaxLength(1000), MinLength(1)]
        public int Massage { get; set; }


    }
}
