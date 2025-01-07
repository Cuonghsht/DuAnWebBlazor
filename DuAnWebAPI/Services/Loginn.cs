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
        private readonly SessionLogin _session;
        public Loginn(DataContext data, SessionLogin session)
        {
            _data = data;
            _session = session;
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody]LoginRequest res)
        {
            var dangNhap = await _data.Accountss.Where(x=>x.AccountName == res.AccountName && x.AccountPass == res.AccountPass).Select(x => new { x.AccountName,x.AccountId,x.RoleId }).FirstOrDefaultAsync();
            Console.WriteLine("hehe");
            if (dangNhap == null)
            {
                return NotFound("Thông tin đăng nhập không hợp lệ ");
            }
            else
            {
                _session.SetaccountName(dangNhap.AccountName);
                _session.SetAccountId(dangNhap.AccountId);
                return  Ok(dangNhap);
            }
        }
    }
}
