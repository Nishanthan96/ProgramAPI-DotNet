using ProgramDatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramDatabase.Repository
{
    public interface IEmployerRepository
    {
        Task<bool> AddQuestion(List<CustomQuestionTemplate> question);
        Task<IEnumerable<CustomQuestionTemplate>> GetAllQuestions();
        Task<CustomQuestionTemplate> GetQuestionById(int id);
        Task<bool> UpdateQuestion(CustomQuestionTemplate question);
    }
}
