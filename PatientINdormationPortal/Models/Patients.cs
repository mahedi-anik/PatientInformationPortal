using PatientInformationPortalAPI.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment.Models
{
    public class Patient
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PatientID {get;set; }
        [Required]
        [StringLength(25)]
        public string? PatientName { get; set; }
        public int? DiseaseID { get; set; }
        [Required]
        [StringLength(3)]
        public string? Epilepsy { get;set; }
        public virtual Disease? Disease { get; private set; }
        public virtual ICollection<NCD_Details> NCD_Details { get; set; } = new List<NCD_Details>();
        public virtual ICollection<Allergies_Details> Allergies_Details  { get; set; } = new List<Allergies_Details>();

    }
}
