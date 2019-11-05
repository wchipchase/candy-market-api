using System;
using System.Collections.Generic;
using System.Linq;
using CandyMarket.Api.DataModels;
using CandyMarket.Api.Dtos;
using CandyMarket.Api.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CandyMarket.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CandyController : ControllerBase
    {
        private readonly ILogger<CandyController> _logger;
        private readonly ICandyRepository _repo;

        public CandyController(ILogger<CandyController> logger, ICandyRepository repo)
        {
            _logger = logger;
            _repo = repo;
        }

        [HttpGet]
        public IEnumerable<Candy> GetAll()
        {
            return _repo.GetAllCandy();
        }

        [HttpGet("{candyId}")]
        public Candy Get(int candyId)
        {
            var candy1 = _repo.GetAllCandy().FirstOrDefault(candy => candy.Id == candyId);
            return candy1;
        }

        [HttpPost]
        public void Add(AddCandyDto newCandy)
        {
            _repo.AddCandy(newCandy);
        }

        [HttpDelete("{candyIdToDelete}/eat")]
        public void Delete(int candyIdToDelete)
        {
            _repo.EatCandy(candyIdToDelete);
        }

        [HttpPut("{candyIdToDonate}/donate")]
        public void Donate(int candyIdToDonate)
        {
            // todo: make this endpoint behave less greedy and more honest
            _repo.EatCandy(candyIdToDonate);
        }

        //[HttpPost]
        public void Trade()
        {
            /**
             * flex goal: Trade Candy
             * Hint: you're going to need to add Users to your application
             */
        }
    }
}
