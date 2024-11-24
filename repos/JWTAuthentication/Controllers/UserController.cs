using JWTAuthentication.Data;
using JWTAuthentication.Models;
using Microsoft.AspNetCore.Mvc;



namespace JWTAuthentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
       
            readonly ApplicationDBContext _db;
            public UserController(ApplicationDBContext db)
            {
                _db = db;
            }

            [HttpGet]
            public IActionResult GetUsers()
            {
                List<User> usersList;
                usersList = _db.Set<User>().ToList();
                if (usersList.Count < 1) return NotFound();

                return Ok(usersList);
            }

            [Route("Register")]
            [HttpPost]
            [ProducesResponseType(StatusCodes.Status201Created)]
            public IActionResult CreateUser([FromBody] User user)
            {
                _db.Add<User>(user);
                _db.SaveChanges();

                return CreatedAtAction("GetUsers", new User() { UserId = user.UserId }, user);
            }

            [Route("update")]
            [HttpPut]
            public IActionResult UpdateUser([FromBody] User user, int id)
            {
                var userFound = _db.Find<User>(id);
                if (userFound == null) return NotFound();

                userFound.UserName = user.UserName;
                userFound.Email = user.Email;
                userFound.Password = user.Password;
                userFound.RoleType = user.RoleType;

                var updatedUser = userFound;
                _db.Update<User>(updatedUser);
                _db.SaveChanges();

                return Ok();
            }

            [Route("delete")]
            [HttpDelete]
            [ProducesResponseType(StatusCodes.Status404NotFound)]
            public IActionResult DeleteUser(int id)
            {
                var userFound = _db.Find<User>(id);
                if (userFound == null) return NotFound();
                _db.Remove<User>(userFound);
                _db.SaveChanges();

                return Ok(userFound);
            }
    }
}

