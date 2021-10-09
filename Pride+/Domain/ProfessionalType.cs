using System.ComponentModel.DataAnnotations;

namespace Pride_.Domain
{
    public class ProfessionalType
    {
        [Key]
        public int Id { get; set; }
        public string Category { get; set; }
        public string Speciality { get; set; }


    }
}
