using DuAnWebAPI.Services.ProductDL;
using DuAnWebData.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DuAnWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly Iproduct iproduct;
        public ProductController(Iproduct _iproduct)
        {
            iproduct = _iproduct;
        }

        [HttpGet("GetallProduct")]

        public async Task<object> Getall(Product pr, int page , int pagesize)
        {
           return await iproduct.GetAllProduct(pr, page, pagesize);
        }

        [HttpPost]
        public async Task<IActionResult> Addproduct(Product pro, Guid idUser)
        {
            if (pro == null || idUser == null)
            {
                return NotFound("Dữ liệu không đầy đủ ");
            }
            else
            {
                await iproduct.AddProduct(pro, idUser);
                return Ok();
            }

        }
    }
}
