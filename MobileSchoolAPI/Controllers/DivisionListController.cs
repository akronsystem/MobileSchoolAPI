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
    public class DivisionListController : ApiController
    {
        SchoolContext db = new SchoolContext();
        [HttpPost]
        public object getStdDivList([FromBody]ParamDIVISIONLIST objdiv)
        {
            GetDivisionInfoBusiness obj = new GetDivisionInfoBusiness(); 
            return obj.GetDivision(objdiv) ;
        }
        [HttpPost]
        public object GetStandard([FromBody]ParamDIVISIONLIST objdiv)
        {
            GetStandardList objstd = new GetStandardList();
           return objstd.GetStdList(objdiv);
           
		}
        public object ViewDivision([FromBody]PARAMSTD objstd)
        {
            GETHOMEWORK objhome = new GETHOMEWORK();
            return objhome.GetStandard(objstd);
          


        } 

    }
}
