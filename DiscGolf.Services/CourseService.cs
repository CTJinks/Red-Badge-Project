using DiscGolf.Data;
using DiscGolf.Models.CourseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscGolf.Services
{
    public class CourseService
    {
        public bool CreateCourse(CourseCreate model)
        {
            var entity =
                new Course()
                {
                    CourseName = model.CourseName,
                    CourseLocation = model.CourseLocation,
                    Holes = model.Holes,
                    CourseDescription = model.CourseDescription,
                    CountyId = model.CountyId
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Courses.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<CourseListItem> GetCourses()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Courses
                        .Select(
                            e =>
                                new CourseListItem
                                {
                                    CourseId = e.CourseId,
                                    CourseLocation = e.CourseLocation,
                                    CourseName = e.CourseName,
                                    Holes = e.Holes,
                                    CourseDescription = e.CourseDescription,
                                    CountyName = e.County.CountyName
                                }
                        );
                return query.ToArray(); 
            }
        }
        public IEnumerable<CourseListItem> SortCourses(string sortOrder, string searchString)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var courses = from s in ctx.Courses
                            select s;
                if (!String.IsNullOrEmpty(searchString))
                {
                    courses = courses.Where(s => s.County.CountyName.Contains(searchString));
                }
                switch (sortOrder)
                {
                    case "name_desc":
                        courses = courses.OrderByDescending(s => s.CourseId);
                        break;
                    case "countyName":
                        courses = courses.OrderBy(s => s.County.CountyName);
                        break;
                    case "countyName_desc":
                        courses = courses.OrderByDescending(s => s.County.CountyName);
                        break;
                    default:
                        courses = courses.OrderBy(s => s.CourseId);
                        break;
                }
                return (courses.Select(
                            e =>
                                new CourseListItem
                                {
                                    CourseId= e.CourseId,
                                    CourseName=e.CourseName,
                                    CourseLocation=e.CourseLocation,
                                    Holes=e.Holes,
                                    CourseDescription=e.CourseDescription,
                                    CountyName=e.County.CountyName
                                }
                        ).ToList());
            }
        }
        public CourseDetail GetCourseDetailById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Courses
                        .Single(e => e.CourseId == id);
                return
                    new CourseDetail
                    {
                        CourseId = entity.CourseId,
                        CourseLocation = entity.CourseLocation,
                        CourseName = entity.CourseName,
                        Holes = entity.Holes,
                        CourseDescription = entity.CourseDescription,
                        CountyName = entity.County.CountyName
                     
                        
                    };
            }
        }
        public Course GetCourseById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Courses
                        .Single(e => e.CourseId == id);
                return
                    new Course
                    {
                        CourseId = entity.CourseId,
                        CourseName = entity.CourseName,
                        CourseLocation = entity.CourseLocation,
                        Holes = entity.Holes,
                        CourseDescription= entity.CourseDescription
                        
                    };
            }
        }
        public bool UpdateCourse(CourseEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Courses
                        .Single(e => e.CourseId == model.CourseId);

                entity.CourseName = model.CourseName;
                entity.CourseLocation = model.CourseLocation;
                entity.Holes = model.Holes;
                entity.CourseDescription = model.CourseDescription;


                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteCourse(int courseId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Courses
                        .Single(e => e.CourseId == courseId);

                ctx.Courses.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
