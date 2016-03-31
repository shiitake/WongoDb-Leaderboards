using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using WongoDb.Collections;

namespace WongoDb.Helpers
{
    public static class MongoDbHelpers
    {
        //this extension method and interface is used for updating documents asynchronously
        public static async Task<ReplaceOneResult> SaveAsync<T>(
            this IMongoCollection<T> collection, T entity) where T : IIdentified
        {
            return await collection.ReplaceOneAsync(i => i.Id == entity.Id,
                entity,
                new UpdateOptions { IsUpsert = true });
        }
    }
}
