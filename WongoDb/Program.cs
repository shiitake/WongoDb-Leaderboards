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

            var svc = new MongoService("http://localhost", 27017);
            switch (args[0])
            {
                case "-new":
                case "-n":
                    svc.Start(MongoServiceOptions.AddUser);
                    break;
                case "-friend":
                case "-f":
                    svc.Start(MongoServiceOptions.AddFriend);
                    break;
                case "-score":
                case "-s":
                    svc.Start(MongoServiceOptions.AddHighScore);
                    break;
                case "-leader":
                case "-l":
                    svc.Start(MongoServiceOptions.LeaderBoard);
                    break;
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();

        }

        public static void PrintHelp()
        {
            Console.WriteLine("WongoDB.exe will let you add players, friends, and new highscores. It uses MongoDB running on localhost, port 27017");
            Console.WriteLine();
            Console.WriteLine("Usage:" + "\t" + "WongoDB.exe [-n] [-f] [-s] [-l]");
            Console.WriteLine();
            Console.WriteLine("Options:");
            Console.WriteLine("\t-new, -n" + "\t\t" + "Add a new Player");
            Console.WriteLine("\t-friend, -f" + "\t\t" + "Add an existing player to your friend list");
            Console.WriteLine("\t-score, -s" + "\t\t" + "Update your high score");
            Console.WriteLine("\t-leaderboard, -l" + "\t\t" + "View the leaderboards");
        }





    }
}
