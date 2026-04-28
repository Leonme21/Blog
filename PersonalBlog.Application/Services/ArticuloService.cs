using PersonalBlog.Application.DTOs;
using PersonalBlog.Application.Interfaces;
using PersonalBlog.Application.Mappings;
using PersonalBlog.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBlog.Application.Services
{
    public class ArticuloService : IArticuloService
    {
        private readonly IArticuloRepository _articuloRepository;

        public ArticuloService(IArticuloRepository articuloRepository)
        {
            _articuloRepository = articuloRepository;
        }

        public async Task actualizarAsyncs(int id, UpdateArticuloDto updateDto)
        {
            var articuloExistente = await _articuloRepository.GetByIdAsyncs(id);
            if (articuloExistente == null) throw new ArgumentException("Artículo no encontrado");
            articuloExistente.UpdateEntity(updateDto);
            await _articuloRepository.UpdateAsyncs(articuloExistente);

        }

        public async Task<ArticuloResponseDto> crearAsyncs(CreateArticuloDto articuloDto, int usuarioId)
        {
            var newArticulo = articuloDto.ToEntity();
            newArticulo.UsuarioId = usuarioId;
            await _articuloRepository.AddAsyncs(newArticulo);
            return newArticulo.ToArticuloDto();
        }

        public async Task eliminarAsyncs(int id)
        {
            await _articuloRepository.DeleteAsyncs(id);
        }

        public async Task<ArticuloResponseDto?> obtenerPorIdAsyncs(int id)
        {
            var articulo = await _articuloRepository.GetByIdAsyncs(id);
            return articulo?.ToArticuloDto();
        }
        public async Task<IEnumerable<ArticuloResponseDto>> obtenerTodosAsyncs()
        {
            var articulos = await _articuloRepository.GetAllAsyncs();
            return articulos.Select(a => a.ToArticuloDto());
        }
    }
}
