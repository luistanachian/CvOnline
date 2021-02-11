using Cv.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cv.Models
{
    public class SkillModel
    {
        public string CodeCategory { get; set; }
        public string Skill { get; set; }
        public int Score { get; set; }
        public DateTime FirstUsed { get; set; }
        public DateTime LastUsed { get; set; }
    }
}