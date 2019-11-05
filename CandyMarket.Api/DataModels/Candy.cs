using System;

namespace CandyMarket.Api.DataModels
{
    public class Candy
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Flavor { get; set; }
        public double Price { get; set; }
        public bool isDonated { get; set; }
    }
}
