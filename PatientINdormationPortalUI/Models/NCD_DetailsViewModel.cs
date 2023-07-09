using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using Assignment.Models;

namespace PatientInformationPortaUI.Models
{
    public class NCD_DetailsViewModel
    {
        public int ID { get; set; }
        [ForeignKey("PatientID")]
        [DisplayName("Patient Name")]
        public int? PatientID { get; set; }
        [ForeignKey("NCDID")]
        [DisplayName("NCD")]
        public int? NCDID { get; set; }
        public PatientViewModel PatientViewModel { get; set; }
        public NCD NCD { get; set; }
    }
}
