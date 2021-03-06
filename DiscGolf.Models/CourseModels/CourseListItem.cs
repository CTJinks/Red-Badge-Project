﻿using DiscGolf.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscGolf.Models.CourseModels
{
    public class CourseListItem
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public string CourseLocation { get; set; }
        public int Holes { get; set; }
        public string CourseDescription { get; set; }
        public County County { get; set; }
        public string CountyName { get; set; }
    }
}
