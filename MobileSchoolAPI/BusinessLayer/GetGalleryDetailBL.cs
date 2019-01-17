using MobileSchoolAPI.Models;
using MobileSchoolAPI.ParamModel;
using MobileSchoolAPI.ResultModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileSchoolAPI.BusinessLayer
{
    public class GetGalleryDetailBL
    {
        public object GetGallery(ParamDefault OBJ)
        {
            try
            {
                SchoolMainContext db = new ConcreateContext().GetContext(OBJ.USERID, OBJ.PASSWORD);
                if (db == null)
                {
                    return new Results() { IsSuccess = false, Message  = "Invalid User" } ;
                }
                var GetGallery = db.VW_GetGallery.ToList();
                List<Gallary> Details = new List<Gallary>();
                object[,] str=new object[ GetGallery.Count,2];
                for (int i = 0; i < GetGallery.Count; i++)
                {
                    string[] imgpath = GetGallery[i].IMAGEPATH.Split(',');
                    object[] strpath = new object[imgpath.Length];
                    for (int j = 0; j < imgpath.Length; j++)
                    {
                        strpath[j]= imgpath[j];
                    }


                    Details.Add(new Gallary
                    {
                        AlbumName = GetGallery[i].ALBUMNAME,
                        ImageList = strpath
                    });

                    //str[i,0] = "AlbumName:" + GetGallery[i].ALBUMNAME ;
                    //str[i, 1] =  strpath;
                }
                return new GalleryResult() { IsSuccess = true,URL= "http://www.sxs.akronsystems.com/ALBUMUPLOADS/Original/", GalleryAlbumList = Details.ToArray() };
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

        public class Gallary
        {
            public string AlbumName { get; set; }
            public object ImageList { get; set; }
        }
    }
}