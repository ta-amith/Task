using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task1.Entities;
using Task1.Interfaces;

namespace Task1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet("Get")]
        public async Task<ActionResult<IReadOnlyList<User>>> Get()
        {
            var users = await _userRepository.GetListAsync();
            if (users == null)
                return NotFound();

            return Ok(users);

        }

        [HttpGet("Get/{id}")]
        public async Task<ActionResult<IReadOnlyList<User>>> Get(string id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
                return NotFound();

            return Ok(user);

        }

        [HttpPost("Create")]
        public async Task<ActionResult<User>> Create(User user)
        {
            var newuser = await _userRepository.CreateAsync(user);
            return Ok(newuser);
        }

        [HttpPut("Update/{id}")]
        public async Task<ActionResult<User>> Update(string id, User user)
        {
            await _userRepository.Update(id,user);
            return Ok();
        }

        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            var existingUser = Get(id);
            if (existingUser == null)
                return NotFound();

            await _userRepository.Delete(id: id);
            return Ok();
        }



    }
}