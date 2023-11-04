using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvExtractor.Services.Interfaces;

namespace CsvExtractor.Services
{
    public class DbService : IDbService
    {
        public void SavePlayers(IEnumerable<Player> players)
        {
            using (var db = new PlayerContext())
            {
                db.Players.AddRange(players);
                db.SaveChanges();
            }
        }
    }
}
