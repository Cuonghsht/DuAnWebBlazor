using DuAnWebData.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        [HttpGet("Login")]
        public IActionResult Login(string accountName, string passWord)

        {
            var dangNhap = _data.Accountss.FirstOrDefault(x => x.AccountName == accountName);
            if (dangNhap == null)
            {
                return BadRequest("Thông tin đăng nhập không hợp lệ ");
            }
            else if (dangNhap.AccountPass != passWord)
            {
                return BadRequest("Thông tin đăng nhập không hợp lệ ");
            }
            else
            {
                return Ok(dangNhap);
            }
        }
    }
}
