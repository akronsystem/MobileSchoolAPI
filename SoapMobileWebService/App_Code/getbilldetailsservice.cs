using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

/// <summary>
/// Summary description for getbilldetailsservice
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class RetType
{
	public string out1 { get; set; }
	public string out2 { get; set; }

}

public class getbilldetailsservice : System.Web.Services.WebService
{

	public getbilldetailsservice()
	{

		//Uncomment the following line if using designed components 
		//InitializeComponent(); 
	}

	[WebMethod]
	public RetType getbilldetailsoperation(string SchoolName,string StudentName,string EnrollmentNo,string Paymentdate)
	{

		RetType obj = new RetType();
		obj.out1 = "abc";
		obj.out2 = "xyz";
		return obj;
	}

}
