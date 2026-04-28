using PersonalBlog.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBlog.Domain.Entities
{
    public class Articulo : BaseEntity
    {
        public string Titulo { get; set; } = string.Empty;
        public string Contenido { get; set; } = string.Empty;
        public DateTime FechaPublicacion { get; set; }
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; } = null!;
    }
}
