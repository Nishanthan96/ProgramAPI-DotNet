using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramDatabase.Models
{
    public class CustomQuestionTemplate
    {
        public Guid? Id { get; set; } 
        public string QuestionTypeId { get; set; }        
        public string Question { get; set; }    
        public List<string>? Options { get; set; } 
    }
}
