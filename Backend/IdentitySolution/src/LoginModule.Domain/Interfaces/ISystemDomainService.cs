using LoginModule.Domain.Entities;

namespace LoginModule.Domain.Interfaces
{
	public interface ISystemDomainService : IDisposable
	{
		Task CreateDomainAsync(SystemDomain domain);
		Task UpdateDomainAsync(SystemDomain domain);
		Task DeleteDomainAsync(Guid id);
	}
}
