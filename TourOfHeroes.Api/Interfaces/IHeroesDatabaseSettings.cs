namespace TourOfHeroes.Api.Interfaces
{
    public interface IHeroesDatabaseSettings
    {
        string HeroesCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}