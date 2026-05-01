using System.ComponentModel.DataAnnotations;

namespace PersonalBlog.Application.DTOs
{
    public class CreateArticuloDto
    {
        [Required(ErrorMessage = "El título es obligatorio")]
        [MaxLength(100, ErrorMessage = "El título no puede tener más de 100 caracteres")]
        [MinLength(5, ErrorMessage = "El título debe tener al menos 5 caracteres")]
        public string Titulo { get; set; }= string.Empty;

        [Required(ErrorMessage = "El contenido no puede estar vacio")]
        [MinLength(50, ErrorMessage = "El contenido debe tener al menos 50 caracteres")]
        [MaxLength(2000, ErrorMessage = "El contenido no puede tener más de 2000 caracteres")]
        public string Contenido { get; set; } = string.Empty;
        public DateTime FechaPublicacion { get; set; }
    }
}
