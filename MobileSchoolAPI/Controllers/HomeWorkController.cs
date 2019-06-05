﻿using MobileSchoolAPI.BusinessLayer;
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
		
		[HttpPost]

		public object ShowHomeWork([FromBody]ParamHOMEWORKBYUSER objhome)
		{
			GETHOMEWORK obj = new GETHOMEWORK();
            var homemworkresult=obj.ViewHomeWorkbyUser(objhome);
            //return obj.ViewHomeWorkbyUser(objhome);
            //return new DivisionListResult() { IsSuccess = true, HomeWork = obj.ViewHomeWorkbyUser(objhome) };
            return homemworkresult;
		}

        [HttpPost]
        public object ShowHomeWorkAll([FromBody]ParamHomeWorkAll objhome)
        {
            GETHOMEWORK obj = new GETHOMEWORK();
            var homemworkresult = obj.ViewHomeWorkByDates(objhome);
            return homemworkresult;
        }



        //[HttpPost]
        //public object HomeworkSave([FromBody]homeworkparameters hobj)
        //{

        //    Homeworkbussinesslayer bhobj = new Homeworkbussinesslayer();
           

        //   var result=  bhobj.Savehomework(hobj);
        //    //  bhobj.StudentsMethod(hobj);

        //    return result;
            



        //}

        [HttpPost]
        public object HomeworkSave()
        {
            homeworkparameters obj = new homeworkparameters();
            try
            {
                Homeworkbussinesslayer objp = new Homeworkbussinesslayer();
                var homemworkresult = objp.FileUpload(obj);
                return homemworkresult;
            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };
            }


        }

		[HttpPost]
		public object TestNotification(homeworkparameters obj)
		{
			 
			try
			{
				Homeworkbussinesslayer objp = new Homeworkbussinesslayer();
				var homemworkresult = objp.SendNotificaiton(obj);
				return homemworkresult;
			}
			catch (Exception e)
			{
				return new Error() { IsError = true, Message = e.Message };
			}


		}



	}
}