using System;
using TourOfHeroes.Api.Interfaces;

namespace TourOfHeroes.Api.Models
{
    public class HeroesDatabaseSettings: IHeroesDatabaseSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}