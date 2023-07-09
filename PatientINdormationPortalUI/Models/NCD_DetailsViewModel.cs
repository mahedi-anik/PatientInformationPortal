using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace PatientInformationPortaUI.Models
{
    public class NCD_DetailsViewModel
    {
        public int ID { get; set; }
        [Required]
        [DisplayName("Patient Name")]
        public int? PatientID { get; set; }
        [Required]
        [DisplayName("NCD")]
        public int? NCDID { get; set; }
    }
}
