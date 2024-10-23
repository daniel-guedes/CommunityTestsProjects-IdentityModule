using FluentValidation;

namespace LoginModule.Domain.Entities.Validations
{
	public class ClientValidation : AbstractValidator<Client>
	{
		public ClientValidation()
		{
			RuleFor(c => c.Name)
				.NotEmpty().WithMessage("O nome do cliente é obrigatório.");

			RuleFor(c => c.ApiKey)
				.MaximumLength(100).WithMessage("A chave de API pode ter no máximo 100 caracteres.")
				.When(c => !string.IsNullOrEmpty(c.ApiKey));
		}
	}
}
