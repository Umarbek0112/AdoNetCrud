using AutoMapper;
using ExamProgram.Data.IRepository;
using ExamProgram.Data.Repository;
using ExamProgram.Domain.Configurations;
using ExamProgram.Domain.Entities.Hometowns;
using ExamProgram.Domain.Entities.Users;
using ExamProgram.Service.DTOs.HomeTowns;
using ExamProgram.Service.Exceptionst;
using ExamProgram.Service.Extensions;
using ExamProgram.Service.Interfaces.Hometowns;
using ExamProgram.Service.Mappers;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExamProgram.Service.Services.Hometowns
{
    public class HometownsService : IHometownService
    {
        private readonly IGenericRepositoriy _repository;
        private readonly IMapper _mapper;
        public HometownsService()
        {
            _repository = new GenericRepository();
            _mapper = new MapperConfiguration(cfg =>
                cfg.AddProfile<MappingProfile>())
                .CreateMapper();
        }
        public async Task<HometownForCreateDTO> CreateAsync(HometownForCreateDTO usehometownForCreate)
        {
            var count = await _repository.CreateAsync($"Insert into Hometown (Name, CreateAt) Values ('{usehometownForCreate.Name}', '{DateTime.UtcNow}');");

            if (count > 0)
                await _repository.CloseAsync();
            else
                throw new ExamProgramException("Create not found");

            return usehometownForCreate;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var count = await _repository.DeleteAsync($"DELETE FROM Hometown WHERE Id = {id};");

            if (count > 0)
                await _repository.CloseAsync();
            else
                throw new ExamProgramException("Delete not found");

            return count > 0;
        }

        public async Task<IEnumerable<HometownForViewDTO>> GetAllAsync(PaginationParams @params)
        {
            List<HometownForViewDTO> hometown = new List<HometownForViewDTO>();

            var reader = await _repository.GetAsync($"Select * from Hometown inner join Users on Hometown.Id = Users.HometownId;");

            while (reader.Read())
            {
                User user = new User();
                user.Id = reader.GetInt32(12);
                user.LastName = reader.GetString(6);
                user.FirstName = reader.GetString(4);
                user.Email = reader.GetString(5);
                user.PhoneNumber = reader.GetString(7);
                user.UserName = reader.GetString(8);
                user.Password = reader.GetString(11);

                hometown.Add(new HometownForViewDTO
                {
                    Id = reader.GetInt32(3),
                    Name = reader.GetString(0),
                    
                    Users = new List<User>()

                });
                /* User user;
                  user = new User
                 {
                     Id = reader.GetInt32(12),
                     LastName = reader.GetString(6),
                     FirstName = reader.GetString(4),
                     Email = reader.GetString(5),
                     PhoneNumber = reader.GetString(7),
                     UserName = reader.GetString(8),
                     Password = reader.GetString(11)
                 };
                 Hometown hom = new Hometown();
                 hom.Id = reader.GetInt32(3);
                 hom.Name = reader.GetString(0);
                 hom.Users.Add(user);*/

                //hometown.Users.add(user);

            }
            await _repository.CloseAsync();

            if (!reader.HasRows)
                throw new ExamProgramException("Chat notfound");

            return hometown.ToPagedList<HometownForViewDTO>(@params);
        }

        public async Task<HometownForViewDTO> GetAsync(int id)
        {
            HometownForViewDTO hometown = new HometownForViewDTO();

            var reader = await _repository.GetAsync($"Select * from Hometown inner join Users on Hometown.Id = Users.HometownId Where Hometown.Id = {id};");
            int son = 0;
            while (reader.Read())
            {
                son++;
                if(son == 1)
                    hometown = new HometownForViewDTO
                    {
                        Id = reader.GetInt32(3),
                        Name = reader.GetString(0),
                        Users = new List<User>()
                    };

                User user = new User();
                user.Id = reader.GetInt32(12);
                user.LastName = reader.GetString(6);
                user.FirstName = reader.GetString(4);
                user.Email = reader.GetString(5);
                user.PhoneNumber = reader.GetString(7);
                user.UserName = reader.GetString(8);
                user.Password = reader.GetString(11);

                
                hometown.Users.Add(user);
            }

            await _repository.CloseAsync();

            if (!reader.HasRows)
                throw new ExamProgramException("Chat notfound");

            return hometown;
        }

        public async Task<HometownForUpdateDTO> UpdateAsync(int id, HometownForUpdateDTO hometownForUpdate)
        {
            var count = await _repository.UpdateAsync($"UPDATE Hometown SET (Name, UpdateAT) = ('{hometownForUpdate.Name}', '{DateTime.UtcNow}') WHERE Id = {id};");

            if (count > 0)
                await _repository.CloseAsync();
            else
                throw new ExamProgramException("Create not found");

            return hometownForUpdate;
        }
    }
}
