using Microsoft.AspNetCore.Mvc;

namespace UniversitySystem.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
       [HttpPost]
       public async Task<IActionResult> TeacherRegister()
       {
            return StatusCode(StatusCodes.Status201Created);
       }
    }
}