using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace Cv.Models
{
    public class oldCountryModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }

        public int id { get; set; }
        public string name { get; set; }
        public string iso3 { get; set; }
        public string iso2 { get; set; }
        public string phone_code { get; set; }
        public string capital { get; set; }
        public string currency { get; set; }
        public string currency_symbol { get; set; }
        public string native { get; set; }
        public string region { get; set; }
        public string subregion { get; set; }
        public List<TimezoneItem> timezones { get; set; }
        public TranslationItem translations { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
        public string emoji { get; set; }
        public string emojiU { get; set; }
    }
}
