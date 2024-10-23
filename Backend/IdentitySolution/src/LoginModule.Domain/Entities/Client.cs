namespace LoginModule.Domain.Entities
{
	public class Client : Entity
	{
		public string Name { get; set; } = default!;  
		public string? ApiKey { get; set; }  
	}
}
