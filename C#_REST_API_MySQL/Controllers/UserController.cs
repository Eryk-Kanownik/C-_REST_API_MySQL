using C__REST_API_MySQL.Models;
using C__REST_API_MySQL.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace C__REST_API_MySQL.Controllers
{
    [ApiController]
    [Route("/users")]
    public class UserController : Controller
    {
        private IUserRepository _userRepository;
        public UserController(IUserRepository userRepository) {
            _userRepository = userRepository;
        }

        //get all users || WORKS
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            IEnumerable<User> users = await _userRepository.GetUsers();
            return Ok(users);
        }

        //get single user || WORKS
        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {
            User user = await _userRepository.GetUser(id);
            return Ok(user);
        }

        //create single user || WORKS
        [HttpPost]
        public async Task<ActionResult> Post([FromBody]User user)
        {
            await _userRepository.CreateUser(user);
            return Ok(user);
        }

        //edit single user || WORKS
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put([FromBody] User user, int id)
        {
            await _userRepository.UpdateUser(id,user);
            return Ok(user);
        }

        //delete user || WORKS
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var users = await _userRepository.DeleteUser(id);
            if (users == null)
            {
                return NotFound("User not found!");
            }
            return Ok(users);
        }
    }
}
