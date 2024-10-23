using LoginModule.Domain.Entities;
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
			await _roleRepository.AddAsync(role);
		}
		public async Task UpdateRoleAsync(Role role)
		{
			await _roleRepository.UpdateAsync(role);
		}

		public async Task DeleteRoleAsync(Guid id)
		{
			await _roleRepository.RemoveAsync(id);
		}

		public void Dispose()
		{
			_roleRepository.Dispose();
		}

	}
}
