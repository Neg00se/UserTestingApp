using System.ComponentModel.DataAnnotations;
using UserTestingData.Models;

namespace UserTestingApi.Models
{
	public class UserAnswersModel : IUserAnswersModel
	{
		[Required]
		public int QuestionId { get; set; }
		public Answer? UserAnswer { get; set; }
	}
}
