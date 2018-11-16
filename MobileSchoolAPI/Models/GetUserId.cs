using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace MobileSchoolAPI.Models
{
    public class GetUserId
    {
        [Key]
        public long UserId { get; set; }

        public string PASSWORD { get; set; }
    }
}