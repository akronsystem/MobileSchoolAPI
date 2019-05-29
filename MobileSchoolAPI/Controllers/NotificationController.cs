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
    public class NotificationController : ApiController
    {
        [HttpPost]
        public object SaveNotification([FromBody]ParamNotification obj)
        {
            NotificationBusiness objnote = new NotificationBusiness();

            return objnote.SaveNotification(obj);
        }

        public object ViewNotification([FromBody]ParamNotificationView obj)
        {
            NotificationBusiness objnote = new NotificationBusiness();
			return  objnote.ViewNotification(obj) ;

		}

        public object UpdateNotification([FromBody]ParamNotificationUpdate obj)
        {
            NotificationBusiness objnote = new NotificationBusiness();
            return objnote.UpdateNotification(obj);
        }

        [HttpPost]
        public object SaveAllNotification([FromBody]ParamAllNotification obj)
        {

            NotificationBusiness objnote = new NotificationBusiness();

            return objnote.SaveNotificationAll(obj);
        }

        [HttpPost]
        public object ViewEventHoliday([FromBody]ParamNotificationView obj)
        {
            NotificationBusiness objnote = new NotificationBusiness();
            return objnote.ViewEventHoliday(obj);
        }

    }
}
