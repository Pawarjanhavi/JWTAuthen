using BasicApiAuthentication.Model;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace BasicApiAuthentication.Controllers
{
    [Route("api/[Controller")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserRepositry _userRepositry;

        public UserController(IUserRepositry userRepositry)
        {
            _userRepositry = userRepositry;

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            var User = await _userRepositry.GetAllUsers();

            return Ok(User);

        }

        [HttpPost]
        public async Task<ActionResult<User>> CreateUser([FromBody] User user )
        {
            try
            {
                var createdUser = await _userRepositry.AddUser(user);
                return CreatedAtAction(nameof(GetUsers), new { id = createdUser.Id }, createdUser);
            }
            catch (Exception ex)

            {
                return BadRequest(ex);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateUser(int id, [FromBody] User user)
        {
            if(id != user.Id)
            {
                return BadRequest("ID mismatch in the Url and body");

            }
            try
            {
                await _userRepositry.UpdateUser(user);
                return NoContent();
            }
            catch(Exception ex)
            {
                if(ex.Message == "User not found")
                {
                    return NotFound(ex.Message);
                }
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser(int id)
        {
            try
            {
                await _userRepositry.DeleteUser(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                if (ex.Message == "User not found.")
                {
                    return NotFound(ex.Message);
                }
                return BadRequest(ex.Message);
            }
        }





    }
}
