using ProjectTest.Models;
using System;
using System.Linq;

namespace ProjectTest.Models
{
    public static class DataInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            if (context.Subject.Any() || context.Student.Any() || context.Exam.Any())
            {
                return;
            }

            var subjects = new Subject[]
            {
                new Subject { SubjectName = "Toán" },
                new Subject { SubjectName = "Văn" },
                new Subject { SubjectName = "Lý" }
            };
            context.Subject.AddRange(subjects);

            var students = new Student[]
            {
                new Student { StudentName = "Nguyễn Văn A", StudentRollId = "SV001", StudentDOB = DateTime.Parse("2000-01-01")},
                new Student { StudentName = "Trần Thị B", StudentRollId = "SV002", StudentDOB = DateTime.Parse("2000-02-02") },
                new Student { StudentName = "Lê Văn C", StudentRollId = "SV003", StudentDOB = DateTime.Parse("2000-03-03") },
                new Student { StudentName = "Phạm Thị D", StudentRollId = "SV004", StudentDOB = DateTime.Parse("2000-04-04") },
                new Student { StudentName = "Hoàng Văn E", StudentRollId = "SV005", StudentDOB = DateTime.Parse("2000-05-05") },
                new Student { StudentName = "Mai Thị F", StudentRollId = "SV006", StudentDOB = DateTime.Parse("2000-06-06") },
                new Student { StudentName = "Ngô Văn G", StudentRollId = "SV007", StudentDOB = DateTime.Parse("2000-07-07") },
                new Student { StudentName = "Trịnh Thị H", StudentRollId = "SV008", StudentDOB = DateTime.Parse("2000-08-08") },
                new Student { StudentName = "Lý Văn I", StudentRollId = "SV009", StudentDOB = DateTime.Parse("2000-09-09") },
                new Student { StudentName = "Đỗ Thị K", StudentRollId = "SV010", StudentDOB = DateTime.Parse("2000-10-10") },

            };
            context.Student.AddRange(students);

            var exams = new Exam[]
            {
                new Exam { SubjectId = 1, StudentId = 1, Mark = 85 },
                new Exam { SubjectId = 1, StudentId = 2, Mark = 78 },
                new Exam { SubjectId = 2, StudentId = 3, Mark = 92 },
                new Exam { SubjectId = 2, StudentId = 4, Mark = 65 },
                new Exam { SubjectId = 3, StudentId = 5, Mark = 75 },
                new Exam { SubjectId = 3, StudentId = 6, Mark = 88 },
                new Exam { SubjectId = 1, StudentId = 7, Mark = 70 },
                new Exam { SubjectId = 1, StudentId = 8, Mark = 95 },
                new Exam { SubjectId = 2, StudentId = 9, Mark = 80 },
                new Exam { SubjectId = 2, StudentId = 10, Mark = 60 },
                new Exam { SubjectId = 3, StudentId = 1, Mark = 90 },
                new Exam { SubjectId = 3, StudentId = 2, Mark = 85 },
                new Exam { SubjectId = 1, StudentId = 3, Mark = 78 },
                new Exam { SubjectId = 1, StudentId = 4, Mark = 95 },
                new Exam { SubjectId = 2, StudentId = 5, Mark = 88 },
                new Exam { SubjectId = 2, StudentId = 6, Mark = 75 },
                new Exam { SubjectId = 3, StudentId = 7, Mark = 62 },
                new Exam { SubjectId = 3, StudentId = 8, Mark = 80 },
                new Exam { SubjectId = 1, StudentId = 9, Mark = 70 },
                new Exam { SubjectId = 1, StudentId = 10, Mark = 50 },
            };
            context.Exam.AddRange(exams);

            context.SaveChanges();
        }
    }
}
