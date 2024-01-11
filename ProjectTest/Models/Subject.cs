using System.ComponentModel.DataAnnotations;

namespace ProjectTest.Models
{
    public class Subject
    {
        public int SubjectId { get; set; }

        [StringLength(30, MinimumLength = 1)]
        [Required]
        public string? SubjectName { get; set; }
    }
}
