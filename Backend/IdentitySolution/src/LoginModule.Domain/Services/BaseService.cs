using FluentValidation;
using FluentValidation.Results;
using LoginModule.Domain.Entities;
using LoginModule.Domain.Interfaces;
using LoginModule.Domain.Notifications;

namespace LoginModule.Domain.Services
{
	public abstract class BaseService
	{
		private readonly INotifier _notifier;

        protected BaseService(INotifier notifier)
        {
			_notifier = notifier;
        }

		protected void Notify(ValidationResult validationResult)
		{
			foreach (var item in validationResult.Errors)
			{
				Notify(item.ErrorMessage);
			}
		}

        protected void Notify(string menssage)
		{
			_notifier.Handle(new Notification(menssage));
		}

		protected bool ExecuteValidation<TValidacao, TEntidade>(TValidacao validacao, TEntidade entidade) 
			where TValidacao : AbstractValidator<TEntidade>
			where TEntidade : Entity
		{
			var validator = validacao.Validate(entidade);

			if (validator.IsValid) return true;

			Notify(validator);

			return false;
		}
	}
}
