using System;
using System.Collections.Generic;
using System.Text;

namespace Titan.Core.DTO
{
    public class UsuarioDTO
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
        public int ProvinciaId { get; set; }
        public ProvinciaDTO Provincia { get; set; }
        public string Token { get; set; }
    }
}
