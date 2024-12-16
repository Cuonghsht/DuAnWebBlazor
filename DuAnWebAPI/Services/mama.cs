using DuAnWebAPI.Services.OtpEmail;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Iemail = DuAnWebAPI.Services.Res.Iemail;

namespace DuAnWebAPI.Services
{
    [Route("api/[controller]")]
    [ApiController]
    public class mama : ControllerBase
    {
        private readonly Iemail _ie;
        public mama(Iemail ic)
        {
            _ie = ic;
        }
        [HttpPost("send-code")]
        public async Task<IActionResult> SendCode(string email)
        {
            string code = new Random().Next(100000, 999999).ToString(); 
            string subject = "Mã xác nhận của bạn";
            string body = $"<h1>Mã của bạn là: {code}</h1>";
            await _ie.SendEmailAsync(email, subject, body);
            return Ok(new { message = "Email sent successfully", code });
        }
    }
}
