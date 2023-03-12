using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TicTacToe.Services;

namespace TicTacToe.Controllers
{
    [ApiController]
    [Route("/")]
    public class HomeController : ControllerBase
    {
        private readonly IUsersService _usersService;
        public HomeController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        
        [ResponseCache(NoStore = true, Duration = 0)]   
        [HttpPost("login")]
        public async Task<IActionResult> LogIn([FromQuery] string name, [FromQuery] string redirectUrl)
        {
            if (User?.Identity?.IsAuthenticated == true)
            {
                return Redirect(redirectUrl);
            }

            var id = Guid.NewGuid().ToString();
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, name),
                new Claim(ClaimTypes.NameIdentifier, id),
                new Claim(ClaimTypes.Role, "Player")
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var authProperties = new AuthenticationProperties()
            {
                RedirectUri = "/ready"
            };

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);
            await _usersService.AddUserAsync(id, name);

            return Redirect(redirectUrl);
        }
    }
}