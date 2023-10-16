using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UserTestingApi.Models;
using UserTestingApi.Repositories;
using UserTestingApi.Services;
using UserTestingData.DataAccess;
using UserTestingData.Models;

namespace UserTestingApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
	private readonly IAuthService _authService;

	public UserController(IUserRepository userRepo, IAuthService authService)
	{
		_authService = authService;
	}


	[HttpPost]
	[AllowAnonymous]
	[Route("Login")]
	public async Task<IActionResult> Login(UserCredentialsModel userCreds)
	{
		try
		{
			var token = await _authService.GenerateToken(userCreds.UserName, userCreds.Password);
			var output = new
			{
				accessToken = token
			};
			return Ok(output);
		}
		catch (Exception ex)
		{

			return BadRequest(ex.Message);
		}
	}


}
