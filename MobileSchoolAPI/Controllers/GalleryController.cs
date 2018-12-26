using MobileSchoolAPI.BusinessLayer;
using MobileSchoolAPI.Models;
using MobileSchoolAPI.ParamModel;
using MobileSchoolAPI.ResultModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MobileSchoolAPI.Controllers
{
    public class GalleryController : ApiController
    {
        [HttpPost]
        public object GetGallery([FromBody]ParamDefault OBJ)
        {
            GetGalleryDetailBL GETOBJ = new GetGalleryDetailBL();
            var GetGalleryResult = GETOBJ.GetGallery(OBJ);
            return GetGalleryResult;
        }
    }
}
