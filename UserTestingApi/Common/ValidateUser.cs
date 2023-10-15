using Microsoft.AspNetCore.Identity;
using UserTestingData.Models;

namespace UserTestingApi.Common;

public class ValidateUser : IValidateUser
{
	private readonly IPasswordHasher<User> _hasher;

	public ValidateUser(IPasswordHasher<User> hasher)
	{
		_hasher = hasher;
	}

	public bool IsUserValid(User user, string password)
	{
		var result = _hasher.VerifyHashedPassword(user, user.PasswordHash, password);

		if (result == PasswordVerificationResult.Success)
		{
			return true;
		}

		return false;
	}

}
