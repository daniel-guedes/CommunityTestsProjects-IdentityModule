using LoginModule.Domain.Entities;

namespace LoginModule.Domain.Interfaces
{
	public interface IUserService : IDisposable
	{
		Task CreateUserAsync(User user);
		Task UpdateUserAsync(User user);
		Task DeleteUserAsync(Guid id);
	}
}
