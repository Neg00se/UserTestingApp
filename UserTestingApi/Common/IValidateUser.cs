using UserTestingData.Models;

namespace UserTestingApi.Common
{
	public interface IValidateUser
	{
		bool IsUserValid(User user, string password);
	}
}