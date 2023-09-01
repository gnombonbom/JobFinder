using JF.Domain.Models.Blank;
using JF.Domain.Models.Domain;
using JF.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace JF.API.Controllers
{
    [Route("index/[controller]")]
    [Area("User")]
    public class UserController : Controller
    {
        private UserService _service = new("Data Source=Mikhuil;Initial Catalog=JobFinderDB;Integrated Security=True");

        [HttpPost]
        [Route("Save")]
        public void SaveUser(UserBlank blank)
        {
            _service.SaveUser(blank);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById([FromRoute] Guid id)
        {
            User user = await _service.GetUserById(id);
            return Ok(user);
        }

        [HttpGet("{login},{password}")]
        [Route("GetByLoginAndPass")]
        public User GetUserByLoginAndPassword(String login, String password)
        {
            return _service.GetUserByLoginAndPassword(login, password);
        }
    }
}
