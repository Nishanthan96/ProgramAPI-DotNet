using ProgramDatabase.Models;
using ProgramDatabase.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramService
{
    public class CandidateService:ICandidateService
    {
        private readonly ICandidateRepository _candidateRepsoitory;
        public CandidateService(ICandidateRepository candidateRepository)
        {
                _candidateRepsoitory = candidateRepository; 
        }

        public async Task<bool> AddProgram(Application application)
        {
            return await _candidateRepsoitory.AddProgram(application);
        }
    }
}
