using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Driver;
using TourOfHeroes.Api.Models;
using TourOfHeroes.Api.Interfaces;
using MongoDB.Bson;

namespace TourOfHeroes.Api.Services
{
    public class HeroService
    {
        private readonly IMongoCollection<Hero> _heroes;
        private readonly IMongoCollection<Counter> _counters;
        public HeroService(IHeroesDatabaseSettings settings) 
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _heroes = database.GetCollection<Hero>("heroes");
            _counters = database.GetCollection<Counter>("counters");
        }

        private long GetNextSequenceValue() 
        {
            var update = Builders<Counter>.Update.Inc(c => c.SequenceValue, 1);
            var options = new FindOneAndUpdateOptions<Counter>() { IsUpsert = false, ReturnDocument = ReturnDocument.After };
            var updatedCounter = _counters.FindOneAndUpdate<Counter>(counter => counter.TableName.Equals("heroes"), update, options: options);
            return updatedCounter.SequenceValue;
        }

        public Hero Get(long id) 
        {
            return _heroes.Find(hero => hero.Id == id).FirstOrDefault();
        }

        public List<Hero> Get(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return _heroes.Find(hero => true).ToList();
            }
            else
            {
                return _heroes.Find(hero => hero.Name.ToLower().Contains(name.ToLower())).ToList();
            }
        }
        
        public Hero Create(Hero hero) 
        {
            hero.Id = GetNextSequenceValue();
            _heroes.InsertOne(hero);
            return hero;
        }

        public Hero Update(Hero hero) 
        {
            long id = hero.Id;
            return _heroes.FindOneAndReplace(hero => hero.Id == id, hero);
        }

        public Hero Delete(long id) 
        {
            return _heroes.FindOneAndDelete(hero => hero.Id == id);        
        }
    }
}