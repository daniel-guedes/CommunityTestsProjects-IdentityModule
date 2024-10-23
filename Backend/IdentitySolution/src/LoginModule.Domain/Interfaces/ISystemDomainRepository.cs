using LoginModule.Domain.Entities;

namespace LoginModule.Domain.Interfaces
{
	public interface ISystemDomainRepository : IRepository<SystemDomain>
	{
		Task<SystemDomain> GetByDomainNameAsync(string domainName);
	}
}
