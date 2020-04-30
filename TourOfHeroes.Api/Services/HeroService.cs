using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Driver;
using TourOfHeroes.Api.Models;
using TourOfHeroes.Api.Interfaces;

namespace TourOfHeroes.Api.Services
{
    public class HeroService
    {
        private readonly IMongoCollection<HeroModel> _heroes;
        public HeroService(IHeroesDatabaseSettings settings) 
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _heroes = database.GetCollection<HeroModel>(settings.HeroesCollectionName);
        }

        public List<Hero> Get() => _heroes.Find(hero => true).Project(hero => new Hero() { Id = hero.HeroId, Name = hero.Name }).ToList();
    }
}