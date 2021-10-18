using ClientesApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ClientesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IConfiguration configuration;

        public LoginController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(UsuarioLogin usuarioLogin)
        {
            var _userInfo = await AutenticarUsuarioAsync(usuarioLogin.Usuario, usuarioLogin.Password);
            if (_userInfo != null)
            {
                return Ok(new { token = GenerarTokenJWT(_userInfo) });
            }
            else
            {
                return Unauthorized();
            }
        }

        private async Task<UsuarioInfo> AutenticarUsuarioAsync(string usuario, string password)
        {
            return new UsuarioInfo()
            {
                Id = new Guid("B5D233F0-6EC2-4950-8CD7-F44D16EC878F"),
                Nombre = "Dennys",
                Apellidos = "Lopez",
                Email = "email.usuario@dominio.com",
                Rol = "Administrador"
            };
        }

        private string GenerarTokenJWT(UsuarioInfo usuarioInfo)
        {
            var _symmetricSecurityKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(configuration["JWT:ClaveSecreta"])
                );
            var _signingCredentials = new SigningCredentials(
                    _symmetricSecurityKey, SecurityAlgorithms.HmacSha256
                );
            var _Header = new JwtHeader(_signingCredentials);

            var _Claims = new[] {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.NameId, usuarioInfo.Id.ToString()),
                new Claim("nombre", usuarioInfo.Nombre),
                new Claim("apellidos", usuarioInfo.Apellidos),
                new Claim(JwtRegisteredClaimNames.Email, usuarioInfo.Email),
                new Claim(ClaimTypes.Role, usuarioInfo.Rol)
            };

            var _Payload = new JwtPayload(
                    issuer: configuration["JWT:Issuer"],
                    audience: configuration["JWT:Audience"],
                    claims: _Claims,
                    notBefore: DateTime.UtcNow,
                    expires: DateTime.UtcNow.AddHours(24)
                );

            var _Token = new JwtSecurityToken(
                    _Header,
                    _Payload
                );

            return new JwtSecurityTokenHandler().WriteToken(_Token);
        }
    }
}
