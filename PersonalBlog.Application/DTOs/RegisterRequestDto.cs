using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBlog.Application.DTOs
{
    public class RegisterRequestDto
    {
        [MinLength(3, ErrorMessage = "El nombre debe tener al menos 3 caracteres.")]
        [MaxLength(50, ErrorMessage = "El nombre no puede tener más de 50 caracteres.")]
        public string? Nombre { get; set; } 

        [Required(ErrorMessage = "El nombre de usuario es requerido.")]
        [MinLength(6, ErrorMessage = "El nombre de usuario debe tener al menos 6 caracteres.")]
        [MaxLength(20, ErrorMessage = "El nombre de usuario no puede tener más de 20 caracteres.")]
        public string UserName { get; set; } = string.Empty;

        [EmailAddress(ErrorMessage = "Formato de correo inválido.")]
        [MinLength(6, ErrorMessage = "El correo debe tener al menos 6 caracteres.")]
        [MaxLength(100, ErrorMessage = "El correo no puede tener más de 100 caracteres")]
        public string? Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "La contraseña es requerida.")]
        [MinLength(6, ErrorMessage = "La contraseña debe tener al menos 6 caracteres.")]
        [MaxLength(20, ErrorMessage = "La contraseña no puede tener más de 20 caracteres.")]
        public string Contraseña { get; set; } = string.Empty;
    }
}
