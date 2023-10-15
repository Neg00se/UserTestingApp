using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UserTestingApi.Common;
using UserTestingApi.Repositories;

namespace UserTestingApi.Services;

public class AuthService : IAuthService
{
	private readonly IUserRepository _userRepo;
	private readonly IValidateUser _validUser;
	private readonly IConfiguration _config;

	public AuthService(IUserRepository userRepo,
		IValidateUser validUser,
		IConfiguration config)
	{
		_userRepo = userRepo;
		_validUser = validUser;
		_config = config;
	}


	public async Task<string> GenerateToken(string username, string password)
	{
		var user = await _userRepo.GetUserAsync(username);

		if (_validUser.IsUserValid(user, password))
		{
			var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));

			var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

			var claims = new List<Claim>
			{
				new Claim(ClaimTypes.NameIdentifier , user.Id.ToString()),
				new Claim(ClaimTypes.GivenName , user.UserName) ,
				new Claim(ClaimTypes.Role , user.Role)
			};

			var token = new JwtSecurityToken(_config["Jwt:Issuer"],
				_config["Jwt:Audience"],
				claims: claims,
				expires: DateTime.Now.AddHours(2),
				signingCredentials: credentials
				);

			return new JwtSecurityTokenHandler().WriteToken(token);
		}

		throw new Exception("invalid password");

	}


}
