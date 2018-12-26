using MobileSchoolAPI.Models;
using MobileSchoolAPI.ResultModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileSchoolAPI.BusinessLayer
{
    public class BirthdayBusiness
    {
        public object GetTodayBirthDay(GetUserId Obj)
        {
            SchoolMainContext db = new ConcreateContext().GetContext(Obj.UserId, Obj.PASSWORD);
            if (db == null)
            {
                return new ResultBirth { IsSuccess = false, Result = "User Id or Password is Incorrect" };
            }
            else
            {
                //to get todays birthday list ViewGetTodayBirthDetail

                var result = db.ViewGetTodayBirthDetails.ToList();
                if (result == null)
                {
                    return new ResultBirth { IsSuccess = false, Result = "No Birthdays Found Today" };
                }
                else
                {
                    return new ResultBirth { IsSuccess = true, Result = result };
                }
            }

        }
    }
}