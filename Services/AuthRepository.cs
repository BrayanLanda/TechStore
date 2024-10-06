using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using TechStore.DTOs.UserDtos;
using TechStore.Errors;
using TechStore.Interfaces;
using TechStore.Models;

namespace TechStore.Services
{
    public class AuthRepository : IAuthRepository
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly ITokenRepository _tokenRepository;
        private readonly IPasswordHasher<User> _passwordHasher;

        public AuthRepository(
            IUserRepository userRepository,
            IMapper mapper,
            ITokenRepository tokenRepository,
            IPasswordHasher<User> passwordHasher)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _tokenRepository = tokenRepository;
            _passwordHasher = passwordHasher;
        }


        public async Task<UserAuthResponseDto> RegisterAsync(UserRegisterDto userRegisterDto)
        {
            // Verificar si el usuario ya existe
            var existingUser = await _userRepository.GetUserByEmailAsync(userRegisterDto.Email);
            if (existingUser != null)
            {
                throw new UserAlreadyExistsException("User", userRegisterDto.Email);
            }

            // Crear nuevo usuario
            var newUser = _mapper.Map<User>(userRegisterDto);

            // Mapea el role desde el string a la enumeración Role
            newUser.Role = Enum.Parse<UserRole>(userRegisterDto.Role, true);

            newUser.PasswordHash = _passwordHasher.HashPassword(newUser, userRegisterDto.Password);

            // Guardar usuario en la base de datos
            await _userRepository.AddAsync(newUser);

            // Generar token
            var token = _tokenRepository.CreateToken(newUser);

            // Crear y devolver respuesta
            return new UserAuthResponseDto
            {
                Username = newUser.Username,
                Token = token,
                Role = newUser.Role.ToString()
            };
        }

        public async Task<UserAuthResponseDto> LoginAsync(UserLoginDto userLoginDto)
        {
            // Buscar usuario por email
            var user = await _userRepository.GetUserByEmailAsync(userLoginDto.Email);
            if (user == null)
            {
                throw new InvalidCredentialsException();
            }

            // Verificar contraseña
            var result = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, userLoginDto.Password);
            if (result == PasswordVerificationResult.Failed)
            {
                throw new InvalidCredentialsException();
            }

            // Generar token
            var token = _tokenRepository.CreateToken(user);

            // Crear y devolver respuesta
            return new UserAuthResponseDto
            {
                Username = user.Username,
                Token = token,
                Role = user.Role.ToString()
            };
        }
    }
}