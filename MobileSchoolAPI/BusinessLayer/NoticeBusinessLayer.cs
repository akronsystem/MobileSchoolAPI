using MobileSchoolAPI.Models;
using MobileSchoolAPI.ParamModel;
using MobileSchoolAPI.ResultModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileSchoolAPI.BusinessLayer
{
    public class NoticeBusinessLayer
    {
        public object GetNotice(NoticeParam obj)
        {
            SchoolMainContext db = new ConcreateContext().GetContext(obj.UserName, obj.Password);
            if (db == null)
            {
                return new Results { IsSuccess = false, Message = "Invalid User" };
            }
            else
            {
                var AcademicYear = db.View_GETACADEMICYEAR.FirstOrDefault();
                if(obj.EventType==null || obj.EventType=="string")
                {
                    var data = db.View_DisplayNotice.Where(r => r.STARTDATE >= System.DateTime.Today.Date && r.DISPLAY == 1 && r.ACADEMICYEAR == AcademicYear.ACADEMICYEAR).ToList();
                    if (data != null)
                    {
                        return new NoticeResult { IsSuccess = true, Result = data };
                    }
                    else
                    {
                        return new NoticeResult { IsSuccess = true, Result = "Notice or Event Not Found" };
                    }

                }
                else
                {
                    var data = db.View_DisplayNotice.Where(r => r.STARTDATE >= System.DateTime.Today.Date && r.DISPLAY == 1 && r.TYPE == obj.EventType && r.ACADEMICYEAR == AcademicYear.ACADEMICYEAR).ToList();
                    if (data != null)
                    {
                        return new NoticeResult { IsSuccess = true, Result = data };
                    }
                    else
                    {
                        return new NoticeResult { IsSuccess = true, Result = "Notice or Event Not Found" };
                    }

                }

            }
        }
    }
}