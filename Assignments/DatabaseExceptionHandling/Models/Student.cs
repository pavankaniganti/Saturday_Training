﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseExceptionHandling.Models
{
    public class Student
    {
        public int StudentID { get; set; }

        public string Name { get; set; }

        public string GroupName { get; set; }

        public DateTime ModifiedDate { get; set; }
    }
}
