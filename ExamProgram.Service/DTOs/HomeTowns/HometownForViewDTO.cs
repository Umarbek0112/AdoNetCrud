using ExamProgram.Domain.Entities.Users;
using System.Collections.Generic;
namespace ExamProgram.Service.DTOs.HomeTowns
{
    public class HometownForViewDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
