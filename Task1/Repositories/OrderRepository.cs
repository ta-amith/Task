using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1.Entities;
using Task1.Interfaces;

namespace Task1.Repositories
{
    public class OrderRepository : BaseRepository, IOrderRepository
    {
        public OrderRepository()
        {

        }
        public async Task<Order> CreateAsync(Order order)
        {
            double totalCost = 0;

            order.Products.ForEach(x => totalCost = totalCost + (x.Price * x.Quantity));

            order.Payment.TotalCost = totalCost;
            await _order.InsertOneAsync(order);
            return order;
        }

        public async Task<Order> GetOrder(string id)
        {
            return await _order.Find(order => order.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IReadOnlyList<Order>> GetOrders()
        {
           

            return await _order.Find(order => true).SortByDescending(x => x.OrderDate).ToListAsync();
        }

        public async Task<string> GetOrdersByYear(int year)
        {
            StringBuilder builder = new StringBuilder("");
            var options = new AggregateOptions()
            {
                AllowDiskUse = false
            };

            PipelineDefinition<BsonDocument, BsonDocument> pipeline = new BsonDocument[]
            {
                new BsonDocument("$match", new BsonDocument()
                        .Add("OrderedYear", new BsonDocument()
                                .Add("$eq", year)
                        ))
            };

            
            using (var cursor = await _orderCollection.AggregateAsync(pipeline, options))
            {
                while (await cursor.MoveNextAsync())
                {
                    var batch = cursor.Current;
                    foreach (BsonDocument document in batch)
                    {
                        builder.Append(document.ToJson());
                    }
                }
            }
            return builder.ToString();
        }

        public async Task UpdateAsync(Order order, string id)
        {

            await _order.ReplaceOneAsync(order => order.Id == id, order);
        }

        
    }
}
