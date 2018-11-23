namespace MobileSchoolAPI.Models
{
	using System;
	using System.Data.Entity;
	using System.ComponentModel.DataAnnotations.Schema;
	using System.Linq;

	public partial class SchoolContext : SchoolMainContext
	{
		public SchoolContext()
			: base("name=SchoolContext")
		{
			
		}	 
	}
}
