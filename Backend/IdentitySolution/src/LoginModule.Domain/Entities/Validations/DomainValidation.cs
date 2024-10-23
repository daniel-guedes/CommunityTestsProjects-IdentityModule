using FluentValidation;

namespace LoginModule.Domain.Entities.Validations
{
	public class DomainValidation : AbstractValidator<Domain>
	{
		public DomainValidation()
		{
			RuleFor(c => c.DomainName)
				.NotEmpty().WithMessage("O nome do domínio é obrigatório.")
				.Length(3,100).WithMessage("O nome do domínio deve ter entre 3 e 100 caracteres.")
				.Matches(@"^[a-zA-Z0-9\-\.]+\.[a-zA-Z]{2,}$").WithMessage("O nome do domínio é inválido.");

			RuleFor(d => d.ClientId)
				.NotEmpty().WithMessage("O ID do cliente é obrigatório.")
				.NotEqual(Guid.Empty).WithMessage("O ID do cliente não pode ser um GUID vazio.");

			RuleFor(c => c.DatabaseConnectionString)
				.NotEmpty().WithMessage("A string de conexão com o banco de dados é obrigatória.")
				.MaximumLength(500).WithMessage("A string de conexão não pode ter mais de 500 caracteres.")
				.When(d => !string.IsNullOrEmpty(d.DatabaseConnectionString));
		}
	}
}
