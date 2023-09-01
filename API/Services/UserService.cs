
using API.DTOS;
using API.Helpers;
using Aplicacion.Contratos;
using Dominio.Interfaces;
using Dominio.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace API.Services
{
    public class UserService :IUserService
    {
        private readonly JWT _jwt;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPasswordHasher<Usuario> _passwordHasher;
        private readonly IJwtGenerador _jwtGenerador;

        public UserService(IUnitOfWork unitOfWork, IOptions<JWT> jwt,
            IPasswordHasher<Usuario> passwordHasher, IJwtGenerador jwtGenerador)
        {
            _jwt = jwt.Value;
            _unitOfWork = unitOfWork;
            _passwordHasher = passwordHasher;
            _jwtGenerador = jwtGenerador;
        }

        public Task<DatosUsuarioDTO> GetTokenAsync(LoginDTO model)
        {
            throw new NotImplementedException();
        }

        public Task<string> RegisterAsync(RegisterDTO model)
        {
            throw new NotImplementedException();
        }
    }

   
}