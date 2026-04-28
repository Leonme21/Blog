using Microsoft.EntityFrameworkCore;
using PersonalBlog.Domain.Entities;
using PersonalBlog.Domain.Interfaces;
using PersonalBlog.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBlog.Infrastructure.Repositories
{
    public class ArticuloRepository : IArticuloRepository
    {
        private readonly ApplicationDbContext _context;

        public ArticuloRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsyncs(Articulo articulo)
        {
            await _context.Articulos.AddAsync(articulo);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsyncs(int id)
        {
            await _context.Articulos.Where(a => a.Id == id).ExecuteDeleteAsync();
        }

        public async Task<IEnumerable<Articulo>> GetAllAsyncs()
        {
            return await _context.Articulos.Include(a => a.Usuario).ToListAsync();
        }

        public async Task<Articulo?> GetByIdAsyncs(int id)
        {
            return await _context.Articulos.Include(a => a.Usuario).FirstOrDefaultAsync(a => a.Id == id);
        }

        public Task UpdateAsyncs(Articulo articulo)
        {
            _context.Articulos.Update(articulo);
            return _context.SaveChangesAsync();
        }
    }
}
