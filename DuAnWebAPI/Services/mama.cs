using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
            string code = new Random().Next(100000, 999999).ToString(); // Tạo mã ngẫu nhiên
            string subject = "Mã xác nhận của bạn";
            string body = $"<h1>Mã của bạn là: {code}</h1>";

            // Gửi email
            await _ie.SendEmailAsync(email, subject, body);

            // Trả về mã cho client
            return Ok(new { message = "Email sent successfully", code });
        }
    }
}
