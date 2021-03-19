using Cv.Models.Enums;
using System;
using System.Collections.Generic;

namespace Cv.Models
{
    public class AssignedCandidateItem
    {
        public DateTime Date { get; set; }
        public string UserId { get; set; }
        public string CandidateId { get; set; }
        public int EstimateAmount { get; set; }
        public string StartEstimateDate { get; set; }
        public string RelocateEstimateDate { get; set; }
        public StatusAssignedCandidateEnum Status { get; set; }
        public List<CommentItem> CommentsInterview { get; set; }
        public List<TestItem> Tests { get; set; }
        public List<CommentItem> CommentsInterviewClient { get; set; }
    }
}
