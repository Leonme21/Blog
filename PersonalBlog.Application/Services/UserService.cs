using PersonalBlog.Application.DTOs;
using PersonalBlog.Application.Interfaces;
using PersonalBlog.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using PersonalBlog.Application.Mappings;

namespace PersonalBlog.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IPasswordHasher _passwordHasher;

        public UserService(IUserRepository userRepository, IJwtTokenGenerator jwtTokenGenerator, IPasswordHasher passwordHasher)
        {
            _userRepository = userRepository;
            _jwtTokenGenerator = jwtTokenGenerator;
            _passwordHasher = passwordHasher;
        }
        public async Task<AuthResponseDto> LoginAsyncs(AuthRequestDto dto)
        {
            var user = await _userRepository.GetByNombreUsuarioAsync(dto.UserName);
            if (user == null || !_passwordHasher.VerificacionContraseña(dto.Password, user.Contraseña))
            {
                return new AuthResponseDto { Success = false, Message = "Usuario o contraseña incorrectos." };
            }
            var token = _jwtTokenGenerator.GenerateToken(user);

            // Usamos tu método de mapeo y le pasamos el token
            var response = user.ToAuthResponseDto(token);
            response.Success = true;
            response.Message = "Inicio de sesión exitoso.";
            return response;
        }


        public async Task<RegisterResponseDto> RegisterAsyncs(RegisterRequestDto dto)
        {
            // 1. Validar si ya existe
            if (await _userRepository.GetByNombreUsuarioAsync(dto.UserName) != null)
                return new RegisterResponseDto { Success = false, Message = "El nombre de usuario ya existe." };
            if (await _userRepository.ExistsByEmailAsync(dto.Email ?? string.Empty))
                return new RegisterResponseDto { Success = false, Message = "El email ya existe." };
            // 2. Crear entidad y Hashear contraseña
            var user = dto.ToEntity();
            user.Contraseña = _passwordHasher.HashContraseña(dto.Contraseña);
            user.Rol = PersonalBlog.Domain.Enums.Rol.User;

            await _userRepository.AddAsync(user);
            // 3. Generar token y responder
            var token = _jwtTokenGenerator.GenerateToken(user);
            return user.ToRegisterResponseDto(token);
        }
    }
}



