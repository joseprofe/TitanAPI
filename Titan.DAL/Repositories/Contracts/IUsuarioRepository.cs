using System;
using System.Collections.Generic;
using System.Text;
using Titan.DAL.Entities;

namespace Titan.DAL.Repositories.Contracts
{
    public interface IUsuarioRepository
    {
        bool Login(Usuario u);
        Usuario Create(Usuario usuario);
        bool Exists(Usuario u);
    }
}
