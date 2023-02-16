using ExamApp.Data;
using ExamApp.Domain.Entity;
using ExamApp.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ExamApp.Repository.Repositories
{
    public class StudentsService : IStudentsService
    {
        public IEnumerable<Student> GetAllStudents()
        {
            using (ExamAppDBContext _dbContext = new ExamAppDBContext())
            {
                return _dbContext.Students.ToList();
            }
        }

        public async Task AddStudent(Student student)
        {
            using (ExamAppDBContext _dbContext = new ExamAppDBContext())
            {
                if (student.Age < 18)
                {
                    throw new Exception();
                }

                await _dbContext.Students.AddAsync(student);
                await _dbContext.SaveChangesAsync();
            }
        }

        public void Modify(int id, Student student)
        {
            using (ExamAppDBContext _dbContext = new ExamAppDBContext())
            {
                if (student.Age < 18)
                {
                    throw new Exception();
                }

                student.Id = id;

                _dbContext.Attach(student).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }
        }

        public IEnumerable<Course> GetCourses()
        {
            using (ExamAppDBContext _dbContext = new ExamAppDBContext())
            {
                var courses = _dbContext.Courses
                .ToArrayAsync()
                .Result
                .AsEnumerable();

                courses.OrderBy(c => c.Title);

                return courses;
            }
        }

        public Course GetCourse(Guid id)
        {
            using (ExamAppDBContext _dbContext = new ExamAppDBContext())
            {
                return _dbContext.Courses
                .Include(x => x.Students)
                .FirstOrDefault(x => x.Id == id);
            }
        }

        public void ModifyCourse(Guid id, Course course)
        {
            using (ExamAppDBContext _dbContext = new ExamAppDBContext())
            {
                course.Id = id;
                _dbContext.Attach(course).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }
        }
    }
}
