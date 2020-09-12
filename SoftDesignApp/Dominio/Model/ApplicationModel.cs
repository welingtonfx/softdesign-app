using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Dominio.Model
{
    public class ApplicationModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public int Application { get; set; }
        public string Url { get; set; }
        public string PathLocal { get; set; }
        public bool DebuggingMode { get; set; }
    }
}
