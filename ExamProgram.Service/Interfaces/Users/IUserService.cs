using ExamProgram.Domain.Configurations;
using ExamProgram.Domain.Entities.Users;
using ExamProgram.Service.DTOs.Users;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;


namespace ExamProgram.Service.Interfaces.Users
{
    public interface IUserService
    {
        Task<IEnumerable<UserForViewDTO>> GetAllAsync(PaginationParams @params);
        Task<UserForViewDTO> GetAsync(int id);
        Task<UserForUpdateDTO> UpdateAsync(int id, UserForUpdateDTO userForUpdate);
        Task<UserForCreateDTO> CreateAsync(UserForCreateDTO userForCreate);
        Task<bool> DeleteAsync(int id);
        
    }
}
