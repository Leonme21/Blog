using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBlog.Application.DTOs
{
    public class CreateArticuloDto
    {
        public string Titulo { get; set; }= string.Empty;
        public string Contenido { get; set; } = string.Empty;
        public DateTime FechaPublicacion { get; set; }
    }
}
