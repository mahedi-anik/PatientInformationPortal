using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment.Models
{
    public class Disease
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DiseaseID { get; set; }
        [Required]
        [StringLength(25)]
        public string? DiseaseName { get; set; }
        public virtual ICollection<Patient> Patients { get; set; } = new List<Patient>();

    }
}
