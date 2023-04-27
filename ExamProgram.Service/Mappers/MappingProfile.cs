using AutoMapper;
using ExamProgram.Domain.Entities.Chats;
using ExamProgram.Domain.Entities.Hometowns;
using ExamProgram.Domain.Entities.Users;
using ExamProgram.Service.DTOs.Chats;
using ExamProgram.Service.DTOs.HomeTowns;
using ExamProgram.Service.DTOs.Users;

namespace ExamProgram.Service.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            // user mapper
            CreateMap<User, UserForCreateDTO>().ReverseMap();
            CreateMap<User, UserForUpdateDTO>().ReverseMap();
            CreateMap<User, UserForViewDTO>().ReverseMap();

            // Chat mappers
            CreateMap<Chat, ChatForCreateDTO>().ReverseMap();
            CreateMap<Chat, ChatForUpdateDTO>().ReverseMap();
            CreateMap<Chat, ChatForViewDTO>().ReverseMap();

            // Hometowns mappers
            CreateMap<Hometown, HometownForCreateDTO>().ReverseMap();
            CreateMap<Hometown, HometownForUpdateDTO>().ReverseMap();
            CreateMap<Hometown, HometownForViewDTO>().ReverseMap();
        }
    }
}
