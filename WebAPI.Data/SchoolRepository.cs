using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebAPI.Data.Model;

namespace WebAPI.Data
{
    public class SchoolRepository : ISchoolRepository
    {
        private SchoolContext _ctx;

        public SchoolRepository(SchoolContext ctx)
        {
            _ctx = ctx;
        }
        public IQueryable<Student> GetAllStudent()
        {
            return _ctx.Students;
        }

        public bool Insert(AuthToken token)
        {
            return true;
        }
    }
}
