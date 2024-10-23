using LoginModule.Domain.Entities;

namespace LoginModule.Domain.Interfaces
{
	public interface ILoginAttemptRepository : IRepository<LoginAttempt>
	{
		Task<IEnumerable<LoginAttempt>> GetLoginAttemptsByUserAsync(Guid userId, int take = 10);
	}
}
