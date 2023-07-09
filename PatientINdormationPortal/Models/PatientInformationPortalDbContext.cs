using Assignment.Models;
using Microsoft.EntityFrameworkCore;

namespace PatientInformationPortalAPI.Models
{
    public class PatientInformationPortalDbContext:DbContext
    {
        
        public PatientInformationPortalDbContext(DbContextOptions<PatientInformationPortalDbContext> options) : base(options) { }

        public  DbSet<Patient> Patient => Set<Patient>();

        public DbSet<Disease> Diseases => Set<Disease>();

        public  DbSet<NCD> NCDs => Set<NCD>();

        public  DbSet<NCD_Details> NCD_Details => Set<NCD_Details>();

        public  DbSet<Allergies> Allergies => Set<Allergies>();

        public  DbSet<Allergies_Details> Allergies_Details => Set<Allergies_Details>();



        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //}


    }
}
