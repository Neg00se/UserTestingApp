using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserTestingApi.Models;
using UserTestingApi.Repositories;
using UserTestingData.Models;

namespace UserTestingApi.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class TestController : ControllerBase
{
	private readonly ITestRepository _testRepo;

	public TestController(ITestRepository testRepo)
	{
		_testRepo = testRepo;
	}



	[HttpPost]
	public async Task<IActionResult> PassTest(int testId, List<IUserAnswersModel> userAnswers)
	{
		try
		{
			await _testRepo.Update(testId, userAnswers);
			return Ok();
		}
		catch (Exception ex)
		{

			return BadRequest(ex.Message);
		}
	}

	[HttpGet]
	public async Task<IActionResult> GetAllTests()
	{
		try
		{
			var userTests = await _testRepo.GetAllUserTests();
			return Ok(userTests);
		}
		catch (Exception ex)
		{

			return BadRequest(ex.Message);
		}
	}
}
