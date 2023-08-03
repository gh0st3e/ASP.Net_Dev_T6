using Lab8.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace Lab8.Controllers
{
    [ApiController]
    [Route("/api/Lera")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly GenericRepository<User> _userRepository;

        public UserController(ILogger<UserController> logger, GenericRepository<User> genericRepository)
        {
            _logger = logger;
            _userRepository = genericRepository;
        }


        /// <summary>
        /// Get All Users
        /// </summary>
        /// <remarks>
        /// create 20.05.2022
        /// </remarks>
        [ProducesResponseType(typeof(IEnumerable<User>), 200)]
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return _userRepository.GetAll();
        }

        /// <summary>
        /// Add User
        /// </summary>
        /// <remarks>
        /// create 20.05.2022
        /// </remarks>
        /// <response code="200">User updated</response>
        /// <response code="400">User not added</response>
        [HttpPost]
        [ProducesResponseType(typeof(User), 200)]
        public User AddUser(User user)
        {
            try
            {
                _userRepository.Add(user);
                _userRepository.SaveChanges();
                return user;
            } catch
            {
                Response.StatusCode = 404;
            }

            return user;
        }

        /// <summary>
        /// Get User by Id
        /// </summary>
        /// <remarks>
        /// create 20.05.2022
        /// </remarks>
        /// <param name="id" example="101">The User id</param>
        /// <response code="200">User found</response>
        /// <response code="400">User not found</response>
        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(User), 200)]
        public User GetUser(int id)
        {
            return _userRepository.GetById(id);
        }

        /// <summary>
        /// Update User
        /// </summary>
        /// <remarks>
        /// create 20.05.2022
        /// </remarks>
        /// <response code="200">User found</response>
        /// <response code="400">User not found</response>
        [HttpPut]
        [ProducesResponseType(typeof(User), 200)]
        public User EditUser(User user)
        {
            _userRepository.Update(user);

            return user;
        }


        /// <summary>
        /// Delete User by Id
        /// </summary>
        /// <remarks>
        /// create 20.05.2022
        /// </remarks>
        /// <param name="id" example="101">The User id</param>
        /// <response code="200">User found</response>
        /// <response code="400">User not found</response>
        [HttpDelete("{id:int}")]
        [ProducesResponseType(typeof(User), 200)]
        public User DeleteUser(int id)
        {
            User user = _userRepository.GetById(id);
            _userRepository.Remove(user);
            _userRepository.SaveChanges();

            return user;
        }
    }
}
