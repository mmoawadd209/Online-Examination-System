using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineExamination.Models
{
    public class Exam
    {
        public int Id { get; set; }
        [Display(Name="Exam Name")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Exam Duration In Minutes")]
        public int DurationInMinutes { get; set; }
        public int Status { get; set; }
        public ICollection<Question> Questions { get; set; }

        public Exam()
        {
            Questions = new List<Question>();

        }
    }
}