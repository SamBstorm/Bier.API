using Bier.Models;
using Bier.Services.Bases;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Bier.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository repository;
        private readonly JWTSettings jwtSettings;

        public UsersController(IUserRepository repository, IOptions<JWTSettings> jwtSettings)
        {
            this.repository = repository;
            this.jwtSettings = jwtSettings.Value;
        }

        [AllowAnonymous]
        [HttpPost("[action]")]
        public ActionResult<UserPublic> Login(string email, string password) {
            try
            {
                UserPublic user = repository.Check(email, password);
                if (user is null) return StatusCode(StatusCodes.Status401Unauthorized, "L'email et le mot de passe ne correspondent à aucun profil.");
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(jwtSettings.SecretKey);
                var tokenDescriptor = new SecurityTokenDescriptor {
                    Subject = new ClaimsIdentity( new Claim[]
                    {
                        new Claim (ClaimTypes.Name, user.Email)
                    }),
                    Expires = DateTime.UtcNow.AddMinutes(10),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                user.Token = tokenHandler.WriteToken(token);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    Method = nameof(Login),
                    Message = ex.Message
                });
            }
        }
    }
}
