using DuAnWebAPI.Services.Buy;
using DuAnWebAPI.Services.Session;
using DuAnWebData.Data;
using DuAnWebData.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;

namespace DuAnWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartdetailController : ControllerBase
    {
        private readonly ICartcs _iCart;
        private readonly SessionLogin _Session;
        private readonly DataContext _data;
       

        public CartdetailController(ICartcs iCar, SessionLogin sss, DataContext data)
        {
            _iCart = iCar;
            _Session = sss;
            _data = data;
        }
        private string IdCart;
          
        [HttpGet("Getall")]
        public async Task<object> Get()
        {
            if (_Session.AccountName == "")
            {
                return NotFound();
            }
            var user = await _data.Users.FirstOrDefaultAsync(x => x.AccountName == _Session.AccountName);
            if (user == null)
            {
                return BadRequest("Nguoi dung khong ton tai");
            }
            var IdCart = await _data.Carts.FirstOrDefaultAsync(x => x.IdUser == user.UserId);
            if (IdCart == null)
            {
                return NotFound();
            }
            else
            {
                return _iCart.GetAllProduct(IdCart.IdCart);
            }

        }
        [HttpPost("Add")]
        public async Task<IActionResult> Add(CartDetail car)
        {
            if(car == null)
            {
                return BadRequest("Du lieu dang bi null");
            }
            else
            {
                var user = await _data.Users.FirstOrDefaultAsync(x => x.AccountName = _Session.GetAccountName);
                if(user == null)
                {
                    return BadRequest("He thong dang bi loi");
                }
                var idCart = await _data.Carts.FirstOrDefaultAsync(x=>x.IdUser=user.Id)
                 if (idCart == null)
                {
                    return NotFound("Tai khoan cua ban dang co van de");
                }

                await _iCart.BuyProduc(car);
                return Ok("Them thanh cong");
            }
        }
    }
}
