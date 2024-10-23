using FluentValidation;

namespace LoginModule.Domain.Entities.Validations
{
	public class PermissionValidation : AbstractValidator<Permission>
	{
		public PermissionValidation()
		{
			RuleFor(c => c.Name)
				.NotEmpty().WithMessage("O nome da permissão é obrigatório.")
				.MinimumLength(3).WithMessage("O nome da permissão deve ter pelo menos 3 caracteres.");

			RuleFor(c => c.Description)
				.MaximumLength(250).WithMessage("A descrição pode ter no máximo 250 caracteres.");
		}
	}
}
