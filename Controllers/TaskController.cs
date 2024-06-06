using MaximTestCases.RequestsLimitLogic.Interfaces;
using MaximTestCases.Task1;
using MaximTestCases.WordsBlackListLogic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MaximTestCases.Controllers;


[Route("api/task")]
public class TaskController : ControllerBase
{
    private readonly IWordsBlackListService wordsBlackListService;
    private readonly IRequestsLimitService requestsLimitService;

    public TaskController(IWordsBlackListService wordsBlackListService, IRequestsLimitService requestsLimitService)
    {
        this.wordsBlackListService = wordsBlackListService;
        this.requestsLimitService = requestsLimitService;
    }
    
    [HttpGet]
    [ProducesResponseType(200)]
    public async Task<IActionResult> GetTaskAnswerAsync([FromQuery] string inputString)
    {
        if (await requestsLimitService.IsLimit())
            return StatusCode(503, "Requests limit");
        
        try
        {
            if (wordsBlackListService.IsWordInList(inputString))
                throw new Exception("Слово в черном списке!!!");

            var taskAnswerResponse = TaskSolution.GetTaskAnswerResponse(inputString);

            return Ok(JsonConvert.SerializeObject(taskAnswerResponse));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
        finally
        {
            requestsLimitService.Exit();
        }
    }
}