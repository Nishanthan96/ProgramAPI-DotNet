using ProgramDatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramService
{
    public interface IEmployerService
    {
        Task<bool> AddQuestion(List<CustomQuestionTemplate> questions);
        Task<IEnumerable<CustomQuestionTemplate>> GetAllQuestions();
        Task<CustomQuestionTemplate> GetQuestionById(int id);
        Task<bool> UpdateQuestion(CustomQuestionTemplate question);
    }
}
