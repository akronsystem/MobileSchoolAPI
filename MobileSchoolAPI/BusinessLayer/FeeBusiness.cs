using MobileSchoolAPI.Models;
using MobileSchoolAPI.ParamModel;
using System;
using System.Data.SqlClient;
using System.Linq;

namespace MobileSchoolAPI.BusinessLayer
{
    public class FeeBusiness
    {
        public object GetFee(FeePram obj)
        {
            try
            {
                SchoolMainContext db = new ConcreateContext().GetContext(obj.UserName, obj.Password);
                if (db == null)
                {
                    return new Results() { IsSuccess = false, Message = "Invalid User" };
                }
                var data = db.TBLUSERLOGINs.Where(r => r.UserName == obj.UserName && r.Password == obj.Password).FirstOrDefault();
                int StudentId = Convert.ToInt32(data.EmpCode);
                var getlist = db.View_DisplayFee.Where(r=>r.STUDENTID==StudentId).FirstOrDefault();
                var GetStanderd= db.TBLSTUDENTADMISSIONs.Where(r => r.STUDENTID == StudentId).FirstOrDefault();
                var GetFee = db.View_FeeSetting.Where(r => r.STANDARDID == GetStanderd.STANDARDID).FirstOrDefault();
                var RemaingFee = db.View_RemainingFeeDisplay.Where(r => r.STUDENTID == StudentId).FirstOrDefault();
                if (GetFee == null)
                {
                    return new Results
                    {
                        IsSuccess = false,
                        Message = "Fee Not Found"
                    };
                }
                //else
                //{
                //    return new FeeList() { IsSuccess = true, TotalFee = GetFee.TOTALFEES };
                //}
               else if (RemaingFee == null)

                    return new Results
                    {
                        IsSuccess = false,
                        Message = "Fee Not Found"
                    };

                else
                {
                    double Cocession = 0, TotalFee = 0;
                    string dateadmission = "";
                    string ANNUALFEE = "";
                    
                    dateadmission = Convert.ToDateTime(getlist.ADMISSIONDATE).ToShortDateString();

                    string[] admsndate = dateadmission.Split('/');
                    int ADMISSIONYEAR = 0, NEXTYEAR = 0;
                    dateadmission = admsndate[2];
                    if (dateadmission != "")
                    {
                        int.TryParse(dateadmission, out ADMISSIONYEAR);
                    }
                    NEXTYEAR = ADMISSIONYEAR + 1;
                    string STUDADMISSIONYEAR = ADMISSIONYEAR + "-" + NEXTYEAR;

                    if (STUDADMISSIONYEAR == getlist.ACADEMICYEAR)
                    {
                        //newadmission
                        TotalFee = Convert.ToDouble(GetFee.TOTALFEES);
                    }
                    else
                    {
                        var AdmissionFee = db.View_FeeSetting.Where(r => r.FEETYPEID == 1).FirstOrDefault();
                        TotalFee=Convert.ToDouble(GetFee.TOTALFEES) - Convert.ToDouble(AdmissionFee.AMOUNT);
                        //oldadmission
                    }
                       
                    if (getlist.CONCESSION!=null)
                    {
                        Cocession = Convert.ToDouble(getlist.CONCESSION);
                    }
                    TotalFee =TotalFee - Cocession;

                    return new FeeList() { IsSuccess = true, TotalFee = TotalFee,RemainingFee=RemaingFee.AMOUNT };
                }
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