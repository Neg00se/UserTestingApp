using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UserTestingData.DataAccess;
using UserTestingData.Models;

namespace UserTestingApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UserController : ControllerBase
	{
		private readonly TestingAppDbContext _context;
		private readonly IPasswordHasher<User> _hasher;

		public UserController(TestingAppDbContext context, IPasswordHasher<User> hasher)
		{
			_context = context;
			_hasher = hasher;
		}


		[HttpPost]
		public async Task CreateUser(string userName, string password)
		{
			User user = new User() { UserName = userName, Role = "User" };
			user.PasswordHash = _hasher.HashPassword(user, password);

			await _context.Users.AddAsync(user);
			await _context.SaveChangesAsync();

		}

	}
}
