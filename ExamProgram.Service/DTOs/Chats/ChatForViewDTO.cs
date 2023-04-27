using ExamProgram.Domain.Entities.Users;

namespace ExamProgram.Service.DTOs.Chats
{
    public class ChatForViewDTO
    {
        public int Id { get; set; }
        public string ChatText { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
