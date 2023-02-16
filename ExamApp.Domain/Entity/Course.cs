using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamApp.Domain.Entity
{
    public class Course : BaseEntity<Guid>
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Student> Students { get; set; }
        public virtual Language Language { get; set; }
    }
}
