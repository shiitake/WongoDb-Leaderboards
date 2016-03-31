# WongoDb-Leaderboards
A small console app that uses MongoDb to store player and leaderboard data. 

To run this locally you will need to have MongoDb running locally on the default port 27017. 

The player documents stored in MongoDb have fairly simple schema.

```json
{
    "_id" : ObjectId("56fd3ebbc08a4740504cf261"),
    "UserName" : "_foobar",
    "FirstName" : "Foo",
    "LastName" : "Bar",
    "EmailAddress" : "foo@wongodb-leaderboards.bar",
    "FriendList" : [ 
        {
            "UserName" : "I_am_Awesome",
            "DateAdded" : ISODate("2016-03-31T20:22:31.956Z")
        }, 
        {
            "UserName" : "JimmyD",
            "DateAdded" : ISODate("2016-03-31T20:23:12.373Z")
        }
    ],
    "GameCount" : 3,
    "HighScore" : {
        "Score" : 120,
        "DatePlayed" : ISODate("2016-03-31T14:59:00.000Z")
    }
}
```

### Right now you can do the following: 
 * add players
 * update player high scores
 * add friends
 * view the global leaderboard

### Todo: 
* add the ability to change the mongoDB host/port
* add friend leaderboards
