using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPITest.API.Models
{
    public class StudentModel
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
       public IEnumerable<EnrollmentModel> Enrollments { get; set; }
    }
}