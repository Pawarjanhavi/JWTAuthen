using DemoIntrWebAPI.models;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Threading.Tasks;

namespace DemoIntrWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        [HttpPost]
        public async Task<IActionResult> CreateUser([FromForm] User user)
        {
            if (user.ProfilePic != null)
            {
                var uploadFolderPath = Path.Combine(Directory.GetCurrentDirectory(), "Uploads");
                if (!Directory.Exists(uploadFolderPath))
                {
                    Directory.CreateDirectory(uploadFolderPath);
                }

                var filepath = Path.Combine(uploadFolderPath, user.ProfilePic.FileName);

                using (var stream = new FileStream(filepath, FileMode.Create))
                {
                    await user.ProfilePic.CopyToAsync(stream);
                }

                var response = new
                {
                    Success = true,
                    Message = $"User {user.UserName} created with {user.Email}!",
                    ProfilePic = user.ProfilePic.FileName,
                    Code = StatusCodes.Status200OK
                };

                return Ok(response);
            }

            return BadRequest(ModelState);
        }
    }
}
