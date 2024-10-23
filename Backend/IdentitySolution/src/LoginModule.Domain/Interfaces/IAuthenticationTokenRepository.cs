using LoginModule.Domain.Entities;

namespace LoginModule.Domain.Interfaces
{
	public interface IAuthenticationTokenRepository : IRepository<AuthenticationToken>
	{
		Task<AuthenticationToken> GetByTokenAsync(string token);
		Task<IEnumerable<AuthenticationToken>> GetActiveTokensByUserIdAsync(Guid userId);
	}
}
