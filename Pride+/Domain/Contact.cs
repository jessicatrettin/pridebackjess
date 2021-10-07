using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pride_.Domain
{
    public class Contact : User
    {
        public string CauseComplain { get; set; }

        [MaxLength(1000), MinLength(1)]
        public string Message { get; set; }
    }
}
