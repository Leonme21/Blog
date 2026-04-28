using PersonalBlog.Application.DTOs;
using PersonalBlog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBlog.Application.Mappings
{
    public static class UserMappingExtensions
    {
        public static AuthResponseDto ToAuthResponseDto(this Usuario usuario, string token)
        {
            return new AuthResponseDto
            {
                Id = usuario.Id,
                Token = token,
                UserName = usuario.NombreUsuario,
                Rol = usuario.Rol.ToString(),
            };
        }
        public static Usuario ToEntity (this AuthRequestDto dto)
        {
            return new Usuario
            {
                NombreUsuario = dto.UserName,
                Contraseña = dto.Password
            };
        }

        public static RegisterResponseDto ToRegisterResponseDto(this Usuario usuario, string token)
        {
            return new RegisterResponseDto
            {
                Id = usuario.Id,
                Token = token,
                Rol = usuario.Rol.ToString(),
            };
        }

        public static Usuario ToEntity (this RegisterRequestDto dto)
        {
            return new Usuario
            {
                Nombre = dto.Nombre,
                NombreUsuario = dto.UserName,
                Email = dto.Email,
                Contraseña = dto.Contraseña
            };
        }
    }
}
