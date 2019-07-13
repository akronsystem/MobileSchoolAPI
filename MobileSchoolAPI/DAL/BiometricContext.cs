using MobileSchoolAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MobileSchoolAPI.DAL
{
    public class BiometricContext: SchoolMainContext
    {
        public BiometricContext()
            : base("name=BiometricModule")
        {
        }
        public virtual DbSet<DeviceLog> DeviceLogs { get; set; }
        public virtual DbSet<Device> Devices { get; set; }
    }
}