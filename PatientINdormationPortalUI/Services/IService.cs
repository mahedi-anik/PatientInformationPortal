using Assignment.Models;
using PatientInformationPortalAPI.Models;
using System.Drawing.Drawing2D;

namespace PatientINdormationPortalUI.Services
{
    public interface IService
    {
        Task<List<Disease>> GetAllDiseases();
        Task<List<Allergies>> GetAllAllergies();
        Task<List<NCD>> GetAllNCDs();
    }
}
