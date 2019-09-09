using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;


namespace OnlineExamination.Models
{
    public class Question
    {
        public int Id { get; set; }

        [Display(Name = "Question text")]
        public string Text { get; set; }
        public Exam Exam { get; set; }
        public int ExamId { get; set; }
        public ICollection<Choice> Choices { get; set; }
       
        public Question()
        {
            Choices = new Collection<Choice>();
        }
    }
}