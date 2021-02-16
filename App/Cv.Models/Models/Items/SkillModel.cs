﻿using Cv.Models.Enums;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Cv.Models
{
    public class SkillModel
    {
        public string Skill { get; set; }
        public int Score { get; set; }
        public FrequencyUsedEnum FrequencyUsed { get; set; }
        public int Years { get; set; }
        public string LastUsed { get; set; }
    }
}