using Microsoft.AspNetCore.Mvc;

namespace CarDealer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        [HttpGet("search/{brand}/{model}/{offerId}")]
        public string Get(int id)
        {
            return "value";
        }
    }
}
