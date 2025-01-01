using DuAnWebAPI.Services.Login;
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
        public Loginn(DataContext data)
        {
            _data = data;
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
                return Ok(dangNhap);
            }
        }
    }
}
