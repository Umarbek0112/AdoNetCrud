using AutoMapper;
using ExamProgram.Data.IRepository;
using ExamProgram.Data.Repository;
using ExamProgram.Domain.Configurations;
using ExamProgram.Domain.Entities.Hometowns;
using ExamProgram.Service.DTOs.Users;
using ExamProgram.Service.Exceptionst;
using ExamProgram.Service.Extensions;
using ExamProgram.Service.Interfaces.Users;
using ExamProgram.Service.Mappers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExamProgram.Service.Services.Users
{
    public class UserService : IUserService
    {
        private readonly IGenericRepositoriy _repository;
        private readonly IMapper _mapper;
        public UserService() 
        {
            _repository = new GenericRepository();
            _mapper = new MapperConfiguration(cfg =>
                cfg.AddProfile<MappingProfile>())
                .CreateMapper();
        }

        public async Task<UserForViewDTO> GetAsync(int id)
        {
            UserForViewDTO user = new UserForViewDTO();

            var reader = await _repository.GetAsync($"Select * from Users inner join Hometown on Users.HometownId = Hometown.id Where Users.id = {id};");

            while (reader.Read())
            {
                user = new UserForViewDTO
                {
                    Id = reader.GetInt32(8),
                    FirstName = reader.GetString(0),
                    Email = reader.GetString(1),
                    LastName = reader.GetString(2),
                    PhoneNumber = reader.GetString(3),
                    UserName = reader.GetString(4),
                    Password = reader.GetString(7),
                    HometownId = reader.GetInt32(9),
                    Hometown = new Hometown
                    {
                        Name = reader.GetString(10),
                        Id = reader.GetInt32(13),
                    }
                };             
            }
           await _repository.CloseAsync();

            if (!reader.HasRows)
                throw new ExamProgramException("Student notfound");
            
            return user;
        }

        public async Task<IEnumerable<UserForViewDTO>> GetAllAsync(PaginationParams @params)
        {
            List<UserForViewDTO> users = new List<UserForViewDTO>();

            var reader = await _repository.GetAllAsync($"Select * from Users inner join Hometown on Users.HometownId = Hometown.id ;");

            while (reader.Read())
            {
                users.Add(new UserForViewDTO
                {
                    Id = reader.GetInt32(8),
                    FirstName = reader.GetString(0),
                    Email = reader.GetString(1),
                    LastName = reader.GetString(2),
                    PhoneNumber = reader.GetString(3),
                    UserName = reader.GetString(4),
                    Password = reader.GetString(7),
                    HometownId = reader.GetInt32(9),
                    Hometown = new Hometown
                    {
                        Name = reader.GetString(10),
                        Id = reader.GetInt32(13),
                    }
                });
            }

            await _repository.CloseAsync();

            if (!reader.HasRows)
                throw new ExamProgramException("Student notfound");

            return users.ToPagedList<UserForViewDTO>(@params);
        }

        public async Task<UserForCreateDTO> CreateAsync(UserForCreateDTO userForCreate)
        {
            var reader = await _repository.GetAsync($"Select Email From Users Where Email = '{userForCreate.Email}'");
            
            if(reader.HasRows)
                throw new ExamProgramException("Email notfound");

            var count = await _repository.CreateAsync($"Insert into Users (FirstName, LastName, UserName, Email, PhoneNumber, Password, HometownId, CreateAt) Values ('{userForCreate.FirstName}', '{userForCreate.LastName}', '{userForCreate.UserName}', '{userForCreate.Email}', '{userForCreate.PhoneNumber}', '{userForCreate.Password}', {userForCreate.HometownId}, '{DateTime.Now}');");

            if (count > 0)
                await _repository.CloseAsync();
            else
                throw new ExamProgramException("Create not found");

            return userForCreate;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var count = await _repository.DeleteAsync($"DELETE FROM Users WHERE Id = {id};");

            if (count > 0)
                await _repository.CloseAsync();
            else
                throw new ExamProgramException("Delete not found");

            return count > 0;
        }
                
        public async Task<UserForUpdateDTO> UpdateAsync(int id, UserForUpdateDTO userForUpdate)
        {           
            var count = await _repository.UpdateAsync($"UPDATE Users SET (FirstName, LastName, UserName, Email, PhoneNumber, Password, HometownId, UpdateAt) = ('{userForUpdate.FirstName}', '{userForUpdate.LastName}', '{userForUpdate.UserName}', '{userForUpdate.Email}', '{userForUpdate.PhoneNumber}', '{userForUpdate.Password}', {userForUpdate.HometownId}, '{DateTime.Now}') WHERE Id = {id};");

            if (count > 0)
                await _repository.CloseAsync();
            else
                throw new ExamProgramException("Create not found");

            return userForUpdate;
        }
    }
}
