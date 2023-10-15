using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using UserTestingApi.Repositories;
using UserTestingData.DataAccess;
using UserTestingData.Models;

namespace UserTestingApi.Repositories;

public class UserRepository : IUserRepository
{
	private readonly TestingAppDbContext _context;
	public UserRepository(TestingAppDbContext context )
	{
		_context = context;
		
	}


	public async Task<User> GetUserAsync(string username)
	{
		var user = await _context.Users.FirstOrDefaultAsync(u => u.UserName == username);
		if (user is not null)
		{
			return user;
		}

		throw new Exception("User dont exist");
	}
}
