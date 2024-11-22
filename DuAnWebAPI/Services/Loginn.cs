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
        [HttpGet("Login")]
        public async  Task< IActionResult> Login(string accountName, string passWord)

        {
            var dangNhap =  await _data.Accountss.FirstOrDefaultAsync(x => x.AccountName == accountName);
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

                return  Ok(dangNhap);
            }
        }

        [HttpGet("Laythongtin")]
        public   IActionResult ThongTinCaNhan(string nameAccount)
        {
            var thongTin = (from a in _data.Accountss
                            join b in _data.Users on a.AccountName equals b.AccountName
                            join c in _data.Carts on b.UserId equals c.IdUser
                            select new 
                            {
                                tenTk = a.AccountName,
                                Email = b.Email,
                                SDT = b.PhoneNumber,
                                Sex = b.Sex,
                                DiaChi = b.Address,
                                IdGiohang = c.IdCart,
                                NameUser = b.UserName,

                            }
                            ).FirstOrDefault(x => x.tenTk == nameAccount);
            if(thongTin != null)
            {
                return Ok(thongTin);

            }
            else
            {
                return NotFound();
            }
        }

    }
}
