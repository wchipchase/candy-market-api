﻿namespace CandyMarket.Api.Dtos
{
    public class AddCandyDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Flavor { get; set; }
        public double Price { get; set; }
    }
}