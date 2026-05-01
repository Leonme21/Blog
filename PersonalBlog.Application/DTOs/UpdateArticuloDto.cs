using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBlog.Application.DTOs
{
    public class UpdateArticuloDto
    {
        [Required(ErrorMessage = "El título es obligatorio")]
        [MaxLength(100, ErrorMessage = "El título no puede tener más de 100 caracteres")]
        [MinLength(5, ErrorMessage = "El título debe tener al menos 5 caracteres")]
        public string Titulo { get; set; } = string.Empty;

        [Required(ErrorMessage = "El contenido no puede estar vacio")]
        [MinLength(50, ErrorMessage = "El contenido debe tener al menos 50 caracteres")]
        [MaxLength(5000, ErrorMessage = "El contenido no puede tener más de 5000 caracteres")]
        public string Contenido { get; set; } = string.Empty;
        public DateTime FechaPublicacion { get; set; }
    }
}
