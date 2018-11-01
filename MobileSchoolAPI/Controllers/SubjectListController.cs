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
    public class SubjectListController : ApiController
    {
        public object ShowSubjectList([FromBody]ParamDIVISIONWISESUBJECT objsub)
        {



            GetSubjectListBusiness obj = new GetSubjectListBusiness();
            //return obj.GetSubjectList(objsub);

            return new DivisionListResult() { IsSuccess = "true", SubjectList = obj.GetSubjectList(objsub) };
        }
    }
}
