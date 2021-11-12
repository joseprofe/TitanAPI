using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Titan.BL.Contracts;
using Titan.Core.DTO;
using Titan.Core.Security;
using Titan.DAL.Entities;
using Titan.DAL.Repositories.Contracts;

namespace Titan.BL.Implementations
{
    public class UsuarioBL : IUsuarioBL
    {
        public IUsuarioRepository usuarioRepository { get; set; }
        public IPasswordGenerator passwordGenerator { get; set; }
        public IMapper mapper { get; set; }
        public UsuarioBL(IUsuarioRepository usuarioRepository, IPasswordGenerator passwordGenerator,
            IMapper mapper)
        {
            this.usuarioRepository = usuarioRepository;
            this.passwordGenerator = passwordGenerator;
            this.mapper = mapper;
        }

        public UsuarioDTO Login(UsuarioDTO usuarioDTO)
        {
            usuarioDTO.Password = passwordGenerator.Hash(usuarioDTO.Password);
            var usuario = mapper.Map<UsuarioDTO, Usuario>(usuarioDTO);
            usuarioDTO = mapper.Map<Usuario, UsuarioDTO>(usuarioRepository.Login(usuario));
            if(usuarioDTO != null)
                usuarioDTO.Password = null;
            return usuarioDTO;
        }

        public UsuarioDTO Create(UsuarioDTO usuarioDTO)
        {
            usuarioDTO.Password = passwordGenerator.Hash(usuarioDTO.Password);
            var usuario = mapper.Map<UsuarioDTO, Usuario>(usuarioDTO);
            if (!usuarioRepository.Exists(usuario))
            {
                var u = mapper.Map<Usuario, UsuarioDTO>(usuarioRepository.Create(usuario));
                u.Password = null;
                return u;
            }
            return null;
        }
    }
}
