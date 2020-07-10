using DiscGolf.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscGolf.Models.CourseModels
{
    public class CourseDetail
    {
        public int CourseId { get; set; }
        public string CourseLocation { get; set; }
        public string CourseName { get; set; }
        public string CourseDescription { get; set; }
        public string CountyName { get; set; }
        public List<CommentListItem> Comments { get; set; }
    }
    public class CommentListItem
    {
        public int CommentId { get; set; }
        public string Text { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
    }
}
