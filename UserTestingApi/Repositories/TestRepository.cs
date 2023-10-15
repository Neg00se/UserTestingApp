using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using UserTestingApi.Models;
using UserTestingData.DataAccess;
using UserTestingData.Models;

namespace UserTestingApi.Repositories;

public class TestRepository : ITestRepository
{
	private readonly TestingAppDbContext _context;
	private readonly IHttpContextAccessor _httpContextAccessor;

	public TestRepository(TestingAppDbContext context,
		IHttpContextAccessor httpContextAccessor)
	{
		_context = context;
		_httpContextAccessor = httpContextAccessor;
	}

	public async Task<List<Test>> GetAllUserTests()
	{
		var loggedInUserId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

		var tests = await _context.Tests.Where(test => test.UserId.ToString() == loggedInUserId)
			.Include(q => q.Questions)
			.ThenInclude(a => a.AnswerOptions)
			.ToListAsync();

		return tests;
	}

	public async Task Update(int testId, List<IUserAnswersModel> userAnswers)
	{
		var test = _context.Tests.Find(testId);
		test.Completed = true;
		test.Mark = 0;

		foreach (var question in test.Questions)
		{
			var answer = userAnswers.FirstOrDefault(answer => answer.QuestionId == question.Id);
			if (answer is not null && answer.UserAnswer == question.CorrectAnswer)
			{
				test.Mark++;
			}
		}

		await _context.SaveChangesAsync();
	}
}
