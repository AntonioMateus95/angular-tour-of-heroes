namespace TourOfHeroes.Api.Interfaces
{
    public interface IHeroesDatabaseSettings
    {
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}