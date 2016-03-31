using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using WongoDb.Helpers;

namespace WongoDb.Collections
{
    public static class PlayerAction
    {
        public static void CreateNewPlayer(string username, string first, string last, string email)
        {
            var alreadyExists = DoesPlayerExist(username);

            if (alreadyExists.Result)
            {
                Console.WriteLine("Player with that username already exists.");
            }
            else
            {
                var player = new Player
                {
                    EmailAddress = email,
                    FirstName = first,
                    LastName = last,
                    UserName = username,
                    GameCount = 0,
                    HighScore = new HighScore { Score = 0}
                };

                MongoClient client = new MongoClient();
                var db = client.GetDatabase("LeaderBoard");
                var collection = db.GetCollection<Player>("Player");
                collection.InsertOneAsync(player);
                Console.WriteLine("Created new player: " + player.UserName);
            }
        }

        public static async Task<bool>  DoesPlayerExist(string username)
        {
            MongoClient client = new MongoClient();
            var db = client.GetDatabase("LeaderBoard");
            var collection = db.GetCollection<Player>("Player");

            var playerList = await collection.Find(player => player.UserName == username).ToListAsync();
            return playerList.Any();
        }

        public static List<Player> GetPlayers()
        {
            MongoClient client = new MongoClient();
            var db = client.GetDatabase("LeaderBoard");
            var collection = db.GetCollection<Player>("Player");

            return collection.Find(_ => true).ToListAsync().Result;

        }

        public static async Task<Player> GetPlayerByUsername(string username)
        {
            MongoClient client = new MongoClient();
            var db = client.GetDatabase("LeaderBoard");
            var collection = db.GetCollection<Player>("Player");

            var player = await collection.Find(p => p.UserName == username).ToListAsync();
            return player.Any() ? player.First(): new Player();

        }

        public static void UpdatePlayerHighScore(Player player, int score)
        {
            MongoClient client = new MongoClient();
            var db = client.GetDatabase("LeaderBoard");
            var playerCollection = db.GetCollection<Player>("Player");
            player.HighScore.Score = score;
            player.HighScore.DatePlayed = DateTime.Now;
            player.GameCount++;
            playerCollection.SaveAsync(player).Wait();
        }

        public static async Task<string> GetPlayerUserName(ObjectId playerId)
        {
            MongoClient client = new MongoClient();
            var db = client.GetDatabase("LeaderBoard");
            var collection = db.GetCollection<Player>("Player");

            var player = await collection.Find(p => p.Id == playerId).ToListAsync();
            return player.Any() ? player.First().UserName : "Unknown";
        }

        public static void AddPlayerFriend(Player player, string friend)
        {
            MongoClient client = new MongoClient();
            var db = client.GetDatabase("LeaderBoard");
            var playerCollection = db.GetCollection<Player>("Player");
            var newFriend = new Friend
            {
                UserName = friend,
                DateAdded = DateTime.Now
            };
            if (player.FriendList == null)
            {
                player.FriendList = new List<Friend>();
            }
            player.FriendList.Add(newFriend);
            playerCollection.SaveAsync(player).Wait();
        }
    }
}
