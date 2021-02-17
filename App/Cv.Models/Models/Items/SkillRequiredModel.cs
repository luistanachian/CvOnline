namespace Cv.Models.Models.Items
{
    public class SkillRequiredModel
    {
        public string Skill { get; set; }
        public int Months { get; set; }
        public int Years { get; set; }
        public bool Excluding { get; set; }
        public string Comment { get; set; }
    }
}
