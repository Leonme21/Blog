using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PersonalBlog.Application.DTOs;
using PersonalBlog.Application.Interfaces;
using System.Security.Claims;


namespace PersonalBlog.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ArticuloController : Controller
    {
        private readonly IArticuloService _articuloService;

        public ArticuloController(IArticuloService articuloService)
        {
            _articuloService = articuloService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var articulos = await _articuloService.obtenerTodosAsyncs();
            return Ok(articulos);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var articulo = await _articuloService.obtenerPorIdAsyncs(id);
            if (articulo == null) return NotFound();
            return Ok(articulo);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult> Create(CreateArticuloDto articuloDto)
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim == null) return Unauthorized(); 
            int userId = int.Parse(userIdClaim.Value);
            var nuevoArticulo = await _articuloService.crearAsyncs(articuloDto, userId);
            return CreatedAtAction(nameof(GetById), new { id = nuevoArticulo.Id }, nuevoArticulo);

        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, UpdateArticuloDto articuloDto)
        {
            try
            {
                await _articuloService.actualizarAsyncs(id, articuloDto);
                return NoContent();
            }
            catch (ArgumentException)
            {
                return NotFound();
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _articuloService.eliminarAsyncs(id);
            return NoContent();
        }
    }
}
