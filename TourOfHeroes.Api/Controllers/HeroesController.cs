using Microsoft.AspNetCore.Mvc;
using TourOfHeroes.Api.Models;
using TourOfHeroes.Api.Interfaces;
using TourOfHeroes.Api.Services;
using System.Collections.Generic;

namespace TourOfHeroes.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HeroesController: ControllerBase
    {
        private readonly HeroService _heroService;
        public HeroesController(HeroService service) 
        {
            _heroService = service;
        }

        [HttpGet]
        public ActionResult<List<Hero>> Get(string name = null) 
        {
            return _heroService.Get(name);
        }

        [HttpGet]
        [Route("{id}", Name = "GetHero")]
        public ActionResult<Hero> Get([FromRoute] long id) 
        {
            var hero = _heroService.Get(id);

            if (hero == null) 
            {
                return NotFound();
            }

            return hero;
        }

        [HttpPost]
        public ActionResult<Hero> Create([FromBody] Hero hero) 
        {
            Hero createdHero = _heroService.Create(hero);
            return CreatedAtRoute("GetHero", new { id = hero.Id }, createdHero);
        }

        [HttpPut]
        public IActionResult Update([FromBody] Hero hero)
        {
            Hero updatedHero = _heroService.Update(hero);
            if (updatedHero == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete([FromRoute] long id)
        {
            Hero deletedHero = _heroService.Delete(id);
            if (deletedHero == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}