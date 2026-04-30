using PersonalBlog.Domain.Entities;

namespace PersonalBlog.Domain.Interfaces
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(Usuario usuario);
    }
}
