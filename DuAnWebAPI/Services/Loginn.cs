using DuAnWebData.Data;
using DuAnWebData.Fake;
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
        public string nameAcoount;
        [HttpGet("Login")]
        public async IActionResult Login(string accountName, string passWord)

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
                nameAcoount = dangNhap.AccountName;
            }
        }

        [HttpGet("Laythongtin")]
        public  IActionResult ThongTinCaNhan()
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
                            ).First(x => x.tenTk == nameAcoount);
            return Ok(thongTin);
        }

    }
}
