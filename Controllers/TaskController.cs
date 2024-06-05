using System.Text.Json.Serialization;
using MaximTestCases.Controllers.Response;
using MaximTestCases.Task1;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MaximTestCases.Controllers;


[Route("api/task")]
public class TaskController : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(200)]
    public IActionResult GetTaskAnswer([FromQuery] string inputString)
    {
        try
        {
            var taskAnswerResponse = TaskSolution.GetTaskAnswerResponse(inputString);

            return Ok(JsonConvert.SerializeObject(taskAnswerResponse));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}