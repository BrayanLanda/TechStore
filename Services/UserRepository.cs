using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TechStore.Data;
using TechStore.DTOs.UserDtos;
using TechStore.Errors;
using TechStore.Errors.GenericErrors;
using TechStore.Interfaces;
using TechStore.Models;

namespace TechStore.Services
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly DataContext _context;
        public UserRepository(DataContext context) : base(context)
        {
            _context = context;
        }
        public async Task<User> GetUserByEmailAsync(string email)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
            if(user == null) 
                throw new UserNotFoundException("user", email);
            return user;
        }

        // public async Task AddUserAsync(UserRegisterDto userDto)
        // {
        //     // Verificar si el usuario ya existe
        //     var existingUser = await GetUserByEmailAsync(userDto.Email);
        //     if (existingUser != null)
        //     {
        //         throw new UserAlreadyExistsException(userDto.Email);
        //     }

        //     // Mapear el DTO al modelo
        //     var user = new User
        //     {
        //         Email = userDto.Email,
        //         // Asigna otros campos según sea necesario
        //     };

        //     await AddAsync(user);
        // }
    }
}