using CarDealer.Models;

namespace CarDealer.DTO
{
    public class Car
    {
        public Car(Brand brand, Offer offer, CarModel model)
        {
            this.hp = offer.hp;
            this.Manufacturer = brand.Manufacturer;
            this.Model = model.Model;
            this.Color = offer.Color;
            this.Engine = offer.Engine;
            this.Fuel = offer.Fuel;
        }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public string? hp { get; set; }
        public decimal Engine { get; set; }
        public string? Fuel { get; set; }
    }
}
