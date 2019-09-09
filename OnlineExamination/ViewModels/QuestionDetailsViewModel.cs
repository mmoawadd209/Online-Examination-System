using OnlineExamination.Models;


namespace OnlineExamination.ViewModels
{
    public class QuestionDetailsViewModel
    {
        public Question DomainModel { get; set; }
        public Choice ChoiceModel { get; set; }
    }
}