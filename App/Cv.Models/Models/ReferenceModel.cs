using Cv.Models.Enums;

namespace Cv.Models.Models
{
    public class ReferenceModel
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public WorkRelationshipEnum WorkRelationship { get; set; }
        public string ReferenceAnswer  { get; set; }
    }
}
