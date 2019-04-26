using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ClinkedInSQL.Data;


namespace ClinkedInSQL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        readonly UserRepository _userRepository;

        public UsersController()
        {
            _userRepository = new UserRepository();
        }

        [HttpGet]
        public ActionResult GetAllUsers()
        {
            var users = _userRepository.GetAll();
            return Ok(users);
        }
    }
}