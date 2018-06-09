using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Routing;
using WebAPI.Data;
using WebAPI.Data.Model;

namespace WebAPITest.API.Models
{
    public class ModelFactory
    {
        private UrlHelper _urlHelper;
        private ISchoolRepository _repo;
        public ModelFactory(HttpRequestMessage request, ISchoolRepository repo)
        {
            _urlHelper = new UrlHelper(request);
            _repo = repo;
        }

        public StudentModel Create(Student food)
        {
            return new StudentModel()
            {
                FirstName = food.FirstName,
                LastName = food.LastName,
                Enrollments = food.Enrollments.Select(  
                    e => new EnrollmentModel()
                    {
                        EnrollmentID = e.EnrollmentID,
                        CourseID = e.CourseID                        
                    }
                    )
                
            };
        }

        internal object Create2(Student food)
        {
            return new StudentModel()
            {
                FirstName = food.FirstName,
                LastName = food.LastName
            };
        }
    }
}