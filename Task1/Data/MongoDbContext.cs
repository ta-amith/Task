using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using Task1.Entities;
using Task1.Interfaces;

namespace Task1.Data
{
    public class MongoDbContext
    {
        
        IMongoDatabase database = null;
        IMongoCollection<BsonDocument> orderCollection = null;
        public MongoDbContext()
        {
            var client = new MongoClient(Resource.ConnectionString);
            database = client.GetDatabase(Resource.DatabaseName);

        }

        public IMongoCollection<BsonDocument> OrderCollection
        {
            get
            {
                return database.GetCollection<BsonDocument>(Resource.OrderCollection); ;
            }
        }

        public IMongoCollection<User> User
        {
            get
            {
                return database.GetCollection<User>(Resource.UserCollection);
            }
        }

        public IMongoCollection<Order> Order
        {
            get
            {
                return database.GetCollection<Order>(Resource.OrderCollection);
            }
        }
    }
}
