using Assignment.Models;
using PatientInformationPortalAPI.Repository;

namespace PatientInformationPortalAPI.Interface
{
    public interface IPatientRepository: IGenericRepository<Patient>
    {
    }
}
