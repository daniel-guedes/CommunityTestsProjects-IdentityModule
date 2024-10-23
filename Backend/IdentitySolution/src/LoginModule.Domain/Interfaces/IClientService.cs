using LoginModule.Domain.Entities;

namespace LoginModule.Domain.Interfaces
{
	public interface IClientService : IDisposable
	{
		Task CreateClientAsync(Client client);
		Task UpdateClientAsync(Client client);
		Task DeleteClientAsync(Guid id);
	}
}
