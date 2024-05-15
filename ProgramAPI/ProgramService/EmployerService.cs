using ProgramDatabase.Models;
using ProgramDatabase.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramService
{
    public class EmployerService:IEmployerService
    {
        private readonly IEmployerRepository _employerRepository;
        public EmployerService(IEmployerRepository employerRepository)
        {
            _employerRepository = employerRepository;
        }

        public async Task<bool> AddQuestion(List<CustomQuestionTemplate> questions)
        {
            return await _employerRepository.AddQuestion(questions);
        }
        public async Task<IEnumerable<CustomQuestionTemplate>> GetAllQuestions()
        {
            return await _employerRepository.GetAllQuestions();
        }

        public async Task<CustomQuestionTemplate> GetQuestionById(int id)
        {
            return await _employerRepository.GetQuestionById(id);
        }

        public async Task<bool> UpdateQuestion(CustomQuestionTemplate question)
        {
            return await _employerRepository.UpdateQuestion(question);
        }
    }
}
