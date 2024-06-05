using System.Text.Json.Serialization;
using MaximTestCases.Controllers.Response;
using MaximTestCases.Task1;
using MaximTestCases.WordsBlackListLogic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MaximTestCases.Controllers;


[Route("api/task")]
public class TaskController : ControllerBase
{
    private readonly IWordsBlackListService wordsBlackListService;

    public TaskController(IWordsBlackListService wordsBlackListService)
    {
        this.wordsBlackListService = wordsBlackListService;
    }
    
    [HttpGet]
    [ProducesResponseType(200)]
    public IActionResult GetTaskAnswer([FromQuery] string inputString)
    {
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
    }
}