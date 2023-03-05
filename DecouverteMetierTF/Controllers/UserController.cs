using DecouverteMetierTF.Models;
using DecouverteMetierTF.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DecouverteMetierTF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private UserRepository _userRepository;
        public UserController(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        [HttpPost]
        public IActionResult Register(UserRegisterDTO u)
        {
            try
            {
                _userRepository.Register(u);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{login}/{password}")]
        public IActionResult Login(string login,string password) 
        {
            try
            {
                User user = _userRepository.Login(login,password);
                return Ok(user);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
