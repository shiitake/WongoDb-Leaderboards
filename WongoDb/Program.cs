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
            var svc = new MongoService("http://localhost", 27017);
            //add user
            //svc.Start(MongoServiceOptions.AddUser);

            //add score
            //svc.Start(MongoServiceOptions.AddHighScore);

            //add friend
            svc.Start(MongoServiceOptions.AddFriend);

            //view leaderboard
            //svc.Start(MongoServiceOptions.LeaderBoard);


            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();

        }





    }
}
