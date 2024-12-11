
using DuAnWebData.Data;
using DuAnWebData.Model;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
namespace DuAnWebAPI.Services
{
    [Route("api/[controller]")]
    [ApiController]
    public class DangKiShop : ControllerBase
    {
        private readonly DataContext _dataContext;
        public DangKiShop(DataContext data)
        {
            this._dataContext = data;
        }
        [HttpPatch("DKShop")]
        public IActionResult Update(string Accouname)
        {
            if (string.IsNullOrEmpty(Accouname))
            {
                return BadRequest("Tài khoản không hợp lệ ");
            }
            var account = _dataContext.Accountss.FirstOrDefault(x=>x.AccountName== Accouname);
            try
            {
                account.RoleId = 1; 
                _dataContext.SaveChanges();
                return Ok(account);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
            
        }

    }
}
