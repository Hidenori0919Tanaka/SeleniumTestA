using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UnitTest_Sample.Entity.MongoDB
{
    public class hogeDoc
    {
        [BsonId(IdGenerator = typeof(CombGuidGenerator))]
        public Guid Id { get; set; }

        [BsonElement("Name")]
        public string Name { get; set; }

        [BsonElement("Date")]
        public DateTime Date { get; set; }

        [BsonElement("CreatedDate")]
        public DateTime CreatedDate { get; set; }
    }
}