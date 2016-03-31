using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace WongoDb.Collections
{
    public class LeaderBoard : IIdentified
    {
        public ObjectId Id { get; set; }
        public List<Score> ScoreList { get; set; }
    }

    public class Score : HighScore
    {
        public string UserName { get; set; }
    }
}
