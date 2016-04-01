using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using WongoDb.Collections;
using WongoDb.Services;

namespace WongoDb
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                PrintHelp();
                return;
            }
            var host = "localhost";
            var port = 27017;
            var database = "LeaderBoard";
            var username = "";
            var password = "";
            MongoServiceOptions action = MongoServiceOptions.LeaderBoard;
            var validPort = true;

            for (var i = 0; i < args.Length; i++)
            {
                switch (args[i].ToLower())
                {
                    case "-new":
                    case "-n":
                        action = MongoServiceOptions.AddUser;
                        break;
                    case "-friend":
                    case "-f":
                        action = MongoServiceOptions.AddFriend;
                        break;
                    case "-highscore":
                    case "-h":
                        action = MongoServiceOptions.AddHighScore;
                        break;
                    case "-leader":
                    case "-l":
                        action = MongoServiceOptions.LeaderBoard;
                        break;
                    case "-server":
                    case "-s":
                        host = args[i + 1];
                        break;
                    case "-port":
                    case "-p":
                        validPort = int.TryParse(args[i + 1], out port);
                        break;
                    case "-database":
                    case "-d":
                        database = args[i + 1];
                        break;
                    case "-username":
                    case "-u":
                        username = args[i + 1];
                        break;
                    case "-password":
                    case "-pw":
                        password = args[i + 1];
                        break;
                    case "-?":
                    case "-help":
                        PrintHelp();
                        break;
                }
            }

            if (!validPort)
            {
                Console.WriteLine("Please input a valid port number");
                return;
            }
            var svc = new MongoService(host, port, database, username, password);
            svc.Start(action);

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();

        }

        public static void PrintHelp()
        {
            Console.WriteLine("WongoDB.exe will let you add players, friends, and new highscores. It defaults to MongoDB running on localhost, port 27017 but you can configure manually");Console.WriteLine();
            Console.WriteLine("Usage:" + "\t" + "WongoDB.exe [-n] [-f] [-h] [-l] [-s] [-p] [d] [u] [p]");
            Console.WriteLine();
            Console.WriteLine("Options:");
            Console.WriteLine("\t-new, -n" + "\t\t" + "Add a new Player");
            Console.WriteLine("\t-friend, -f" + "\t\t" + "Add an existing player to your friend list");
            Console.WriteLine("\t-highscore, -h" + "\t\t" + "Update your high score");
            Console.WriteLine("\t-leaderboard, -l" + "\t\t" + "View the leaderboards");
            Console.WriteLine("\t-server, -s" + "\t\t" + "Set the MongoDB server (default localhost)");
            Console.WriteLine("\t-port, -p" + "\t\t" + "Set the MongoDB port (default 27017)");
            Console.WriteLine("\t-database, -d" + "\t\t" + "Set the MongoDB database (default LeaderBoard)");
            Console.WriteLine("\t-user, -u" + "\t\t" + "Set username (default: not required)");
            Console.WriteLine("\t-password, -pw" + "\t\t" + "Set password (default: not required)");
        }





    }
}
