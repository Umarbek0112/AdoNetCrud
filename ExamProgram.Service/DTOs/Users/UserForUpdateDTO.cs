
namespace ExamProgram.Service.DTOs.Users
{
    public class UserForUpdateDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string UserName { get; set; }
        public int HometownId { get; set; }
    }
}
