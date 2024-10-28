using LoginModule.Domain.Entities;
using LoginModule.Domain.Entities.Validations;
using LoginModule.Domain.Interfaces;
using System.Security;

namespace LoginModule.Domain.Services
{
	public class RoleService : BaseService, IRoleService
	{
		private readonly IRoleRepository _roleRepository;

		public RoleService(IRoleRepository roleRepository)
		{
			_roleRepository = roleRepository;
		}

		public async Task CreateRoleAsync(Role role)
		{
			if (!ExecuteValidation(new RoleValidation(), role)) return;

			//verificar se o nome da role já existe
			if (_roleRepository.FindAsync(r => r.Name == role.Name).Result.Any())
			{
				Notify("Role já existente.");
				return;
			}

			await _roleRepository.AddAsync(role);
		}

		public async Task UpdateRoleAsync(Role role)
		{
			if (!ExecuteValidation(new RoleValidation(), role)) return;
			
			if (_roleRepository.FindAsync(r => r.Name == role.Name && r.Id != role.Id).Result.Any())
			{
				Notify("Já existe outro role cadastrado para este Nome!");
				return;
			}

			await _roleRepository.UpdateAsync(role);
		}

		public async Task DeleteRoleAsync(Guid id)
		{
			var existingRole = await _roleRepository.GetByIdAsync(id);
			if (existingRole != null)
			{
				Notify("Nenhum role encontrado com o id informado!");
				return;
			}

			await _roleRepository.RemoveAsync(id);
		}

		public void Dispose()
		{
			_roleRepository?.Dispose();
		}

	}
}
