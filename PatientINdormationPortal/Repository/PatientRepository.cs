using Assignment.Models;
using Microsoft.EntityFrameworkCore;
using PatientInformationPortalAPI.Interface;
using PatientInformationPortalAPI.Models;

namespace PatientInformationPortalAPI.Repository
{
    public class PatientRepository : GenericRepository<Patient>,IPatientRepository
    {
        public PatientRepository(PatientInformationPortalDbContext context, ILogger logger) : base(context, logger)
        {
        }
        public override async Task<IEnumerable<Patient>> GetAll()
        {
            try
            {
                return await dbSet.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} All function error", typeof(PatientRepository));
                return new List<Patient>();
            }
        }
        public override async Task<bool> Add(Patient entity)
        {
            try
            {
                await dbSet.AddAsync(entity);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} Upsert function error", typeof(PatientRepository));
                return false;
            }
        }
        public override async Task<bool> Update(Patient entity)
        {
            try
            {
                var existdata = await dbSet.FirstOrDefaultAsync(x => x.PatientID == entity.PatientID);

                if (existdata != null)
                {

                    existdata.PatientName = entity.PatientName;
                    existdata.DiseaseID = entity.DiseaseID;
                    existdata.Epilepsy = entity.Epilepsy;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} Upsert function error", typeof(PatientRepository));
                return false;
            }

        }
        public override async Task<bool> Delete(int id)
        {
            try
            {
                var exist = await dbSet.Where(x => x.PatientID == id)
                                        .FirstOrDefaultAsync();

                if (exist == null) return false;

                dbSet.Remove(exist);

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} Delete function error", typeof(PatientRepository));
                return false;
            }
        }
    }
}
