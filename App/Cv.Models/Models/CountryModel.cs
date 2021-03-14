using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Cv.Models
{
    public class CountryModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.Int32)]
        public int id { get; set; }
        public string name { get; set; }
        public string code { get; set; }
        public string phone_code { get; set; }
        public string currency { get; set; }
        public string currency_symbol { get; set; }
    }
}