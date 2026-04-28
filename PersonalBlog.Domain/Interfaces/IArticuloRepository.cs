using PersonalBlog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBlog.Domain.Interfaces
{
    public interface IArticuloRepository
    {
        Task<IEnumerable<Articulo>> GetAllAsyncs();
        Task<Articulo?> GetByIdAsyncs(int id);
        Task AddAsyncs(Articulo articulo);
        Task UpdateAsyncs(Articulo articulo);
        Task DeleteAsyncs(int id);
    }
}
