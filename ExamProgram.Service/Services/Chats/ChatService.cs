using AutoMapper;
using ExamProgram.Data.IRepository;
using ExamProgram.Data.Repository;
using ExamProgram.Domain.Configurations;
using ExamProgram.Domain.Entities.Users;
using ExamProgram.Service.DTOs.Chats;
using ExamProgram.Service.Exceptionst;
using ExamProgram.Service.Extensions;
using ExamProgram.Service.Interfaces.Chats;
using ExamProgram.Service.Mappers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExamProgram.Service.Services.Chats
{
    public class ChatService : IChatService
    {
        private readonly IGenericRepositoriy _repository;
        private readonly IMapper _mapper;
        public ChatService()
        {
            _repository = new GenericRepository();
            _mapper = new MapperConfiguration(cfg =>
                cfg.AddProfile<MappingProfile>())
                .CreateMapper();
        }
        public async Task<ChatForCreateDTO> CreateAsync(ChatForCreateDTO chatForCreate)
        {
            var count = await _repository.CreateAsync($"Insert into Chats (ChatText, UserId, CreateAt) Values ('{chatForCreate.ChatText}', '{chatForCreate.UserId}', '{DateTime.UtcNow}');");

            if (count > 0)
                await _repository.CloseAsync();
            else
                throw new ExamProgramException("Create not found");

            return chatForCreate;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var count = await _repository.DeleteAsync($"DELETE FROM Chats WHERE Id = {id};");

            if (count > 0)
                await _repository.CloseAsync();
            else
                throw new ExamProgramException("Delete not found");

            return count > 0;
        }

        public async Task<IEnumerable<ChatForViewDTO>> GetAllAsync(PaginationParams @params)
        {
            List<ChatForViewDTO> chat = new List<ChatForViewDTO>();

            var reader = await _repository.GetAsync($"Select * from Chats inner join Users on Users.Id = Chats.Userid;");

            while (reader.Read())
            {
                chat.Add(new ChatForViewDTO
                {
                    Id = reader.GetInt32(3),
                    ChatText = reader.GetString(0),
                    User = new User
                    {
                        FirstName = reader.GetString(5),
                        LastName = reader.GetString(7),
                        Email = reader.GetString(6),
                    }
                });

            }
            await _repository.CloseAsync();

            if (!reader.HasRows)
                throw new ExamProgramException("Chat notfound");

            return chat.ToPagedList<ChatForViewDTO>(@params);
        }

        public async Task<ChatForViewDTO> GetAsync(int id)
        {
            ChatForViewDTO chat = new ChatForViewDTO();

            var reader = await _repository.GetAsync($"Select * from Chats inner join Users on Users.Id = Chats.Userid Where Chats.id = {id};");

            while (reader.Read())
            {
                chat = new ChatForViewDTO
                {
                    Id = reader.GetInt32(3),
                    ChatText = reader.GetString(0),
                    User = new User
                    {
                        FirstName = reader.GetString(5),
                        LastName = reader.GetString(7),
                        Email = reader.GetString(6),
                    }                    
                };

            }
            await _repository.CloseAsync();

            if (!reader.HasRows)
                throw new ExamProgramException("Chat notfound");

            return chat;
        }

        public async Task<ChatForUpdateDTO> UpdateAsync(int id, ChatForUpdateDTO chatForUpdate)
        {
            var count = await _repository.UpdateAsync($"UPDATE Chats SET (ChatText, UserId, UpdateAt) = ('{chatForUpdate.ChatText}', '{chatForUpdate.UserId}', '{DateTime.UtcNow}') WHERE Id = {id};");

            if (count > 0)
                await _repository.CloseAsync();
            else
                throw new ExamProgramException("Create not found");

            return chatForUpdate;
        }
    }
}
