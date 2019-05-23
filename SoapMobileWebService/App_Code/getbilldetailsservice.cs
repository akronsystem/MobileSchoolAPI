using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
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

    public string out3 { get; set; }
    public string out4 { get; set; }
    public string out5 { get; set; }
    public string out6 { get; set; }
    public string out7 { get; set; }
    public string out8 { get; set; }

}
public class Result
{
    public string RequestId { get; set; }
}

public class getbilldetailsservice : System.Web.Services.WebService
{

	public getbilldetailsservice()
	{

		//Uncomment the following line if using designed components 
		//InitializeComponent(); 
	}

	[WebMethod]
	public RetType getbilldetailsoperation(string SchoolName,string StudentName,string EnrollmentNo)
	{
        string Paymentdate = DateTime.Now.ToString("dd/MM/yyyy");
        SoapContext objSC = new SoapContext();
        TBLFEDERALREQUESTDETAIL objFB = new TBLFEDERALREQUESTDETAIL();
        RetType obj = new RetType();
        string Install1 = "", Install2 = "", Install3 = "", Install4 = "";
        try
        {
            var Concession = objSC.View_GetConcessionDetails.Where(r => r.ENROLLMENTNO == EnrollmentNo.Trim().ToUpper()).FirstOrDefault();
            var FeeSetting = objSC.View_GetFeeSettings.Where(r => r.ENROLLMENTNO == EnrollmentNo.Trim().ToUpper()).ToList();
            string Studentname = Concession.STUDENTNAME;
            double PendingAmount = 0, Due = 0, ConcessionAmount = 0;


            if (Concession != null)
            {
                if (Concession.CONCESSION == "YES")
                {
                    ConcessionAmount = Convert.ToDouble(Concession.CONCESSIONPERCENTAGE);
                }
            }
            if (FeeSetting != null)
            {
                for (int i = 0; i < FeeSetting.Count; i++)
                {
                    double Amount = 0,InstPendingAmount=0,InstFine=0;

                    string Installment = FeeSetting[i].FEETYPE;
                    var FeesPaid = objSC.View_GetPaidFees.Where(r => r.ENROLLMENTNO == EnrollmentNo.Trim().ToUpper() && r.FEETYPE == Installment).ToList();
                    if (FeesPaid.Count > 0)
                    {
                        for (int j = 0; j < FeesPaid.Count; j++)
                        {
                            Amount = Amount + Convert.ToDouble(FeesPaid[j].AMOUNT);
                        }
                        
                        PendingAmount += Convert.ToDouble(FeeSetting[i].AMOUNT) - Amount;
                        InstPendingAmount = Convert.ToDouble(FeeSetting[i].AMOUNT) - Amount;
                        
                    }
                    else
                    {
                        Amount = Amount + Convert.ToDouble(FeeSetting[i].AMOUNT);
                        PendingAmount += Amount;
                        InstPendingAmount = Convert.ToDouble(FeeSetting[i].AMOUNT);

                    }
                   

                    DateTime duedate = Convert.ToDateTime(FeeSetting[i].DUEDATE).Date;
                    string[] DATESPLIT = Paymentdate.Split('/');
                    string actualdate = DATESPLIT[1] + "/" + DATESPLIT[0] + "/" + DATESPLIT[2];
                    DateTime dt1 = Convert.ToDateTime(actualdate).Date;

                  
                    if (PendingAmount != 0)
                    {
                        if (dt1 > duedate)
                        {
                            int LATEBYDAYS = (dt1 - duedate).Days;
                            Due += LATEBYDAYS * Convert.ToDouble(FeeSetting[i].INSTALLMENTFINE);
                            InstFine = LATEBYDAYS * Convert.ToDouble(FeeSetting[i].INSTALLMENTFINE);
                        }
                        
                    }
                    if (InstPendingAmount == 0)
                    {
                        if (Installment == "INSTALLMENT 1")
                        {
                            Install1 = "INSTALLMENT 1-PAID";
                        }
                        if (Installment == "INSTALLMENT 2")
                        {
                            Install2 = "INSTALLMENT 2-PAID";
                        }
                        if (Installment == "INSTALLMENT 3")
                        {
                            Install3 = "INSTALLMENT 3-PAID";
                        }
                        if (Installment == "INSTALLMENT 4")
                        {
                            Install4 = "INSTALLMENT 4-PAID";
                        }

                    }
                    else
                    {
                        if (Installment == "INSTALLMENT 1")
                        {
                            Install1 = "INSTALLMENT 1 : " + InstPendingAmount + " - FINE : " + InstFine + "";
                        }
                        if (Installment == "INSTALLMENT 2")
                        {
                            Install2 = "INSTALLMENT 2 : " + InstPendingAmount + " - FINE : " + InstFine + "";

                        }
                        if (Installment == "INSTALLMENT 3")
                        {
                            Install3 = "INSTALLMENT 3 : " + InstPendingAmount + " - FINE : " + InstFine + "";

                        }
                        if (Installment == "INSTALLMENT 4")
                        {
                            Install4 = "INSTALLMENT 4 : " + InstPendingAmount + " - FINE : " + InstFine + "";

                        }

                    }


                }
                string REQID = "", REQUESTID = "";
                var CurrentRequestId = objSC.View_GETFEDERALREQUESTID.OrderByDescending(r => r.BANKREQUESTID).FirstOrDefault();
                if (CurrentRequestId != null)
                {
                    REQID = CurrentRequestId.REQUESTID;
                }
                if (REQID == "" || REQID == null)
                {
                    REQUESTID = "FB00000001";
                }
                else
                {
                    int NO = int.Parse(REQID) + 1;
                    REQUESTID = "FB" + String.Format("{0:D8}", NO);
                }
                if (REQUESTID != null)
                {
                    objFB.REQUESTID = REQUESTID;
                    objFB.ENROLLMENTNO = EnrollmentNo.ToString().ToUpper();
                    objFB.REQUESTDATE = DateTime.Now;
                    objSC.TBLFEDERALREQUESTDETAILS.Add(objFB);
                    objSC.SaveChanges();

                }
                double GrandPending = 0;
                if (PendingAmount != 0)
                {
                    GrandPending = PendingAmount - ConcessionAmount;
                    if (GrandPending != 0)
                    {
                        GrandPending = GrandPending + Due;
                    }
                }
                obj.out1 = REQUESTID;
                obj.out2 = (GrandPending).ToString();
                obj.out3 = Studentname.ToString();
                obj.out4 = EnrollmentNo.Trim().ToUpper();
                obj.out5 = Install1;
                obj.out6 = Install2;
                obj.out7 = Install3;
                obj.out8 = Install4;

            }
        }
        catch(Exception e)
        {
            obj.out1 = e.ToString();
        }

        return obj;
	}

    

}
