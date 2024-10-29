using LoginModule.Domain.Entities;
using LoginModule.Domain.Entities.Validations;
using LoginModule.Domain.Interfaces;

namespace LoginModule.Domain.Services
{
	public class ClientService : BaseService, IClientService
	{
		private readonly IClientRepository _clientRepository;

		public ClientService(IClientRepository clientRepository,
						     INotifier notifier) : base(notifier)
		{
			_clientRepository = clientRepository;
		}

		public async Task CreateClientAsync(Client client)
		{

			//Validar se a entidade é consistente
			if (!ExecuteValidation(new ClientValidation(), client)) return;
			//Validar se ja não existe outro client com mesmos dados
			if (_clientRepository.FindAsync(c => c.Name == client.Name).Result.Any())
			{
				Notify("Cliente já cadastrado.");
				return;
			}

			await _clientRepository.AddAsync(client);
			//await _clientRepository.SaveChangesAsync();
		}

		public async Task UpdateClientAsync(Client client)
		{
			if (!ExecuteValidation(new ClientValidation(), client)) return;

			if (_clientRepository.FindAsync(c => c.Name == client.Name && c.Id != client.Id).Result.Any())
			{
				Notify("Já existe outro cliente cadastrado para este Nome!");
				return;
			}

			await _clientRepository.UpdateAsync(client);
			//await _clientRepository.SaveChangesAsync();
		}

		public async Task DeleteClientAsync(Guid id)
		{
			var client = await _clientRepository.GetByIdAsync(id);
			if (client == null)
			{
				Notify("Cliente não encontrado.");
				return;
			}

			await _clientRepository.RemoveAsync(id);
			//await _clientRepository.SaveChangesAsync();
		}

		public void Dispose()
		{
			_clientRepository?.Dispose();
		}
	}
}
