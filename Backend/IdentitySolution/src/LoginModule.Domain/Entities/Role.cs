using System.Threading.Tasks;

namespace LoginModule.Domain.Entities
{
	public class Role : Entity
	{
		public string Name { get; set; }
		public string? Description { get; set; }
		public ICollection<Permission> Permissions { get; set; } = new List<Permission>();
	}
}
