namespace UserTestingApi.Services
{
	public interface IAuthService
	{
		Task<string> GenerateToken(string username, string password);
	}
}