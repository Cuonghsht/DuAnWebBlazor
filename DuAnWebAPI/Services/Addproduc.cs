using DuAnWebData.Data;
using DuAnWebData.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Framework;

namespace DuAnWebAPI.Services
{
    [Route("api/[controller]")]
    [ApiController]
    public class Addproduc : ControllerBase
    {
        private readonly DataContext _data;
        public Addproduc(DataContext data)
        {
            this._data = data;
        }
        [HttpPost("add")]
        public IActionResult Add([FromBody] Product pr)
        {
            try
            {
                pr.ProductId = new Guid();
                _data.Products.Add(pr);
                _data.SaveChanges();
                return Ok("Them thanh cong");
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
