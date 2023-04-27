using ExamProgram.Domain.Commons;
using ExamProgram.Domain.Entities.Users;

namespace ExamProgram.Domain.Entities.Chats
{
    public class Chat : Auditable
    {
        public string ChatText { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
