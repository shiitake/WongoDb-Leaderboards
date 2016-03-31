using System;
using System.Collections.Generic;
using MongoDB.Bson;

namespace WongoDb.Collections
{
    public class Player : IIdentified
    {
        public ObjectId Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public List<Friend> FriendList { get; set; }
        public int GameCount { get; set; }
        public HighScore HighScore { get; set; }
    }

    public class Friend
    {
        public string UserName { get; set; }
        public DateTime DateAdded { get; set; }
    }

    public class HighScore
    {
        public int Score { get; set; }
        public DateTime DatePlayed { get; set; }

    }


}
