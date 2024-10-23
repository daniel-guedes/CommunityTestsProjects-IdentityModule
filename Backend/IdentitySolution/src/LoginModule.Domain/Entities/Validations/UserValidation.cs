using FluentValidation;

namespace LoginModule.Domain.Entities.Validations
{
	public class UserValidation : AbstractValidator<User>
	{
		public UserValidation()
		{
			RuleFor(c => c.UserName)
				.NotEmpty().WithMessage("O nome de usuário é obrigatório.")
				.MinimumLength(3).WithMessage("O nome de usuário deve ter pelo menos 3 caracteres.");

			RuleFor(c => c.Email)
				.EmailAddress().When(u => !string.IsNullOrEmpty(u.Email))
				.WithMessage("O email fornecido é inválido.");

			RuleFor(c => c.PasswordHash)
				.NotEmpty().WithMessage("A senha é obrigatória.");

			RuleFor(c => c.IsActive)
				.NotNull().WithMessage("O status de ativação é obrigatório.");

			RuleFor(c => c.CreatedAt)
				.NotEmpty().WithMessage("A data de criação é obrigatória.");
		}
	}
}
