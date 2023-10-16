namespace UserTestingApi.Models;

public class UserCredentialsModel : IUserCredentialsModel
{
	public string UserName { get; set; }
	public string Password { get; set; }
}
