﻿using MobileSchoolAPI.Models;
using MobileSchoolAPI.ResultModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileSchoolAPI.BusinessLayer
{
    public class BirthdayBusiness
    {
        public object GetTodayStudentBirthDay(GetUserId Obj)
        {
            SchoolMainContext db = new ConcreateContext().GetContext(Obj.UserId, Obj.PASSWORD);
            if (db == null)
            {
                return new Results() { IsSuccess = false, Message = "Invalid User" };
            }
            else
            {
                    //for getting student todays birthday list
                var result = db.ViewGetTodayBirthDetails.ToList();
                
                if (result.Count == 0)
                { 
                    return new ResultBirth { IsSuccess = false, Result = result }; 
                }
                else
                {
                    return new ResultBirth { IsSuccess = true, Result = result };
                }
            }

        }
        public  object GetTodayEmployeeBirthDay(GetUserId Obj)
        {
            SchoolMainContext db = new ConcreateContext().GetContext(Obj.UserId, Obj.PASSWORD);
            if (db == null)
            {
                return new Results() { IsSuccess = false, Message = "Invalid User" };
            }
            else
            {
                //for getting employee todays birthday list
                var result = db.ViewGetEmployeeBirthDetails.ToList();

                if (result.Count()==0)
                { 
                    return new ResultBirth { IsSuccess = false, Result ="No Birthdays Found Today"  }; 
                }
                else
                {
                    return new ResultBirth { IsSuccess = true, Result = result };
                }
            }
        }
    }
}