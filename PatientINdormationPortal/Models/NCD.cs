using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment.Models
{
    public class NCD
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int NCDID { get; set; }
        [Required]
        [StringLength(25)]
        public string? NCDName { get; set; }
        public virtual ICollection<NCD_Details> NCD_Details { get; set; } = new List<NCD_Details>();
    }
}
