using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Timesheets.API.Authentication.Controllers
{
    [Authorize] 
    [Route("api/[controller]")]
    [ApiController]
    public sealed class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        

        public UsersController(IUserService userService)
        {
            _userService = userService;
            
        }

        //[HttpGet]
        //public async Task<<IActionResult>User> GetAll()
        //{
        //    var res = await _repository;
        //    return Ok(res);
        //}



        //[HttpPost]
        //public async Task<ActionResult> Create([FromBody]User newUser)
        //{
        //    await _repository.Add(newUser);
        //    return NoContent();
        //}

        //[HttpPut]
        //public async Task<ActionResult> Update([FromBody] User newUser)
        //{
        //    await _repository.Update(user);
        //    return NoContent();
        //}

        //[HttpDelete]
        //[Route("{userId}")]
        //public async Task<IActionResult> Delete(int userId)
        //{
        //    await _repository.Delete(userId);
        //    return NoContent();
        //}





        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromQuery] string user, string password)
        {
            var token = _userService.Authenticate(user, password);

            if (token is null)
            {
                return BadRequest(new { message = "Username or password is incorrect" });
            }
            SetTokenCookie(token.RefreshToken);
            return Ok(token);
        }

        //[AllowAnonymous]                              // возврат string
        //[HttpPost("refresh-token")]
        //public IActionResult Refresh()
        //{
        //    string oldRefreshToken = Request.Cookies["refreshToken"];
        //    string newRefreshToken = _userService.RefreshToken(oldRefreshToken);

        //    if (string.IsNullOrWhiteSpace(newRefreshToken))
        //    {
        //        return Unauthorized(new {message="Invalid token"});
        //    }
        //    SetTokenCookie(newRefreshToken);
        //    return Ok(newRefreshToken);
        //}


        [AllowAnonymous]
        [HttpPost("refresh-token")]
        public IActionResult Refresh()
        {
            string oldRefreshToken = Request.Cookies["refreshToken"];
            var newRefreshTokens = _userService.RefreshToken(oldRefreshToken);

            
            SetTokenCookie(newRefreshTokens.RefreshToken);
            return Ok(newRefreshTokens);
        }

        private void SetTokenCookie(string token)
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = DateTimeOffset.UtcNow.AddDays(7)
            };
            Response.Cookies.Append("refreshToken", token, cookieOptions);

        }

    }

}
