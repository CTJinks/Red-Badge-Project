using DiscGolf.Data;
using DiscGolf.Models.CommentModels;
using DiscGolf.Models.CourseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscGolf.Services
{
    public class CommentService
    {
        public bool CreateComment(CommentCreate model)
        {
            var entity =
                new Comment()
                {
                    Text = model.Text
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Comments.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<CommentListItem> GetComments()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Comments
                        .Select(
                            e =>
                                new CommentListItem
                                {
                                    Text = e.Text,
                                    UserName = e.UserName
                                }
                        );
                var array = query.ToArray();
                return array;
            }
        }
        public CommentDetail GetCommentByCourse(Course Course)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Comments
                        .Single(e => e.Course == Course);
                return
                    new CommentDetail
                    {
                        CommentId = entity.CommentId,
                        Text = entity.Text,
                        CourseName = entity.Course.CourseName,
                        UserName = entity.UserName
                    };
            }

        }
        public CommentDetail GetCommentById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Comments
                        .Single(e => e.CommentId == id);
                return
                    new CommentDetail
                    {
                        CommentId = entity.CommentId,
                        Text = entity.Text,
                        CourseName = entity.Course.CourseName,
                        UserName = entity.UserName
                    };
            }
        }
    }
}
