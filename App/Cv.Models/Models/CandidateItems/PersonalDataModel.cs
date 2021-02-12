using Cv.Models.Enums;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace Cv.Models
{
    public class PersonalDataModel
    {
        [BsonElement("ne")]
        public string Name { get; set; }
        [BsonElement("ln")]
        public string LastName { get; set; }
        [BsonElement("bd")]
        public string BirthDay { get; set; }
        [BsonElement("sx")]
        public string Sex { get; set; }
        [BsonElement("di")]
        public string Dni { get; set; }
        [BsonElement("ny")]
        public string Nacionality { get; set; }
        [BsonElement("as")]
        public AdressModel Adress { get; set; }
        [BsonElement("em")]
        public List<string> EMails { get; set; }
        [BsonElement("ps")]
        public List<string> Phones { get; set; }
        [BsonElement("sn")]
        public List<string> ListSocialNetworks { get; set; }
        [BsonElement("oc")]
        public string Occupation { get; set; }
        [BsonElement("re")]
        public string Role { get; set; }
        [BsonElement("sy")]
        public SeniorityEnum Seniority { get; set; }
    }
}
