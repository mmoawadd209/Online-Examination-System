using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineExamination.Models
{
    public class Choice
    {
        public int Id { get; set; }
        [Display(Name ="Choice Text")]
        [Required]
        public string Text { get; set; }
        public Question Question { get; set; }
        public int QuestionId { get; set; }

        [Display(Name = "Is a Correct Answer")]
        public bool IsCorrect { get; set; }

    }
}