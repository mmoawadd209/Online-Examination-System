using OnlineExamination.Models;
using System.Collections.Generic;

namespace OnlineExamination.ViewModels
{
    public class ExamViewModel
    {
        public Exam DomainModel { get; set; }
        public IEnumerable<Exam> ExamsList { get; set; }
    }
}