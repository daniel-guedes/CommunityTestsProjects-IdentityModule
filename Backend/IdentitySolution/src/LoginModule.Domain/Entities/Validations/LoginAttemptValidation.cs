using FluentValidation;

namespace LoginModule.Domain.Entities.Validations
{
	public class LoginAttemptValidation : AbstractValidator<LoginAttempt>
	{
		public LoginAttemptValidation()
		{
			RuleFor(c => c.IpAddress)
				.NotEmpty().WithMessage("O endereço IP é obrigatório.")
				.Matches(@"^\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}$")
				.WithMessage("O endereço IP deve estar em formato válido.");

			RuleFor(c => c.Timestamp)
				.NotEmpty().WithMessage("A data e hora da tentativa de login são obrigatórias.");

			RuleFor(c => c.Success)
				.NotNull().WithMessage("O status de sucesso ou falha da tentativa de login é obrigatório.");
		}
	}
}
