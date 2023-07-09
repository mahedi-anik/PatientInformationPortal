using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PatientInformationPortaUI.Models
{
    public class Allergies_DetailsModelView
    {
        public int ID { get; set; }
        [Required]
        [DisplayName("Patient Name")]
        public int? PatientID { get; set; }
        [Required]
        [DisplayName("Allergies")]
        public int? AllergiesID { get; set; }
    }
}
