using OnlineExamination.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineExamination.ViewModels
{
    public class ResultViewModel
    {
        public Result DomainModel { get; set; }
        public Exam Exam { get; set; }
        public List<Question> Questions { get; set; }
    }
}