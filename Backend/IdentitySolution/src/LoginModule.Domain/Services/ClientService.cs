using LoginModule.Domain.Entities;
using LoginModule.Domain.Interfaces;

namespace LoginModule.Domain.Services
{
	public class ClientService : BaseService, IClientService
	{
		private readonly IClientRepository _clientRepository;

		public ClientService(IClientRepository clientRepository)
		{
			//Validar se a entidade é consistente

			//Validar se ja não existe outro client com mesmos dados

			_clientRepository = clientRepository;
		}

		public async Task CreateClientAsync(Client client)
		{
			await _clientRepository.AddAsync(client);
		}

		public async Task UpdateClientAsync(Client client)
		{
			await _clientRepository.UpdateAsync(client);
		}

		public async Task DeleteClientAsync(Guid id)
		{
			await _clientRepository.RemoveAsync(id);
		}

		public void Dispose()
		{
			_clientRepository?.Dispose();
		}
	}
}
