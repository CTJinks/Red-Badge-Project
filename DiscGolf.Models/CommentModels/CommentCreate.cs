﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscGolf.Models.CommentModels
{
    public class CommentCreate
    {
        [Required]
        public string Text { get; set; }
        public int? CourseId { get; set; }
    }
}
