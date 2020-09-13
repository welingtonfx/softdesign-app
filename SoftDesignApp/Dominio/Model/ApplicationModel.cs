using Dominio.Interface.Model;
using Dominio.ViewModel;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Dominio.Model
{
    public class ApplicationModel : IIdentifier
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public int Application { get; set; }
        public string Url { get; set; }
        public string PathLocal { get; set; }
        public bool DebuggingMode { get; set; }


        public static explicit operator ApplicationModel(ApplicationViewModel model)
        {
            return new ApplicationModel
            {
                Id = model.Id,
                Application = model.Application,
                Url = model.Url,
                PathLocal = model.PathLocal,
                DebuggingMode = model.DebuggingMode
            };
        }
    }
}
