namespace LoginModule.Domain.Entities
{
	//Tentativa de Login
	public class LoginAttempt : Entity
	{
		public Guid? UserId { get; set; } 
		public User? User { get; set; }  
		public string IpAddress { get; set; } = default!;  
		public bool Success { get; set; }
		public DateTime Timestamp { get; set; }
	}
}
