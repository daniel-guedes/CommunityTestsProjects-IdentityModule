using LoginModule.Domain.Entities;

namespace LoginModule.Domain.Interfaces
{
	public interface IPermissionRepository : IRepository<Permission>
	{
		Task<IEnumerable<Permission>> GetPermissionsByRoleAsync(Guid roleId);
	}
}
