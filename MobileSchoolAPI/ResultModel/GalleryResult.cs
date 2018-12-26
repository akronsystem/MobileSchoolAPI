using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileSchoolAPI.ResultModel
{
    public class GalleryResult
    {
        public bool IsSuccess { get; set; }
        public object GalleryListResults { get; set; }
    }
}