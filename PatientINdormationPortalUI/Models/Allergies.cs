using PatientInformationPortaUI.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PatientInformationPortalAPI.Models
{
    public class Allergies
    {
        [Key]
        public int AllergiesID { get; set; }
        [Required]
        [StringLength(25)]
        public string? AllergiesName { get; set; }
        public virtual ICollection<Allergies_DetailsModelView> Allergies_Details { get; set; } = new List<Allergies_DetailsModelView>();
    }
}
