using CRMSharp.Models;

namespace CRMSharp.Services
{
    public class ClientRepository : CRUDRepositoryBase<Client,CRMContext>, IClientRepository
    {
        public ClientRepository(CRMContext context) : base(context)
        {

        }

        public IAsyncEnumerable<Client> GetClientByCompanyName(string companyName)
        {
            return (IAsyncEnumerable<Client>)Context.Clients.Where(x => x.CompanyName.Equals(companyName, StringComparison.InvariantCultureIgnoreCase));
        }
    }
}
