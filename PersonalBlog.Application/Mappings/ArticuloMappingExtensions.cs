using PersonalBlog.Application.DTOs;
using PersonalBlog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBlog.Application.Mappings
{
    public static class ArticuloMappingExtensions
    {
        public static ArticuloResponseDto ToArticuloDto(this Articulo articulo)
        {
            return new ArticuloResponseDto
            {
                Id = articulo.Id,
                Titulo = articulo.Titulo,
                Contenido = articulo.Contenido,
                FechaPublicacion = articulo.FechaPublicacion,
                NombreAutor = articulo.Usuario?.NombreUsuario ?? "Desconocido"

            };
        }

        public static Articulo ToEntity(this CreateArticuloDto articuloDto)
        {
            return new Articulo
            {
                Titulo = articuloDto.Titulo,
                Contenido = articuloDto.Contenido,
                FechaPublicacion = articuloDto.FechaPublicacion,
            };
        }

        public static void UpdateEntity(this Articulo articulo, UpdateArticuloDto articuloDto)
        {
            articulo.Titulo = articuloDto.Titulo;
            articulo.Contenido = articuloDto.Contenido;
            articulo.FechaPublicacion = articuloDto.FechaPublicacion;
        }
    }
}
