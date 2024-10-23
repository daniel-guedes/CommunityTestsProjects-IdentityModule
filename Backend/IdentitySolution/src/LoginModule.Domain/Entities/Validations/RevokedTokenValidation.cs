using FluentValidation;

namespace LoginModule.Domain.Entities.Validations
{
	public class RevokedTokenValidation : AbstractValidator<RevokedToken>
	{
		public RevokedTokenValidation()
		{
			RuleFor(c => c.Token)
				.NotEmpty().WithMessage("O token a ser revogado é obrigatório.");

			RuleFor(c => c.RevokedAt)
				.NotEmpty().WithMessage("A data da revogação é obrigatória.");
		}
	}
}
