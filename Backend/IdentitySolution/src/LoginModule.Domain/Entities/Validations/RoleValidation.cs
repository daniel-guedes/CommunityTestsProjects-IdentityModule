using FluentValidation;

namespace LoginModule.Domain.Entities.Validations
{
	public class RoleValidation : AbstractValidator<Role>
	{
		public RoleValidation()
		{
			RuleFor(c => c.Name)
				.NotEmpty().WithMessage("O nome do papel é obrigatório.")
				.MinimumLength(3).WithMessage("O nome do papel deve ter pelo menos 3 caracteres.");

			RuleFor(c => c.Description)
				.MaximumLength(250).WithMessage("A descrição pode ter no máximo 250 caracteres.");
		}
	}
}
