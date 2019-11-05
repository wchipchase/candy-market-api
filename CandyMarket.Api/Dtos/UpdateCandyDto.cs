using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandyMarket.Api.Dtos
{
    public class UpdateCandyDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Flavor { get; set; }
        public double Price { get; set; }
    }
}
