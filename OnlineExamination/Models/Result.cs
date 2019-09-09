using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineExamination.Models
{
    public class Result
    {
        public int Id { get; set; }
        public Exam Exam { get; set; }
        public int ExamId { get; set; }
        public ApplicationUser User { get; set; }
        public int UserId { get; set; }
        public float Score { get; set; }
        public DateTime Time { get; set; }
    }
}