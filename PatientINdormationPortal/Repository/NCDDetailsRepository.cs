using Assignment.Models;
using Microsoft.EntityFrameworkCore;
using PatientInformationPortalAPI.Interface;
using PatientInformationPortalAPI.Models;

namespace PatientInformationPortalAPI.Repository
{
    public class NCDDetailsRepository : GenericRepository<NCD_Details>, INCDDetailsRepository
    {
        public NCDDetailsRepository(PatientInformationPortalDbContext context, ILogger logger) : base(context, logger)
        {
        }
        public override async Task<IEnumerable<NCD_Details>> GetAll()
        {
            try
            {
                return await dbSet.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} All function error", typeof(NCDDetailsRepository));
                return new List<NCD_Details>();
            }
        }
        public override async Task<bool> Add(NCD_Details entity)
        {
            try
            {
                await dbSet.AddAsync(entity);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} Upsert function error", typeof(NCDDetailsRepository));
                return false;
            }
        }
        public override async Task<bool> Update(NCD_Details entity)
        {
            try
            {
                var existdata = await dbSet.FirstOrDefaultAsync(x => x.ID == entity.ID);

                if (existdata != null)
                {
                    existdata.PatientID = entity.PatientID;
                    existdata.NCDID = entity.NCDID;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} Upsert function error", typeof(NCDDetailsRepository));
                return false;
            }

        }
        public override async Task<bool> Delete(int id)
        {
            try
            {
                var exist = await dbSet.Where(x => x.ID == id)
                                        .FirstOrDefaultAsync();

                if (exist == null) return false;

                dbSet.Remove(exist);

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} Delete function error", typeof(NCDDetailsRepository));
                return false;
            }
        }
    }
}
