using StudentPR.Data;
using Microsoft.EntityFrameworkCore;

namespace StudentPR.Services
{
    public class StudentService
    {
        private readonly AppDbContext context;
        public StudentService(AppDbContext _context)
        {
            context = _context;
        }
        public async Task<Models.Student> CreateAsync(Models.Student student)
        {
            context.Students.Add(student);
            await context.SaveChangesAsync();
            return student;
        }
        public async Task<List<Models.Student>> GetAllAsync()
        {
            var students = await context.Students.ToListAsync();
            return students;
        }
        public async Task<Models.Student> GetStudentByIdAsync(int id)
        {
            var student = await context.Students.FindAsync(id);
            if (student == null) return null;
            return student;
        }
        public async Task<Models.Student> UpdateAsync(Models.Student obj, int id)
        {
            var student = await context.Students.FindAsync(id);
            if (student == null) return null;

            student.FirstName = obj.FirstName;
            student.LastName = obj.LastName;
            student.PhoneNumber = obj.PhoneNumber;
            student.Address = obj.Address;
            await context.SaveChangesAsync();
            return student;
        }
        public async Task<Models.Student> DeleteAsync(int id)
        {
            var student = await context.Students.FindAsync(id);
            if (student == null) return null;
            context.Students.Remove(student);
            await context.SaveChangesAsync();
            return student;
        }

    }
}
