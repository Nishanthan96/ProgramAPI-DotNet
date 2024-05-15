using ProgramDatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramDatabase.Repository
{
    public interface ICandidateRepository
    {
        Task<bool> AddProgram(Application application);
    }
}
