using DuAnWebData.Data;
using DuAnWebData.Fake;
using DuAnWebData.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MailKit.Net.Smtp;

namespace DuAnWebAPI.Services
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreateAccounts : ControllerBase
    {
        private readonly DataContext dataContext;
        public CreateAccounts(DataContext data)
        {
            this.dataContext = data;
        }
        [HttpPost("DangKi")]
        public IActionResult Create([FromBody] CreateAccountUserCart cc)
        {
            var checkNameaccount = (from a in dataContext.Accountss select a).FirstOrDefault(x => x.AccountName == cc.acc.AccountName);
            
            if (checkNameaccount != null)
            {
                return BadRequest("Tên tài khoản này đã tồn tại");
            }
             else{
                try
                {
                    Accounts ac = new Accounts()
                    {
                        AccountId = Guid.NewGuid(),
                        AccountName = cc.acc.AccountName,
                        AccountPass = cc.acc.AccountPass,
                        RoleId = 2
                    };
                    dataContext.Accountss.Add(ac);
                    Guid iduser = Guid.NewGuid();
                    User user = new User()
                    {
                        AccountName = cc.acc.AccountName,
                        UserName = cc.us.UserName,
                        Sex = cc.us.Sex,
                        PhoneNumber = cc.us.PhoneNumber,
                        Email = cc.us.Email,
                        UserId = iduser,
                        Address = cc.us.Address,
                        DateTime = DateTime.Now
                    };
                    dataContext.Users.Add(user);
                    Cart car = new Cart()
                    {
                        IdCart = Guid.NewGuid(),
                        IdUser = iduser,
                        NgayTao = DateTime.Now,
                        NgayCapNhat = DateTime.Now
                    };
                    dataContext.Carts.Add(car);
                    dataContext.SaveChanges();
                    return Ok("Thanh Cong");
                }
                catch (Exception ex)
                {
                    return NotFound(ex);
                }
            }
           
        }

    }
}
