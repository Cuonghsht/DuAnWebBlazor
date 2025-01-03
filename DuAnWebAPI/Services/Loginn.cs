using DuAnWebAPI.Services.Login;
using DuAnWebAPI.Services.Session;
using DuAnWebData.Data;
using DuAnWebData.Fake;
using DuAnWebData.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DuAnWebAPI.Services
{
    [Route("api/[controller]")]
    [ApiController]
    public class Loginn : ControllerBase
    {
        private readonly DataContext _data;
        private readonly SessionService _sessionService;
        public Loginn(DataContext data, SessionService sessionService)
        {
            _data = data;
            _sessionService = sessionService;
        }
        [HttpPost("Login")]
        public IActionResult Login([FromBody]LoginRequest res)

        {
            var dangNhap = _data.Accountss.FirstOrDefault(x => x.AccountName == res.AccountName);
            Console.WriteLine("hehe");
            if (dangNhap == null)
            {
                return NotFound("Thông tin đăng nhập không hợp lệ ");
            }
            else if (dangNhap.AccountPass != res.AccountPass)
            {
                return NotFound("Thông tin đăng nhập không hợp lệ ");
            }
            else
            {
               
                string nameAccount = HttpContext.Session.GetString("AcountName");
                var userid = _data.Users.FirstOrDefault(x => x.AccountName == _sessionService.AccountName);
                var cartid = _data.Carts.FirstOrDefault(x => x.IdUser == userid.UserId);
                HttpContext.Session.SetString("IdCartSession", cartid.IdCart.ToString());
                return Ok(dangNhap);
            }
        }
    }
}
