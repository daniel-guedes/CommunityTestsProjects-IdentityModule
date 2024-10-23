using LoginModule.Domain.Entities;

namespace LoginModule.Domain.Interfaces
{
	public interface IRoleRepository : IRepository<Role>
	{
		Task<IEnumerable<Role>> GetRolesByUserAsync(Guid userId);
	}
}
