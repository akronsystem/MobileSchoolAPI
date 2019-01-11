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
                    return new Results() { IsSuccess = false, Message = new InvalidUser() { IsSuccess = false, Result = "Invalid User" } };
                }
                var GetGallery = db.VW_GetGallery.ToList();
                object[,] str=new object[ GetGallery.Count,2];
                for (int i = 0; i < GetGallery.Count; i++)
                {
                    string[] imgpath = GetGallery[i].IMAGEPATH.Split(',');
                    object[] strpath = new object[imgpath.Length];
                    for (int j = 0; j < imgpath.Length; j++)
                    {
                        strpath[j]= "ImagePath:"+imgpath[j];
                    }

                    str[i,0] = "AlbumName:" + GetGallery[i].ALBUMNAME ;
                    str[i, 1] = strpath;
                }
                return new GalleryResult() { IsSuccess = true, Results = str };
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