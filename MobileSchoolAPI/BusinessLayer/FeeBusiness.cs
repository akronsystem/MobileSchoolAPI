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
                var Password = CryptIt.Encrypt(obj.Password);
                var data = db.TBLUSERLOGINs.Where(r => r.UserName == obj.UserName && r.Password == Password).FirstOrDefault();
                if(data==null)
                {
                    return new Results() { IsSuccess = false, Message = "Invalid User" };
                }
                int StudentId = Convert.ToInt32(data.EmpCode);
                if (obj.UserName.StartsWith("SXS"))
                {
                    var getlist = db.View_DisplayFee.Where(r => r.STUDENTID == StudentId).FirstOrDefault();
                    var GetStanderd = db.TBLSTUDENTADMISSIONs.Where(r => r.STUDENTID == StudentId).FirstOrDefault();
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
                      

                        dateadmission = Convert.ToDateTime(getlist.ADMISSIONDATE).ToShortDateString();

                        string[] admsndate = dateadmission.Split('-');
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
                            TotalFee = Convert.ToDouble(GetFee.TOTALFEES) - Convert.ToDouble(AdmissionFee.AMOUNT);
                            //oldadmission
                        }

                        if (getlist.CONCESSION != null)
                        {
                            Cocession = Convert.ToDouble(getlist.CONCESSION);
                        }
                        TotalFee = TotalFee - Cocession;

                        return new FeeList() { IsSuccess = true, TotalFee = TotalFee, PaindingFee = RemaingFee.AMOUNT };
                    }
                    //return new FeeList() { IsSuccess = true, TotalFee = TotalFee, RemainingFee = RemaingFee.AMOUNT };
                }
                else if (obj.UserName.StartsWith("NKV"))
                {

                    double App_fee = 0;
                   
                    var nkTotalFee = db.View_GetTotalFees.Where(r => r.STUDENTID == StudentId).FirstOrDefault();
                    if(nkTotalFee==null)
                    {

                        var ApplicableFee = db.View_GetFeeSettings.Where(r => r.ENROLLMENTNO == obj.UserName).ToList();
                        if(ApplicableFee.Count()==0)
                        {
                            return new FeeList() { IsSuccess = false, TotalFee = "Not Found Applicable Fee",PaindingFee="" };
                        }
                        for(int i=0;i<ApplicableFee.Count;i++)
                        {
                             App_fee += Convert.ToDouble(ApplicableFee[i].AMOUNT);

                        }
                        var Concession = db.TBLTRANSFERSTUDENTs.Where(r => r.STUDENTID == StudentId).FirstOrDefault();
                        if (Concession.CONCESSIONPERCENTAGE != null)
                        {
                            App_fee = App_fee - Convert.ToDouble(Concession.CONCESSIONPERCENTAGE);
                        }

                        return new FeeList() { IsSuccess = true, TotalFee = App_fee, PaindingFee = App_fee };

                    }
                    else
                    {
                        double Cocession = 0;
                                            

                        if (nkTotalFee.CONCESSION != null)
                        {
                            Cocession = Convert.ToDouble(nkTotalFee.CONCESSIONPERCENTAGE);
                        }
                        nkTotalFee.TOTALFEES = nkTotalFee.TOTALFEES -Convert.ToDecimal( Cocession);

                       // var nkpendingfee = db.View_GetPaidFees.Where(r => r.STUDENTID == StudentId).FirstOrDefault();
                        var Remaining_fee = nkTotalFee.TOTALFEES - nkTotalFee.PAID;
                        return new FeeList() { IsSuccess = true, TotalFee = nkTotalFee.TOTALFEES, PaindingFee = Remaining_fee };
                    }
                 
                }
                return null;
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