using LoginModule.Domain.Entities;
using LoginModule.Domain.Entities.Validations;
using LoginModule.Domain.Interfaces;
using System.Linq;

namespace LoginModule.Domain.Services
{
	public class SystemDomainService : BaseService, ISystemDomainService
	{
		private readonly ISystemDomainRepository _systemDomainRepository;

        public SystemDomainService(ISystemDomainRepository systemDomainRepository,
								   INotifier notifier) : base(notifier)
		{
			_systemDomainRepository = systemDomainRepository;
        }

        public async Task CreateDomainAsync(SystemDomain domain)
		{
			if (!ExecuteValidation(new SystemDomainValidation(), domain)) return;

			if (_systemDomainRepository.FindAsync(d => d.DomainName == domain.DomainName).Result.Any())
			{
				Notify("Já existe outro usuário cadastrado para este Nome de Domínio!");
				return;
			}

			await _systemDomainRepository.AddAsync(domain);
		}
		
		public async Task UpdateDomainAsync(SystemDomain domain)
		{
			if (!ExecuteValidation(new SystemDomainValidation(), domain)) return;

			if (_systemDomainRepository.FindAsync(d => d.DomainName == domain.DomainName && d.Id != domain.Id).Result.Any())
			{
				Notify("Já existe outro usuário cadastrado para este Nome de Domínio!");
				return;
			}
			await _systemDomainRepository.UpdateAsync(domain);
		}

		public async Task DeleteDomainAsync(Guid id)
		{
			var existingDomain = await _systemDomainRepository.GetByIdAsync(id);
			if (existingDomain != null)
			{
				Notify("Nenhum domínio encontrado com o id informado!");
				return;
			}

			await _systemDomainRepository.RemoveAsync(id);
		}

		public void Dispose()
		{
			_systemDomainRepository?.Dispose();
		}

	}
}
