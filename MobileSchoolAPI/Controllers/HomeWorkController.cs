using MobileSchoolAPI.BusinessLayer;
using MobileSchoolAPI.Models;
using MobileSchoolAPI.ParamModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MobileSchoolAPI.Controllers
{
	public class HomeWorkController : ApiController
	{
		SchoolContext db = new SchoolContext();
		[HttpPost]

		public object ViewHomework([FromBody] PARAMHOMEWORK obj)
		{

			GETHOMEWORK objhome = new GETHOMEWORK();
			// return objhome.GetHomework(obj);

			return new DivisionListResult() { IsSuccess = "true", HomeWork = objhome.GetHomework(obj) };

		}


		public object ViewDivision([FromBody]PARAMSTD objstd)
		{
			GETHOMEWORK objhome = new GETHOMEWORK();
			// return objhome.GetStandard(objstd);
			return new DivisionListResult() { IsSuccess = "true", DivisionListByUser = objhome.GetStandard(objstd) };


		}


		public object ViewDivisionByEmp([FromBody]PARAMEMP objemp)
		{
			GETHOMEWORK objhome = new GETHOMEWORK();
			//return objhome.GetStdByEmp(objemp);
			return new DivisionListResult() { IsSuccess = "true", DivisionListByUser = objhome.GetStdByEmp(objemp) };

		}

		public object ShowHomeWork([FromBody]ParamHOMEWORKBYUSER objhome)
		{
			GETHOMEWORK obj = new GETHOMEWORK();
			//return obj.ViewHomeWorkbyUser(objhome);
			return new DivisionListResult() { IsSuccess = "true", HomeWork = obj.ViewHomeWorkbyUser(objhome) };

		}



        [HttpPost]
        public object HomeworkSave([FromBody]homeworkparameters hobj)
        {

            Homeworkbussinesslayer bhobj = new Homeworkbussinesslayer();


            bhobj.Savehomework(hobj);
            //  bhobj.StudentsMethod(hobj);


            return new Results
            {

                IsSuccess = "true",
                Message = "Homework assign successfully"
            };



        }

       
    }
}