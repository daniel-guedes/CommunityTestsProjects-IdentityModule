using LoginModule.Domain.Entities;

namespace LoginModule.Domain.Interfaces
{
	public interface IRevokedTokenRepository : IRepository<RevokedToken>
	{
		Task<bool> IsTokenRevokedAsync(string token);
	}
}
