using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamApp.Domain.Entity
{
    public class Student: BaseEntity<int>
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Guid CourseId { get; set; }

        public virtual Course Course { get; set; }
    }
}
