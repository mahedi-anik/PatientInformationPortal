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
        public Epilepsy Epilepsy { get; set; }
        public virtual ICollection<NCD_DetailsViewModel> NCD_Details { get; set; } = new List<NCD_DetailsViewModel>();
        public virtual ICollection<Allergies_DetailsModelView> Allergies_Details { get; set; } = new List<Allergies_DetailsModelView>();
    }
}
