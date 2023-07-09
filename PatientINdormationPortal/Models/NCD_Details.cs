using Assignment.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment.Models
{
    public class NCD_Details
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public int? PatientID { get; set; }
        public int? NCDID { get; set; }
        public virtual Patient? Patient { get; private set; }
        public virtual NCD? NCD { get; private set; }
    }
}
