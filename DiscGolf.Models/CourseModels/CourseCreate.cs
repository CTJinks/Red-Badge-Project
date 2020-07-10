﻿using DiscGolf.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscGolf.Models.CourseModels
{
    public class CourseCreate
    {
        public string CourseName { get; set; }
        public string CourseLocation { get; set; }
        public string CourseDescription { get; set; }
        public int? CountyId { get; set; } 
    }
}
