using Bier.Models;
using Bier.Services.Bases;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bier.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository repository;

        public UsersController(IUserRepository repository)
        {
            this.repository = repository;
        }

        [HttpPost("[action]")]
        public ActionResult<UserPublic> Login(string email, string password) {
            try
            {
                UserPublic user = repository.Check(email, password);
                if (user is null) return StatusCode(StatusCodes.Status401Unauthorized, "L'email et le mot de passe ne correspondent à aucun profil.");
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
