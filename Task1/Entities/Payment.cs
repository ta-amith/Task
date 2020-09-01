using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task1.Entities
{
    public class Payment
    {
        [BsonRepresentation(BsonType.DateTime)]
        public DateTime PaidDate { get; set; }

        [BsonRepresentation(BsonType.Double)]
        public Double TotalCost { get; set; }

        public string PaymentType { get; set; }
    }
}
