using LoginModule.Domain.Entities;

namespace LoginModule.Domain.Interfaces
{
	public interface IClientRepository : IRepository<Client>
	{
		Task<Client> GetByApiKeyAsync(string apiKey);
	}
}
