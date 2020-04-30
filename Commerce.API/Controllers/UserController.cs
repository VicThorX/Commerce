using Commerce.API.Mappers;
using Commerce.API.Models;
using Commerce.Data.Entities;
using Commerce.Data.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Commerce.API.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserService _userService;
        private readonly IMapper<UserModel, User> _userMapper;

        public UserController(
            ILogger<UserController> logger, 
            IUserService userService,
            IMapper<UserModel, User> userMapper)
        {
            _logger = logger;
            _userService = userService;
            _userMapper = userMapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> Get()
        {
            return new ObjectResult(await _userService.GetAll());
        }

        [HttpGet("{id:length(24)}", Name = "GetUser")]
        public async Task<ActionResult<User>> Get(string id)
        {
            var user = await _userService.Get(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        [HttpPost]
        public async Task<ActionResult<User>> Create(UserModel userModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _logger.LogInformation("Creating new user named: {0}", userModel.Firstname);

                    var userToCreate = _userMapper.Map(userModel);
                    userToCreate.CreatedAt = DateTime.Now;
                    userToCreate.UpdateAt = DateTime.Now;

                    var createdUser = await _userService.Create(userToCreate);

                    return CreatedAtRoute("GetUser", new { id = createdUser.Id }, userModel);
                }

                return BadRequest("User did not pass model validation");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating new user. User object: {0}", userModel);
                return BadRequest(ex);
            }
        }

        [HttpPut("{id:length(24)}")]
        public async Task<ActionResult<User>> Update(string id, UserModel userModel)
        {
            var userToUpdate = await _userService.Get(id);

            if (userToUpdate == null)
            {
                return NotFound();
            }

            _userMapper.Fill(userModel, userToUpdate);
            userToUpdate.UpdateAt = DateTime.Now;

            await _userService.Update(id, userToUpdate);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<ActionResult<User>> Delete(string id)
        {
            var user = await _userService.Get(id);

            if (user == null)
            {
                return NotFound();
            }

            await _userService.Remove(user);

            return NoContent();
        }
    }
}
