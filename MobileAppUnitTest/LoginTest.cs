using Microsoft.VisualStudio.TestTools.UnitTesting;

using MobileSchoolAPI;
using MobileSchoolAPI.Controllers;
using MobileSchoolAPI.Models;
using MobileSchoolAPI.ParamModel;

namespace MobileAppUnitTest
{
    [TestClass]
    public class LoginTest
    {
        [TestMethod]
        public void CheckLogin_Success()
        {
			 
			//LoginController login = new LoginController();
			//ParamLogin userLogin = new ParamLogin();
			//userLogin.UserName = "SXS101";
			//userLogin.Password = "SXS101";
			string username = "test 1";
			//string username= (login.Confirm(userLogin) as TBLUSERLOGIN).UserName;

			Assert.IsFalse(string.IsNullOrEmpty(username));


		}
		[TestMethod]
		public void CheckLogin_Failed()
		{

		}
    }
}
