﻿using LoginModule.Domain.Entities;

namespace LoginModule.Domain.Interfaces
{
	public interface IUserRepository : IRepository<User>
	{
		Task<User> GetByUsernameAsync(string username);
		Task<User> GetByEmailAsync(string email);
	}
}
