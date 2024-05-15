using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProgramDatabase.Models;
using ProgramService;

namespace ProgramAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateController : ControllerBase
    {
        private readonly ICandidateService _candidateService;
        public CandidateController(ICandidateService candidateService)
        {
            _candidateService = candidateService;   
        }

        [HttpPost]
        public async Task<IActionResult> SubmitApplication(Application application)
        {
            bool result = await _candidateService.AddProgram(application);
            if (result) {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
