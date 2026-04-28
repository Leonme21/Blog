using PersonalBlog.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBlog.Application.Interfaces
{
    public interface IArticuloService
    {
        Task<IEnumerable<ArticuloResponseDto>> obtenerTodosAsyncs();
        Task<ArticuloResponseDto?> obtenerPorIdAsyncs(int id);
        Task<ArticuloResponseDto> crearAsyncs(CreateArticuloDto articuloDto, int usuarioId);
        Task actualizarAsyncs(int id, UpdateArticuloDto articuloDto);
        Task eliminarAsyncs(int id);
    }
}
