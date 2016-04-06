# WongoDb-Leaderboards
A small console app that uses MongoDb to store player and leaderboard data. 

### There are a few ways to run the project: 

1. If you've got MongoDb installed locally you can just run the program (it automatically points to localhost on port 27017)

2. If you have Vagrant and Virtualbox installed you can just up a new machine: `vagrant up`
3. You can specify a host, port, username and password through the command line.
```
WongoDb -server <server> -p <port> -database <database> -user <username> -pw <password>
```

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
 * set the MongoDB host/port
 * use MongoDB database authentication

### Todo: 
* add friend leaderboards
