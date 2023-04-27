using ExamProgram.Domain.Entities.Chats;
using ExamProgram.Domain.Entities.Hometowns;
using System.Collections.Generic;

namespace ExamProgram.Service.DTOs.Users
{
    public class UserForViewDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string UserName { get; set; }
        public int HometownId { get; set; }
        public Hometown Hometown { get; set; }
        public virtual ICollection<Chat> Chats { get; set; }
    }
}
