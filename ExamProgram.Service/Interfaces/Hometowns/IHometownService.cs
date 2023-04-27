using ExamProgram.Domain.Configurations;
using ExamProgram.Domain.Entities.Hometowns;
using ExamProgram.Service.DTOs.HomeTowns;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ExamProgram.Service.Interfaces.Hometowns
{
    public interface IHometownService
    {
        Task<IEnumerable<HometownForViewDTO>> GetAllAsync(PaginationParams @params);
        Task<HometownForViewDTO> GetAsync(int id);
        Task<HometownForUpdateDTO> UpdateAsync(int id, HometownForUpdateDTO userForUpdate);
        Task<HometownForCreateDTO> CreateAsync(HometownForCreateDTO userForCreate);
        Task<bool> DeleteAsync(int id);
    }
}
