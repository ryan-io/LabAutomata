using Microsoft.AspNetCore.Mvc;

namespace LabAutomata.WebApi.src.controllers {
    public class SsTempTestController : BaseController {
        [HttpPost("create")]
        public async Task<IActionResult> CreateMockDemoItem () {
            await Task.CompletedTask;
            return Ok();
        }


        public SsTempTestController () {

        }
    }
}
