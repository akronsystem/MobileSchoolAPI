using MobileSchoolAPI.BusinessLayer;
using MobileSchoolAPI.ParamModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MobileSchoolAPI.Controllers
{
    public class NoticeController : ApiController
    {
        [HttpPost]
        public object GetNoticeDetails(NoticeParam obj)
        {
            NoticeBusinessLayer result = new NoticeBusinessLayer();
            var Notice = result.GetNotice(obj);
            return Notice;
        }
    }
}
