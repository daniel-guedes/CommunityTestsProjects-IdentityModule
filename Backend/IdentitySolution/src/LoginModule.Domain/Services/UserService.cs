using LoginModule.Domain.Entities;
using LoginModule.Domain.Entities.Validations;
using LoginModule.Domain.Interfaces;

namespace LoginModule.Domain.Services
{
	public class UserService : BaseService, IUserService
	{
		private readonly IUserRepository _userRepository;
		public UserService(IUserRepository userRepository)
		{
			_userRepository = userRepository;
		}
		public async Task CreateUserAsync(User user)
		{
			// Validação dos dados do usuário
			if (!ExecuteValidation(new UserValidation(), user)) return;

			//Verificar se o email já existe
			if (_userRepository.FindAsync(u => u.Email == user.Email).Result.Any())
			{
				Notify("Já existe usuário cadastrado com esse mesmo e-mail!");
				return;
			}

			await _userRepository.AddAsync(user);
			//await _userRepository.SaveChanges();
		}

		public async Task UpdateUserAsync(User user)
		{
			// Validação dos dados do usuário
			if (!ExecuteValidation(new UserValidation(), user)) return;

			//Verificação de e-mail com id diferente, evitar alterações de e-mail forçada
			if (_userRepository.FindAsync(u => u.Email == user.Email && u.Id != user.Id).Result.Any())
			{
				Notify("Já existe outro usuário cadastrado para este e-mail!");
				return;
			}

			await _userRepository.UpdateAsync(user);
		}

		public async Task DeleteUserAsync(Guid id)
		{
			var user = await _userRepository.GetByIdAsync(id);
			if (user == null)
			{
				Notify("Usuário não encontrado.");
				return;
			}

			await _userRepository.RemoveAsync(id);
		}

		public void Dispose()
		{
			_userRepository?.Dispose();
		}

	}
}
