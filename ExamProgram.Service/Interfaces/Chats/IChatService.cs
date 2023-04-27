using ExamProgram.Domain.Configurations;
using ExamProgram.Domain.Entities.Chats;
using ExamProgram.Service.DTOs.Chats;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ExamProgram.Service.Interfaces.Chats
{
    public interface IChatService
    {
        Task<IEnumerable<ChatForViewDTO>> GetAllAsync(PaginationParams @params);
        Task<ChatForViewDTO> GetAsync(int id);
        Task<ChatForUpdateDTO> UpdateAsync(int id, ChatForUpdateDTO userForUpdate);
        Task<ChatForCreateDTO> CreateAsync(ChatForCreateDTO userForCreate);
        Task<bool> DeleteAsync(int id);
    }
}
