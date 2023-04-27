using ExamProgram.Service.Interfaces.Chats;
using ExamProgram.Service.Interfaces.Hometowns;
using ExamProgram.Service.Interfaces.Users;
using ExamProgram.Service.Services.Chats;
using ExamProgram.Service.Services.Hometowns;
using ExamProgram.Service.Services.Users;
using System;

        Console.WriteLine("Hello, World!");

        IUserService _userService = new UserService();

        IChatService _chatService = new ChatService();

        IHometownService _hometownService = new HometownsService();
