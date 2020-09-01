using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task1.Data;
using Task1.Entities;

namespace Task1.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly IMongoCollection<User> _user;
        protected readonly IMongoCollection<Order> _order;
        protected readonly IMongoCollection<BsonDocument> _orderCollection;


        private readonly MongoDbContext _context;

        public BaseRepository()
        {
            _context = new MongoDbContext();
            _user = _context.User;
            _order = _context.Order;
            _orderCollection = _context.OrderCollection;
        }
    }
}
