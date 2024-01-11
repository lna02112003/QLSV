using System.ComponentModel.DataAnnotations;

namespace ProjectTest.Models
{
    public class Exam
    {
        public int SubjectId { get; set; }
        public int StudentId { get; set; }

        [Range(0, 100)]
        [Required]
        public int Mark { get; set; }
    }
}
