using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task1.Entities
{
    public class Product
    {
        public string Name { get; set; }
        public int Quantity { get; set; }

        [BsonRepresentation(BsonType.Double)]
        public double Price { get; set; }
    }
}
