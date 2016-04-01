using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using WongoDb.Collections;

namespace WongoDb.Services
{
    public class MongoService
    {
        private PlayerAction _player;
        private LeaderBoardAction _leader;
        private MongoClientSettings _settings;

        public MongoService(string host, int port, string database, string username = "", string password = "")
        {
            _settings = new MongoClientSettings();
            _settings.Server = new MongoServerAddress(host, port);

            if (!string.IsNullOrWhiteSpace(username) && !string.IsNullOrWhiteSpace(password))
            {
                var credential = MongoCredential.CreateCredential(database, username, password);
                _settings.Credentials = new[] {credential};
            }

            _player = new PlayerAction(_settings, database);
            _leader = new LeaderBoardAction(_settings, database);
        }

        public void Start(MongoServiceOptions option)
        {
            switch (option)
            {
                case MongoServiceOptions.AddUser:
                    AddUser();
                    break;
                case MongoServiceOptions.AddHighScore:
                    AddGame();
                    break;
                case MongoServiceOptions.AddFriend:
                    AddFriend();
                    break;
                case MongoServiceOptions.LeaderBoard:
                default:
                    DisplayLeaderBoard();
                    break;
            }   
        }

        private void AddUser()
        {
            Console.WriteLine("Please enter username: ");
            var username = Console.ReadLine();
            Console.WriteLine("Please enter first name: ");
            var first = Console.ReadLine();
            Console.WriteLine("Please enter last name: ");
            var last = Console.ReadLine();
            Console.WriteLine("Please enter email: ");
            var email = Console.ReadLine();
            //Todo: Add some sort of validation

            Console.WriteLine("Creating new player.");
            _player.CreateNewPlayer(username, first, last, email);
        }

        private void AddGame()
        {
            Console.WriteLine("Please enter username: ");
            var username = Console.ReadLine();

            Console.WriteLine("Please enter your new score: ");
            var score = 0;
            var validScore = int.TryParse(Console.ReadLine(), out score);
            if (!validScore)
            {
                Console.WriteLine("You entered an invalid score.");
            }
            //get player
            var pa = _player.GetPlayerByUsername(username);
            
            if (score < pa.Result.HighScore.Score)
            {
                Console.WriteLine(string.Format("{0} isn't high enough to beat your current high score of {1}. Keep trying!", score, pa.Result.HighScore.Score));
            }
            else
            {
                Console.WriteLine("Congrats on your new high score. You're really moving up the leaderboards.");
                _player.UpdatePlayerHighScore(pa.Result, score);
            }

        }

        private void AddFriend()
        {
            Console.WriteLine("Please enter username: ");
            var username = Console.ReadLine();
            Console.WriteLine("Please enter the name of the friend you would like to add: ");
            var friend = Console.ReadLine();
            var isValidPlayer = _player.DoesPlayerExist(friend);
            if (!isValidPlayer.Result)
            {
                Console.WriteLine("We can't find a player by that name.");
            }
            else
            {
                Console.WriteLine("Congratulations, You've got a new friend");
                var pa = _player.GetPlayerByUsername(username);
                _player.AddPlayerFriend(pa.Result, friend);
            }
        }

        private void DisplayLeaderBoard()
        {
            Console.WriteLine("Enter your username or press enter for global leaderboards");
            var userName = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(userName))
            {
                Console.WriteLine("Printing global leaderboards");
                _leader.GenerateLeaderBoardGlobal();
            }
            else
            {
                Console.WriteLine("Printing leaderboards for {0}", userName);
                var pa = _player.GetPlayerByUsername(userName);
                _leader.GenerateLeaderBoardByPlayer(pa.Result);
            }
        }

    }

    public enum MongoServiceOptions
    {
        AddUser = 1,
        AddHighScore = 2,
        LeaderBoard = 3,
        AddFriend = 4
    }
}
