using LoginModule.Domain.Entities;

namespace LoginModule.Domain.Interfaces
{
	public interface IRoleService : IDisposable
	{
		Task CreateRoleAsync(Role role);
		Task UpdateRoleAsync(Role role);
		Task DeleteRoleAsync(Guid id);
	}
}
