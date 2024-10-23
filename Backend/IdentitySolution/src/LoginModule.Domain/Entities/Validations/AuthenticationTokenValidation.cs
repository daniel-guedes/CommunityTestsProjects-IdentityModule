using FluentValidation;

namespace LoginModule.Domain.Entities.Validations
{
	public class AuthenticationTokenValidation : AbstractValidator<AuthenticationToken>
	{
		public AuthenticationTokenValidation()
		{
			RuleFor(c => c.Token)
				.NotEmpty().WithMessage("O token de autenticação é obrigatório.");

			RuleFor(c => c.ExpiresAt)
				.GreaterThan(at => at.IssuedAt).WithMessage("A data de expiração deve ser posterior à data de emissão.");

			RuleFor(c => c.UserId)
				.NotEmpty().WithMessage("O ID do usuário associado ao token é obrigatório.");
		}
	}
}
