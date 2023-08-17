﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Enrollment : BaseEntity
    {
        public string StudentId { get; set; }
        public string CourseId { get; set; }
        public Student Student { get; set; }
        public Course Course { get; set; }
    }
}
