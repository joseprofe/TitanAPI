using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Titan.BL.Contracts;
using Titan.Core.DTO;
using Titan.Core.Email;
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
        public IJwtBearer jwtBearer { get; set; }
        public IEmailSender emailSender { get; set; }
        public UsuarioBL(IUsuarioRepository usuarioRepository, IPasswordGenerator passwordGenerator,
            IMapper mapper, IJwtBearer jwtBearer, IEmailSender emailSender)
        {
            this.usuarioRepository = usuarioRepository;
            this.passwordGenerator = passwordGenerator;
            this.mapper = mapper;
            this.jwtBearer = jwtBearer;
            this.emailSender = emailSender;
        }

        public UsuarioDTO Login(LoginDTO loginDTO)
        {
            loginDTO.Password = passwordGenerator.Hash(loginDTO.Password);
            var usuario = mapper.Map<LoginDTO, Usuario>(loginDTO);
            var usuarioDTO = mapper.Map<Usuario, UsuarioDTO>(usuarioRepository.Login(usuario));
            if (usuarioDTO != null)
            {
                usuarioDTO.Password = null;
                usuarioDTO.Token = jwtBearer.GenerateJWTToken(usuario);
            }
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
                this.emailSender.Send(usuario.Email);
                return u;
            }
            return null;
        }
    }
}
