using DiscGolf.Data;
using DiscGolf.Models.CountyModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscGolf.Services
{
    public class CountyService
    {
        public bool CreateCounty(CountyCreate model)
        {
            var entity =
                new County()
                {

                    CountyName = model.CountyName
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Counties.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<CountyListItem> GetCounties()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Counties
                        .Select(
                            e =>
                                new CountyListItem
                                {
                                    CountyId = e.CountyId,
                                    CountyName = e.CountyName
                                }
                        );

                return query.ToArray();
            }
        }
    }
}
