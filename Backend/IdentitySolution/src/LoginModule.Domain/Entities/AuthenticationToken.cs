namespace LoginModule.Domain.Entities
{
	public class AuthenticationToken : Entity
	{
		public string Token { get; set; } = default!;
		public DateTime ExpiresAt { get; set; }
		public DateTime IssuedAt { get; set; }
		public Guid UserId { get; set; }
		public User? User { get; set; }
		public string? SystemCode { get; set; }
	}
}
