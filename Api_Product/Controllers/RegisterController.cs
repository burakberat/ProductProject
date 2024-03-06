using BusinessLayer.Concrete;
using BusinessLayer.Utilities.Results;
using EntityLayer.Concrete;
using EntityLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Api_Product.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;

        public RegisterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(UserRegister p)
        {
            AppUser appUser = new AppUser()
            {
                Name = p.Name,
                SurName = p.SurName,
                Gender = p.Gender,
                UserName = p.UserName,
                Email = p.Mail
            };

            if (p.Password == p.ConfirmPassword)
            {
                var result = await _userManager.CreateAsync(appUser, p.Password);
                if (result.Succeeded)
                {
                    return Ok(result);
                }
                return BadRequest(result);
            }
            return BadRequest();
        }
    }
}
