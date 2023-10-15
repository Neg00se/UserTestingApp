using UserTestingData.Models;

namespace UserTestingApi.Repositories;

public interface IUserRepository
{
	Task<User> GetUserAsync(string userName);

}
