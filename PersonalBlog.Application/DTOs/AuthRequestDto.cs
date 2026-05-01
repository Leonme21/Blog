using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBlog.Application.DTOs
{
    public class AuthRequestDto
    {
        [Required(ErrorMessage = "Username es requerido.")]
        [MaxLength(20, ErrorMessage = "El nombre de usuario no puede tener más de 20 caracteres.")]
        public string UserName { get; set; } = string.Empty;

        [Required(ErrorMessage = "La contraseña es requerida.")]
        [MinLength(6, ErrorMessage = "La contraseña debe tener al menos 6 caracteres.")]
        [MaxLength(20, ErrorMessage = "La contraseña no puede tener más de 20 caracteres.")]
        public string Password { get; set; } = string.Empty;
    }
}
