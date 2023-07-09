using PatientInformationPortalAPI.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PatientInformationPortaUI.Models
{
    public class Allergies_DetailsModelView
    {
        public int ID { get; set; }
        [ForeignKey("PatientID")]
        [DisplayName("Patient Name")]
        public int? PatientID { get; set; }
        [ForeignKey("AllergiesID")]
        [DisplayName("Allergies")]
        public int? AllergiesID { get; set; }
        public PatientViewModel PatientViewModel { get; set; }
        public Allergies Allergies { get; set; }
    }
}
