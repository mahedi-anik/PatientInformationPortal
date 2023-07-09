using PatientInformationPortaUI.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PatientInformationPortaUI.Models
{
    public class PatientViewModel
    { 
        public int PatientID { get; set; }
        [Required]
        [DisplayName("Patient Name")]
        public string? PatientName { get; set; }
        [Required]
        [DisplayName("Disease")]
        public int? DiseaseID { get; set; }
        [Required]
        [DisplayName("Epilepsy")]
        public Epilepsy Epilepsy { get; set; }
    }
}
