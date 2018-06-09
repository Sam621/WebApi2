using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPITest.API.Models
{
    public class EnrollmentModel
    {
        public int EnrollmentID { get; set; }
        public int  CourseID { get; set; }
        
        public IEnumerable<CourseModel> Courses { get; set; }
    }
}