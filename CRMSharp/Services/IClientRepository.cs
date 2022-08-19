using CRMSharp.Models;

namespace CRMSharp.Services
{
    public interface IClientRepository : ICRUD<Client>
    {
        IAsyncEnumerable<Client> GetClientByCompanyName(string companyName);
    }
}
