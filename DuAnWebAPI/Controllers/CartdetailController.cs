using DuAnWebAPI.Services.Buy;
using DuAnWebAPI.Services.Session;
using DuAnWebData.Data;
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
        
        public CartdetailController(ICartcs iCar,SessionLogin sss,DataContext data)
        {
            _iCart = iCar;
            _Session = sss;
            _data = data;
        }

        [HttpGet("Getall")]
        public async Task<object> Get()
        {
            var user =  _data.Users.FirstOrDefault(x=>x.AccountName==_Session.AccountName);
            var IdCart = _data.Carts.FirstOrDefaultAsync(x=>x.IdUser==user.UserId);
            if (IdCart == null)
            {
                return NotFound();
            }
            else
            {
                
                return  _iCart.GetAllProduct(IdCart.Result.IdCart);
            }
            
        }
    }
}
