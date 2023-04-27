using ExamProgram.Domain.Commons;
using ExamProgram.Domain.Entities.Users;
using System.Collections.Generic;

namespace ExamProgram.Domain.Entities.Hometowns
{
    public class Hometown : Auditable
    {
        public string Name { get; set; }   
        public virtual ICollection<User> Users { get; set; }
    }
}
