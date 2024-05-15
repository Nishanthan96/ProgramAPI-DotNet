using ProgramDatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramDatabase.Repository
{
    public class CandidateRepository:ICandidateRepository
    {
        private readonly ProgramDbContext _programDbContext;
        public CandidateRepository(ProgramDbContext programDbContext)
        {
            _programDbContext = programDbContext;   
        }

        public async Task<bool> AddProgram(Application application)
        {
            try
            {
                _programDbContext.ApplicationTemplate.Add(application);
                await _programDbContext.SaveChangesAsync();
                return true;    
            }
            catch (Exception ex) { 
                return false;   
            }    
        }
    }
}
