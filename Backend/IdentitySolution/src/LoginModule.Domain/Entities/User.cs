using System.Data;
using System.Security.Claims;

namespace LoginModule.Domain.Entities
{
	public class User : Entity
	{
		public string UserName { get; set; }
		public string? Email { get; set; }
		public string PasswordHash { get; set; }
		public bool IsActive { get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime? LastLogin { get; set; }
		public ICollection<Role>? Roles { get; set; } = new List<Role>();
		public ICollection<Claim>? Claims { get; set; } = new List<Claim>();
	}
}
