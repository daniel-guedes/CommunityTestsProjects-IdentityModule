//Revogação de Token: Segurança para garantir que um token revogado não seja aceito em requisições subsequentes.
namespace LoginModule.Domain.Entities
{
	public class RevokedToken : Entity
	{
		public string Token { get; set; } = default!;
		public DateTime RevokedAt { get; set; }
	}
}
