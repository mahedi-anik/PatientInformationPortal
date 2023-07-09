namespace PatientInformationPortalAPI.Interface
{
    public interface IUnitOfWork
    {
        IPatientRepository Patient { get; }
        IAllergiesDetailsRepository AllergiesDetails { get; }
        INCDDetailsRepository NCDDetails { get; }
        Task CompleteAsync();
        void Dispose();
    }
}
