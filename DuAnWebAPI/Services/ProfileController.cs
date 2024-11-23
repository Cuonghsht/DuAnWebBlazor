using DuAnWebData.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DuAnWebAPI.Services
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly DataContext _data;
        public ProfileController( DataContext data)
        {
            this._data = data;
        }
        [HttpGet("Laythongtin")]
        public IActionResult ThongTinCaNhan(string nameAccount)
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
            if (thongTin != null)
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
