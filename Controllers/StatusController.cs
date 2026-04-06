using Microsoft.AspNetCore.Mvc;

namespace StatusApiTeste.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StatusController : Controller
    {
        [HttpGet]
        public IActionResult GetStatus()
        {
            // Aqui simulamos a resposta que o seu StatusCard espera
            return Ok(new
            {
                status = "Operational",
                uptime = "99.9%",
                lastCheck = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                environment = "Production"
            });
        }
    }
}
