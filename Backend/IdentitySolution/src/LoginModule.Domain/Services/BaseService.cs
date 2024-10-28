using FluentValidation;
using LoginModule.Domain.Entities;

namespace LoginModule.Domain.Services
{
	public abstract class BaseService
	{
		protected void Notify(string mensagem)
		{ 
		}

		protected bool ExecuteValidation<TValidacao, TEntidade>(TValidacao validacao, TEntidade entidade) 
			where TValidacao : AbstractValidator<TEntidade>
			where TEntidade : Entity
		{
			var validator = validacao.Validate(entidade);

			if (validator.IsValid) return true;

			//Lançamento de notificações

			return false;
		}
	}
}
