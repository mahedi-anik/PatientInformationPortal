using Microsoft.EntityFrameworkCore;
using PatientInformationPortalAPI.Interface;
using PatientInformationPortalAPI.Models;

namespace PatientInformationPortalAPI.Repository
{
    public class UnitOfWorkRepository : IUnitOfWork, IDisposable
    {
        private readonly PatientInformationPortalDbContext _context;
        private readonly ILogger _logger;

        public IPatientRepository Patient { get; private set; }

        public IAllergiesDetailsRepository AllergiesDetails { get; private set; }

        public INCDDetailsRepository NCDDetails { get; private set; }

        public UnitOfWorkRepository(PatientInformationPortalDbContext context, ILoggerFactory loggerFactory)
        {
            _context = context;
            _logger = loggerFactory.CreateLogger("logs");

            Patient = new PatientRepository(context, _logger);
            AllergiesDetails = new AllergiesDetailsRepository(context, _logger);
            NCDDetails = new NCDDetailsRepository(context, _logger);
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
        public void Dispose()
        {
            _context.Dispose();
        }

    }
}
