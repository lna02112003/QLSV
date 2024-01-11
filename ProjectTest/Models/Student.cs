using System.ComponentModel.DataAnnotations;

namespace ProjectTest.Models
{
    public class Student
    {
        public int StudentId { get; set; }

        [StringLength(150, MinimumLength = 2)]
        [Required]
        public string? StudentName { get; set; }

        [Required]
        public string? StudentRollId { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime StudentDOB { get; set; }
    }
}
