namespace UserTestingApi.Models
{
	public interface IUserCredentialsModel
	{
		string Password { get; set; }
		string UserName { get; set; }
	}
}