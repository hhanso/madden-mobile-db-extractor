namespace CsvExtractor.Services.Interfaces
{
    public interface IDbService
    {
        void SavePlayers(IEnumerable<Player> players);
    }
}