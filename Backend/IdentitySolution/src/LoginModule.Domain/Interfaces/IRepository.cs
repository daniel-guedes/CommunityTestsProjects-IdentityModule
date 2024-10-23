using LoginModule.Domain.Entities;
using System.Linq.Expressions;

namespace LoginModule.Domain.Interfaces
{
	//Repositório é a abstração das ações de persistencia dentro de um banco, logo, repositório ou interface de persistencia
	//Recebe uma entidade genérica para usar esses dados para persistir no banco por ela, ao invés da persistencia
	public interface IRepository<TEntity> : IDisposable where TEntity : Entity
	{
		Task<TEntity> GetByIdAsync(Guid id);
		Task<List<TEntity>> GetAllAsync();
		Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate);

		Task AddAsync(TEntity entity);
		Task UpdateAsync(TEntity entity);
		Task RemoveAsync(Guid id);

		Task<int> SaveChangesAsync();
	}
}
