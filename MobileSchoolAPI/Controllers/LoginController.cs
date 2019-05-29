using MobileSchoolAPI.BusinessLayer;
using MobileSchoolAPI.BUSINESSLAYER;
using MobileSchoolAPI.Models;
using MobileSchoolAPI.ParamModel;
using MobileSchoolAPI.ResultModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Script.Serialization;

namespace MobileSchoolAPI.Controllers
{
    public class LoginController : ApiController
    {
		// GET api/values
		 
		/// <summary>	
		/// To Confirm Login UserName and Password
		/// If passed then Json object return else Error message 
		/// </summary>
		/// <param name="UserName"></param>
		/// <param name="Password"></param>
		/// <returns></returns>

		[HttpPost]
		public object Confirm([FromBody]ParamLogin userLogin)
		{
            try
            {
                string TeacherBaseUrl = "";
                string StudentBaseUrl = "";

                LoginManager objLogin = new LoginManager();
                var logindetail = objLogin.GetLoginDetails(userLogin);
                if (logindetail == null)
                    return new Results() { IsSuccess = false, Message = "Invalid User" };

                else
                {
                    if (logindetail.UserType == "STUDENT")
                    {
                        STUDENTINFO_BUSINESS StudBL = new STUDENTINFO_BUSINESS();
                        var result = StudBL.getStudLogo(int.Parse(logindetail.EmpCode),Convert.ToInt16( logindetail.UserId),logindetail.Password);

                        var notificationUnreadCount = StudBL.getNotifCount(int.Parse(logindetail.EmpCode), Convert.ToInt16(logindetail.UserId), logindetail.Password);

                        if (result == null)
                        {
                        }
                        else
                        {
                            logindetail.IMAGEPATH = (string)result;
                            logindetail.HomeworkNotificationUnreadCount =(int)notificationUnreadCount;
                        }
                        if (logindetail.UserName.StartsWith("NKV"))
                        {
                            StudentBaseUrl = ConfigurationManager.AppSettings["NkvsBaseUrlStudent"];
                        }
                        else if(logindetail.UserName.StartsWith("SXS"))
                        {
                            StudentBaseUrl = ConfigurationManager.AppSettings["StxavierBaseUrlStudent"];
                        }
                        else if (logindetail.UserName.StartsWith("ASM"))
                        {
                            StudentBaseUrl = ConfigurationManager.AppSettings["AsmBaseUrlStudent"];
                        }

                        else if (logindetail.UserName.StartsWith("ASY"))
                        {
                            StudentBaseUrl = ConfigurationManager.AppSettings["AsyBaseUrlStudent"];
                        }
                        else if (logindetail.UserName.StartsWith("NMS"))
                        {
                            StudentBaseUrl = ConfigurationManager.AppSettings["NmsBaseUrlStudent"];
                        }
                        logindetail.BaseURL = StudentBaseUrl;
                    }
                    
                    else if (logindetail.UserType == "PARENT")
                    {

                    }
                    else if (logindetail.UserType == "PRINCIPLE")
                    {

                    }
                    else if(logindetail.UserType == "TEACHER" || logindetail.UserType == "CLASS TEACHER")
                    {
                        GetTeacherInfoBusiness TeacherBL = new GetTeacherInfoBusiness();
                        var result=TeacherBL.getTeacherLogo(int.Parse(logindetail.EmpCode),Convert.ToInt16( logindetail.UserId),logindetail.Password);
                        if (result==null)
                        {
                        }
                        else
                        {
                            logindetail.IMAGEPATH = (string)result;
                        }
                        if (logindetail.UserName.StartsWith("NKV"))
                        {
                            TeacherBaseUrl = ConfigurationManager.AppSettings["NkvsBaseUrlTeacher"];

                        }
                        else if(logindetail.UserName.StartsWith("SXS"))
                        {
                            TeacherBaseUrl = ConfigurationManager.AppSettings["StxavierBaseUrlTeacher"];
                        }
                        else if (logindetail.UserName.StartsWith("ASM"))
                        {
                            TeacherBaseUrl = ConfigurationManager.AppSettings["AsmBaseUrlTeacher"];
                        }
                        else if (logindetail.UserName.StartsWith("ASY"))
                        {
                            TeacherBaseUrl = ConfigurationManager.AppSettings["AsyBaseUrlTeacher"];
                        }
                        else if (logindetail.UserName.StartsWith("NMS"))
                        {
                            TeacherBaseUrl = ConfigurationManager.AppSettings["NmsBaseUrlTeacher"];
                        }
                      
                        logindetail.BaseURL = TeacherBaseUrl;
                    }
                    DeviceBusinessLayer objDeviceBl = new DeviceBusinessLayer();
                    ParamDevice PDeviceObj = new ParamDevice();
                    PDeviceObj.UserId = (int)logindetail.UserId;
                    PDeviceObj.DeviceId = userLogin.DeviceId;
                    PDeviceObj.DeviceType = userLogin.DeviceType;
                    objDeviceBl.SaveDevice(PDeviceObj,logindetail.Password);

                    logindetail.DeviceId = userLogin.DeviceId;
                    logindetail.DeviceType = userLogin.DeviceType;

					return new ResultLogin() { IsSuccess = true, UserData = logindetail };
					//return logindetail;
                }
            }
            catch (Exception ex)
            {
                return new Results() { IsSuccess = false, Message = ex.Message };
                
            }
		}
	}
}
