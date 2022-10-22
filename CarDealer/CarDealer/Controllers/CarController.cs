using CarDealer.DTO;
using CarDealer.Models;
using Microsoft.AspNetCore.Mvc;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace CarDealer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        [HttpGet("search")]
        public ActionResult<Car> Get([FromQuery] string brand, string model, int offer)
        {
            var deserializer = new DeserializerBuilder()
                .WithNamingConvention(CamelCaseNamingConvention.Instance)
                .Build();
            var carOffer = deserializer.Deserialize<Offer>(System.IO.File.ReadAllText($"Data/{brand}/{model}/{offer}.yml"));
            var carModel = deserializer.Deserialize<CarModel>(System.IO.File.ReadAllText($"Data/{brand}/{model}.yml"));
            var carBrand = deserializer.Deserialize<Brand>(System.IO.File.ReadAllText($"Data/{brand}.yml"));

            Car car = new Car(carBrand, carOffer, carModel);

            return car;
        }
    }
}
