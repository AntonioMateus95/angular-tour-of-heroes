using Microsoft.AspNetCore.Mvc;
using TourOfHeroes.Api.Models;
using TourOfHeroes.Api.Interfaces;
using TourOfHeroes.Api.Services;
using System.Collections.Generic;

namespace TourOfHeroes.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HeroesController
    {
        private readonly HeroService _heroService;
        public HeroesController(HeroService service) 
        {
            _heroService = service;
        }

        [HttpGet]
        public ActionResult<List<Hero>> Get() 
        {
            return _heroService.Get();
        }
    }
}