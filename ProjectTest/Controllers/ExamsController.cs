using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectTest.Models;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTest.Controllers
{
    public class ExamsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ExamsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var exams = await _context.Exam.ToListAsync();
            return View(exams);
        }
        public async Task<IActionResult> Details(int? subjectId, int? studentId)
        {
            if (subjectId == null || studentId == null)
            {
                return NotFound();
            }

            var exam = await _context.Exam
                .FirstOrDefaultAsync(e => e.SubjectId == subjectId && e.StudentId == studentId);

            if (exam == null)
            {
                return NotFound();
            }

            return View(exam);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SubjectId,StudentId,Mark")] Exam exam)
        {
            if (ModelState.IsValid)
            {
                _context.Add(exam);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(exam);
        }

        public async Task<IActionResult> Edit(int? subjectId, int? studentId)
        {
            if (subjectId == null || studentId == null)
            {
                return NotFound();
            }

            var exam = await _context.Exam
                .FirstOrDefaultAsync(e => e.SubjectId == subjectId && e.StudentId == studentId);

            if (exam == null)
            {
                return NotFound();
            }

            return View(exam);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("SubjectId,StudentId,Mark")] Exam exam)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(exam);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExamExists(exam.SubjectId, exam.StudentId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            return View(exam);
        }

        public async Task<IActionResult> Delete(int? subjectId, int? studentId)
        {
            if (subjectId == null || studentId == null)
            {
                return NotFound();
            }

            var exam = await _context.Exam
                .FirstOrDefaultAsync(e => e.SubjectId == subjectId && e.StudentId == studentId);

            if (exam == null)
            {
                return NotFound();
            }

            return View(exam);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int subjectId, int studentId)
        {
            var exam = await _context.Exam
                .FirstOrDefaultAsync(e => e.SubjectId == subjectId && e.StudentId == studentId);

            _context.Exam.Remove(exam);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExamExists(int subjectId, int studentId)
        {
            return _context.Exam.Any(e => e.SubjectId == subjectId && e.StudentId == studentId);
        }
    }
}
