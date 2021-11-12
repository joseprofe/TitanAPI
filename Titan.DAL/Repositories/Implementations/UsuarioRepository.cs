using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Titan.DAL.Entities;
using Titan.DAL.Repositories.Contracts;

namespace Titan.DAL.Repositories.Implementations
{
    public class UsuarioRepository : IUsuarioRepository
    {
        public pitufoContext _context { get; set; }

        public UsuarioRepository(pitufoContext context)
        {
            this._context = context;
        }
        public Usuario Login(Usuario usuario)
        {
            return _context.Usuarios.FirstOrDefault(u => u.Email == usuario.Email && u.Password == usuario.Password);
        }

        public Usuario Create(Usuario usuario)
        {
            var u = _context.Usuarios.Add(usuario);
            _context.SaveChanges();
            return u.Entity;
        }

        public bool Exists(Usuario usuario)
        {
            return _context.Usuarios.Any(u => u.Email == usuario.Email || u.Username == usuario.Username);
        }
    }
}
