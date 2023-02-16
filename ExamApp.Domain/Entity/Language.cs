using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamApp.Domain.Entity
{
    public class Language : BaseEntity<Guid>
    {
        public string Title { get; set; }
    }
}
