using MongoDB.Bson.Serialization.Attributes;

namespace Cv.Models
{
    public class AdressModel
    {
        [BsonElement("cy")]
        public string Country { get; set; }
        [BsonElement("se")]
        public string State { get; set; }
        [BsonElement("ln")]
        public string Location { get; set; }
        [BsonElement("st")]
        public string Street { get; set; }
        [BsonElement("nr")]
        public string Number { get; set; }
        [BsonElement("fr")]
        public string Floor { get; set; }
        [BsonElement("dt")]
        public string Department { get; set; }
        [BsonElement("pc")]
        public string PostalCode { get; set; }
    }
}
