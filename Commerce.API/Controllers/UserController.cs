using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Commerce.Data.Models;
using Commerce.Data.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Commerce.API.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserService _userService;

        public UserController(ILogger<UserController> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> Get()
        {
            return new ObjectResult(await _userService.GetAll());
        }

        [HttpGet("{id:length(24)}", Name = "GetUser")]
        public async Task<ActionResult<User>> Get(long id)
        {
            var user = await _userService.Get(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        [HttpPost]
        public async Task<ActionResult<User>> Create(User user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _logger.LogInformation("Creating new user named: {0}", user.Firstname);

                    user.Id = await _userService.GetNextId();
                    var createdUser = await _userService.Create(user);

                    return CreatedAtRoute("GetUser", new { id = user.InternalId }, user);
                }

                return BadRequest("User did not pass model validation");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating new user. User object: {0}", user);
                return BadRequest(ex);
            }
        }
    }
}
