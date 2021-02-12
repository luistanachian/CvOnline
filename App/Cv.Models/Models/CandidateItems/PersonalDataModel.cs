using Cv.Models.Enums;
using System.Collections.Generic;

namespace Cv.Models
{
    public class PersonalDataModel
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string BirthDay { get; set; }
        public string Sex { get; set; }
        public string Dni { get; set; }
        public string Nacionality { get; set; }
        public AdressModel Adress { get; set; }
        public List<string> EMails { get; set; }
        public List<string> Phones { get; set; }
        public List<string> ListSocialNetworks { get; set; }
        public string Occupation { get; set; }
        public string Role { get; set; }
        public SeniorityEnum Seniority { get; set; }
    }
}
