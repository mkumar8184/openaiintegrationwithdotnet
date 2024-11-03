using Microsoft.AspNetCore.Mvc;

namespace OpenAIIntegration.WebApi
{

    [Route("api/v1/openai")]
    public class OpenAIApiController : ControllerBase
    {
       


        
        private readonly IOpenAIService _openAIService;

        public OpenAIApiController(IOpenAIService openAIService
            
            )
        {          
            _openAIService = openAIService;
        }
        [HttpGet]
        public IActionResult GetStatus()
        {
            return Ok("api connected successfully");
        }
        [HttpGet]
        [Route("TriggerOpenAI")]
        public async Task<IActionResult> TriggerOpenAI([FromQuery] string input)
        {
            var response = await _openAIService.TriggerOpenAI(input);
            return Ok(response);
        }
        [HttpGet]
        [Route("employee-report")]
        public async Task<IActionResult> GetEmployeeData([FromQuery] string input)
        {
            var response = await _openAIService.GetEmployeeReports(input);
            return Ok(response);
        }

    }



}
