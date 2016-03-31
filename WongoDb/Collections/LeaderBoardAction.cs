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
        public static async void GenerateLeaderBoardGlobal()
        {
            MongoClient client = new MongoClient();
            var db = client.GetDatabase("LeaderBoard");
            var collection = db.GetCollection<Player>("Player");
            var scoreList = await collection.Find(_ => true)
                .SortByDescending(x => x.HighScore.Score)
                .Limit(10)
                .ToListAsync();

            Console.WriteLine("Global Leaderboard: ");
            Console.WriteLine("Score\t\tUsername\t\tDate");
            foreach (var score in scoreList)
            {
                Console.WriteLine("{0}\t\t{1}\t\t{2}", score.HighScore.Score, score.UserName, score.HighScore.DatePlayed);
            }
        }

        public static void GenerateLeaderBoardByPlayer(Player player)
        {
            
        }
    }
}
