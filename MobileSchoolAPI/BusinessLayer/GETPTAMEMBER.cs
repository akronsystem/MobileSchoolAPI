﻿using MobileSchoolAPI.Models;
using MobileSchoolAPI.ParamModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileSchoolAPI.BusinessLayer
{
    public class GETPTAMEMBER
    {

        public object GetMemberList(PTAMemberParam obj)
        {
            try
            {

            
            SchoolMainContext db = new ConcreateContext().GetContext(obj.UserName, obj.Password);
            if (db == null)
            {
                return new Results { IsSuccess = false, Message = "Invalid User" };
            }
            else
            {
                var password = CryptIt.Encrypt(obj.Password);
                var data = db.TBLUSERLOGINs.Where(r => r.UserName == obj.UserName && r.Password == password).FirstOrDefault();
                if (data == null)
                {
                    return new Results { IsSuccess = false, Message = "Invalid User" };
                }
                var result = db.View_DisplayPTAMember.ToList();
                return new StudentDetails { IsSuccess = true, StudentInformation = result };
            }
            }
            catch (Exception ex)
            {
                return new Results
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }
    }
}