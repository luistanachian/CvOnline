using Cv.Models.Enums;
using System;

namespace Cv.Models
{
    public class SkillModel
    {
        public string Skill { get; set; }
        public int Score { get; set; }
        public FrequencyUsedEnum FrequencyUsed { get; set; }
        public int Years { get; set; }
        public DateTime LastUsed { get; set; }
    }
}