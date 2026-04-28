using PersonalBlog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBlog.Domain.Interfaces
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(Usuario usuario);
    }
}
