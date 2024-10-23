using LoginModule.Domain.Entities;
using LoginModule.Domain.Interfaces;
using System.Security;

namespace LoginModule.Domain.Services
{
	public class PermissionService : BaseService, IPermissionService
	{
		private readonly IPermissionRepository _permissionRepository;

		public PermissionService(IPermissionRepository permissionRepository)
		{
			_permissionRepository = permissionRepository;
		}

		public async Task CreatePermissionAsync(Permission permission)
		{
			await _permissionRepository.AddAsync(permission);
		}
		public async Task UpdatePermissionAsync(Permission permission)
		{
			await _permissionRepository.UpdateAsync(permission);
		}

		public async Task DeletePermissionAsync(Guid id)
		{
			await _permissionRepository.RemoveAsync(id);
		}

		public void Dispose()
		{
			_permissionRepository.Dispose();
		}

	}
}
