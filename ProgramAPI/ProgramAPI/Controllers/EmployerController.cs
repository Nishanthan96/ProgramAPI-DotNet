using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProgramDatabase.Enums;
using ProgramDatabase.Models;
using ProgramService;

namespace ProgramAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployerController : ControllerBase
    {
        private readonly IEmployerService _employerService;
        public EmployerController(IEmployerService employerService)
        {
            _employerService = employerService;
        }

        [HttpGet("QuestionTypes")]
        public IActionResult GetQuestionTypes()
        {
            var questionTypes = Enum.GetValues(typeof(QuestionTypes))
                                    .Cast<QuestionTypes>()
                                    .Select(e => new { Value = (int)e, Name = e.ToString() })
                                    .ToList();
            return Ok(questionTypes);
        }

        [HttpPost("CreateQuestion")]
        public async Task<IActionResult> CreateQuestion(List<CustomQuestionTemplate> questions)
        {
            bool result = await _employerService.AddQuestion(questions);
            if (result)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet("GetAllQuestions")]
        public async Task<IActionResult> GetAllQuestions()
        {
            var questions = await _employerService.GetAllQuestions();
            return Ok(questions);
        }

        [HttpGet("GetQuestionByTypeId/{id}")]
        public async Task<IActionResult> GetQuestionByTypeId(int id)
        {
            var question = await _employerService.GetQuestionById(id);
            if (question == null)
                return NotFound();

            return Ok(question);
        }

        [HttpPut("UpdateQuestion/{id}")]
        public async Task<IActionResult> UpdateQuestion(int id, CustomQuestionTemplate question)
        {
            if (id.ToString() != question.QuestionTypeId)
                return BadRequest("ID mismatch");

            var result = await _employerService.UpdateQuestion(question);
            if (result == null)
                return BadRequest();

            return Ok(question);
        }
    }
}
