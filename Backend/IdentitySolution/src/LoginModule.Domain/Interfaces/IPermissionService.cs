using LoginModule.Domain.Entities;

namespace LoginModule.Domain.Interfaces
{
	public interface IPermissionService : IDisposable
	{
		Task CreatePermissionAsync(Permission permission);
		Task UpdatePermissionAsync(Permission permission);
		Task DeletePermissionAsync(Guid id);
	}
}
