using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechStore.DTOs.UserDtos;

namespace TechStore.Interfaces
{
    public interface IAuthRepository
    {
        Task<UserAuthResponseDto> RegisterAsync(UserRegisterDto userRegisterDto);
        Task<UserAuthResponseDto> LoginAsync(UserLoginDto userLoginDto);
    }
}