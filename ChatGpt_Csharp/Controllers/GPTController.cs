using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpenAI_API;
using OpenAI_API.Completions;

namespace ChatGpt_Csharp.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class GPTController : ControllerBase
    {
        [HttpGet]
        [Route("UseChatGPT")]
        public async Task<IActionResult> UseChatGPT(string query)
        {
            string OutPutResult = "";
            var openai = new OpenAIAPI("");
            CompletionRequest completionRequest = new CompletionRequest();
            completionRequest.Prompt = query;
            completionRequest.Model = OpenAI_API.Models.Model.DavinciText;

            var completions = openai.Completions.CreateCompletionAsync(completionRequest);

            foreach (var completion in completions.Result.Completions)
            {
                OutPutResult += completion.Text;
            }

            return Ok(OutPutResult);    
        }
    }
}
