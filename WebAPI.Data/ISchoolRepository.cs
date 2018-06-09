using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebAPI.Data.Model;

namespace WebAPI.Data
{
   public interface ISchoolRepository
    {
        IQueryable<Student> GetAllStudent();

        bool Insert(AuthToken token);


    }
}
