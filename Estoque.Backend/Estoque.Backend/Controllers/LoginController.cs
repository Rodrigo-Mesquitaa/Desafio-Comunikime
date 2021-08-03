using Estoque.Backend.Data;
using Estoque.Backend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Estoque.Backend.Controllers
{
    [Route("api")]
    public class LoginController : ControllerBase
    {
        [HttpPost]
        [Route("Login")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Authenticate([FromBody] User model, [FromServices] UserContext context)
        {
            var user = await context.UserItems
            .FirstOrDefaultAsync(x => x.Username == model.Username && x.Password == model.Password);

            if (user == null)
                return NotFound(new { message = "Usuário ou senha inválidos" });

            var token = TokenService.GenerateToken(user);

            user.Password = "";

            return new
            {
                user = user,
                token = token
            };
        }
    }
}
