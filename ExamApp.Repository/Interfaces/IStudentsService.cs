using ExamApp.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamApp.Repository.Interfaces
{
    public interface IStudentsService
    {
        IEnumerable<Student> GetAllStudents();
        Task AddStudent(Student student);
        void Modify(int id, Student student);
        IEnumerable<Course> GetCourses();
        Course GetCourse(Guid id);
        void ModifyCourse(Guid id, Course course);
    }
}
