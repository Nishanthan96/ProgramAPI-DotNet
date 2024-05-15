using Microsoft.EntityFrameworkCore;
using ProgramDatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramDatabase.Repository
{
    public class EmployerRepository:IEmployerRepository
    {
        private readonly ProgramDbContext _dbContext;
        public EmployerRepository(ProgramDbContext dbContext)
        {
            _dbContext = dbContext; 
        }
        public async Task<bool> AddQuestion(List<CustomQuestionTemplate> question)
        {
            try
            {
                _dbContext.CustomQuestions.AddRange(question);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public async Task<IEnumerable<CustomQuestionTemplate>> GetAllQuestions()
        {
            return await _dbContext.CustomQuestions.ToListAsync();
        }

        public async Task<CustomQuestionTemplate> GetQuestionById(int id)
        {
            return await _dbContext.CustomQuestions.FirstOrDefaultAsync(q => q.QuestionTypeId == id.ToString());
        }

        public async Task<bool> UpdateQuestion(CustomQuestionTemplate question)
        {
            try
            {
                _dbContext.Entry(question).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
