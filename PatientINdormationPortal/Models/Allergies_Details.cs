using Assignment.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PatientInformationPortalAPI.Models
{
    public class Allergies_Details
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public int? PatientID { get; set; }
        public int? AllergiesID { get; set; }
        public virtual Patient? Patient { get; private set; }
        public virtual Allergies? Allergies { get; private set; }
    }
}
