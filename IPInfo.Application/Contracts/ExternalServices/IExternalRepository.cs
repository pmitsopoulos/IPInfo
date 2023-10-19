namespace IPInfo.Application.Contracts.ExternalServices
{
    public interface IExternalRepository <T> 
    {
        Task<T> GetDetailsAsync (string searchTerm);
    }
}
