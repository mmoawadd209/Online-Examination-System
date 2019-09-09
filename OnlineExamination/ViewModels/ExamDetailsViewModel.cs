using OnlineExamination.Models;


namespace OnlineExamination.ViewModels
{
    public class ExamDetailsViewModel
    {
        public Exam DomainModel { get; set; }
        public Question QuestionModel { get; set; }
    }
}