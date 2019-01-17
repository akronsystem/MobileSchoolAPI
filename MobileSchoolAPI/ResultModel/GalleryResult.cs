using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileSchoolAPI.ResultModel
{
    public class GalleryResult
    {
        public bool IsSuccess { get; set; }
        public string URL { get; set; }
        public object GalleryAlbumList { get; set; }

    }
}