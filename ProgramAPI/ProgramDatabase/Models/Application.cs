using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramDatabase.Models
{
    public class Application
    {
        [Key]
        public Guid? Id { get; set; }   
        public string ProgramTitle { get; set; }
        public string ProgramDescription { get; set; }
        public PersonalInformation PersonalInformation { get; set; }
        public List<CustomQuestion> CustomQuestion { get; set; }
    }
}
