using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MobileSchoolAPI.BusinessLayer;
using MobileSchoolAPI.Models;
using MobileSchoolAPI.ParamModel;


namespace MobileSchoolAPI.Controllers
{
    public class StudentController : ApiController
    {
       [HttpPost]
       public object GetStudentDetails(StudentParam obj)
       {
            StudentBusiness result = new StudentBusiness();
            var StudentList = result.GetStudent(obj);
            return StudentList;
       }

    }
}
