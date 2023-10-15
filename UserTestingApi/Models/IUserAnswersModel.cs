using UserTestingData.Models;

namespace UserTestingApi.Models
{
	public interface IUserAnswersModel
	{
		int QuestionId { get; set; }
		Answer? UserAnswer { get; set; }
	}
}