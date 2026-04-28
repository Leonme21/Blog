using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBlog.Application.DTOs
{
    public class RegisterResponseDto
    {
        public int Id { get; set; }
        public bool Success { get; set; }
        public string Rol { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public string Token { get; set; } = string.Empty;
    }
}
