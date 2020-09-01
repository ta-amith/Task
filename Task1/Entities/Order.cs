using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task1.Entities
{
    public class Order
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonRepresentation(BsonType.DateTime)]
        public DateTime OrderDate { get; set; }

        [BsonRepresentation(BsonType.DateTime)]
        public DateTime? DeliveryDate { get; set; }

        public string DeliveryStatus { get; set; }

        public User Customer { get; set; }

        public List<Product> Products { get; set; }

        public Payment Payment { get; set; }

        public int OrderedYear { get; set; }


    }
}
