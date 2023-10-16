using UserTestingApi.Models;
using UserTestingData.Models;

namespace UserTestingApi.Repositories;

public interface ITestRepository
{
	Task<List<Test>> GetAllUserTests();

	Task Update(int testId , List<UserAnswersModel> userAnswers);

}
