using System;
using System.Collections.Generic;
using System.Text;
using Titan.Core.DTO;

namespace Titan.BL.Contracts
{
    public interface IUsuarioBL
    {
        UsuarioDTO Login(LoginDTO loginDTO);
        UsuarioDTO Create(UsuarioDTO usuarioDTO);
    }
}
