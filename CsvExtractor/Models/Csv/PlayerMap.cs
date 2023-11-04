using CsvHelper.Configuration;

namespace CsvExtractor.Models.Csv
{
    public class PlayerMap : ClassMap<Player>
    {
        public PlayerMap()
        {
            Map(m => m.FName).Name("FName");
            Map(m => m.LName).Name("LName");
            Map(m => m.Overall).Name("Overall");
            Map(m => m.Rarity).Name("Rarity");
            Map(m => m.Position).Name("Position");
            Map(m => m.Team).Name("Team");
            Map(m => m.Event).Name("Event");

            Map(m => m.Id).Ignore();
        }
    }
}
