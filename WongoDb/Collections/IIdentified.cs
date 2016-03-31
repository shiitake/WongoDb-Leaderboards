using System.Security.Cryptography.X509Certificates;
using MongoDB.Bson;

namespace WongoDb.Collections
{
    public interface IIdentified
    {
         ObjectId Id { get; }
    }
}