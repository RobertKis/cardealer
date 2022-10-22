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
        [HttpGet("search/{brand}/{model}/{offer}")]
        public ActionResult<Car> Get([FromQuery] string brand, string model, int offerId)
        {
            var deserializer = new DeserializerBuilder()
                .WithNamingConvention(CamelCaseNamingConvention.Instance)
                .Build();
            var carOffer = deserializer.Deserialize<Offer>(System.IO.File.ReadAllText($"Data/{brand}/{model}/{offerId}.yml"));
            var carModel = deserializer.Deserialize<CarModel>(System.IO.File.ReadAllText($"Data/{brand}/{model}CarModel.yml"));
            var carBrand = deserializer.Deserialize<Brand>(System.IO.File.ReadAllText($"Data/{brand}.yml"));

            Car car = new Car(carBrand, carOffer, carModel);

            return car;
        }
    }
}
