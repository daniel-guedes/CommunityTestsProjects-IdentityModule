namespace LoginModule.Domain.Entities
{
	public class SystemDomain : Entity
	{
		public string DomainName { get; set; } = default!;
        public Guid ClientId { get; set; }
		public Client Client { get; set; }
		public string? DatabaseConnectionString { get; set; }  
	}
}
