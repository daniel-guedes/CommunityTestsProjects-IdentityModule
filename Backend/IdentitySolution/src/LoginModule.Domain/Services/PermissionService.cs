using LoginModule.Domain.Entities;
using LoginModule.Domain.Entities.Validations;
using LoginModule.Domain.Interfaces;

namespace LoginModule.Domain.Services
{
	public class PermissionService : BaseService, IPermissionService
	{
		private readonly IPermissionRepository _permissionRepository;

		public PermissionService(IPermissionRepository permissionRepository,
								INotifier notifier) : base(notifier)
		{
			_permissionRepository = permissionRepository;
		}

		public async Task CreatePermissionAsync(Permission permission)
		{
			if (!ExecuteValidation(new PermissionValidation(), permission)) return;

			if (_permissionRepository.FindAsync(p => p.Name == permission.Name).Result.Any())
			{
				Notify("Já existe permissão cadastrada com esse nome!");
				return;
			}

			await _permissionRepository.AddAsync(permission);
		}

		public async Task UpdatePermissionAsync(Permission permission)
		{
			if (!ExecuteValidation(new PermissionValidation(), permission)) return;

			if (_permissionRepository.FindAsync(p => p.Name == permission.Name && p.Id != permission.Id).Result.Any())
			{
				Notify("Já existe permissão cadastrada com esse nome.");
				return;
			}

			await _permissionRepository.UpdateAsync(permission);
		}

		public async Task DeletePermissionAsync(Guid id)
		{
			var existingPermission = await _permissionRepository.GetByIdAsync(id);
			if (existingPermission != null)
			{
				Notify("Nenhuma permissão encontrada com o id informado!");
				return;
			}

			await _permissionRepository.RemoveAsync(id);
		}

		public void Dispose()
		{
			_permissionRepository?.Dispose();
		}

	}
}
