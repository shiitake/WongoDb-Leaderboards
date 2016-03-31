using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace WongoDb.Collections
{
    public static class LeaderBoardAction
    {
        public static void GenerateLeaderBoardGlobal()
        {
            MongoClient client = new MongoClient();
            var db = client.GetDatabase("LeaderBoard");
            var collection = db.GetCollection<Player>("Player");
            var scoreList = collection.Find(_ => true)
                .SortByDescending(x => x.HighScore.Score)
                .Limit(10)
                .ToListAsync().Result;

            Console.WriteLine("{0,-10}{1,-25}{2,-15}", "Score","Username","Date");
            Console.WriteLine("{0}{0}{0}{0}{0}{0}", "==========");
            foreach (var score in scoreList)
            {
                Console.WriteLine("{0,-10}{1,-25}{2,-15}", score.HighScore.Score, score.UserName, score.HighScore.DatePlayed);
            }
        }

        public static void GenerateLeaderBoardByPlayer(Player player)
        {
            
        }
    }
}
