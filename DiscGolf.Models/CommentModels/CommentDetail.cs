using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscGolf.Models.CommentModels
{
    public class CommentDetail
    {
        public int CommentId { get; set; }
        public string UserName { get; set; }
        public string CourseName { get; set; }
        public string Text { get; set; }
    }
}
