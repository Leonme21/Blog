using PersonalBlog.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBlog.Application.Interfaces
{
    public interface IUserService
    {
        Task<AuthResponseDto> LoginAsyncs(AuthRequestDto request);
        Task<RegisterResponseDto> RegisterAsyncs(RegisterRequestDto request);
    }
}
