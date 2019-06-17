using System;
using System.Collections.Generic;

namespace scaffold.Models
{
    public partial class Grade
    {
        public Grade()
        {
            Student = new HashSet<Student>();
        }

        public int GradeId { get; set; }
        public string GradeName { get; set; }
        public string GradeSection { get; set; }

        public virtual ICollection<Student> Student { get; set; }
    }
}
