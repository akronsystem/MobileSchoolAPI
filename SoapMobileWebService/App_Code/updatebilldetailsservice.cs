using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

/// <summary>
/// Summary description for updatebilldetailsservice
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class updatebilldetailsservice : System.Web.Services.WebService
{
    public class RetType
    {
        public string out1 { get; set; }
        public string out2 { get; set; }
        public string out3 { get; set; }
        public string out4 { get; set; }
        public string out5 { get; set; }

    }
    public updatebilldetailsservice()
	{

		//Uncomment the following line if using designed components 
		//InitializeComponent(); 
	}

	

    [WebMethod]
    public RetType updatebilldetailsoperation(string TransactionId,string TransactionDate,string Amount,string Mode,string RequestId,string EnrollmentNo)
    {
        SoapContext db = new SoapContext();
        TBLFEECOLLECTIONNKVSFEDERAL objFEE = new TBLFEECOLLECTIONNKVSFEDERAL();
        TBLRECEIPTTABLENEWFEDEREAL objREC = new TBLRECEIPTTABLENEWFEDEREAL();
        
        TBLFEDERALREQUESTDETAIL objFED = db.TBLFEDERALREQUESTDETAILS.Where(r => r.REQUESTID == RequestId).FirstOrDefault();
        RetType obj = new RetType();
        string Status = "F";

        try
        {
            string PaymentType = "";
            if (Mode == "C")
            {
                PaymentType = "CASH";
            }
            if (Mode == "T")
            {
                PaymentType = "TRANSFER";
            }
            double AmountReceived = 0;
            if (Amount != "")
            {
                AmountReceived = Convert.ToDouble(Amount);
            }
            bool flag = false;
            var FeeSetting = db.View_GetFeeSettings.Where(r => r.ENROLLMENTNO == EnrollmentNo.Trim().ToUpper()).ToList();
            var StudentData = db.View_GetSudentStandard.Where(r => r.ENROLLMENTNO == EnrollmentNo.Trim().ToUpper()).FirstOrDefault();
            var ReceiptNo = db.View_GetReceiptNo.OrderByDescending(r => r.RECEIPTID).FirstOrDefault();
            string StudReceiptNo = "", value = "";
            if (ReceiptNo != null)
            {
                if (ReceiptNo.RECEIPTNO != "")
                {
                    int NO = int.Parse(ReceiptNo.RECEIPTNO) + 1;
                    value = String.Format("{0:D5}", NO);
                }


            }
            StudReceiptNo = "A-" + FeeSetting[0].ACADEMICYEAR + "/" + value;

            if (FeeSetting != null)
            {
                if (AmountReceived != 0)
                {
                    for (int i = 0; i < FeeSetting.Count; i++)
                    {
                        double PaidAmount = 0, PendingAmount = 0;
                        double InstAmount = 0, Due = 0;
                        InstAmount = Convert.ToDouble(FeeSetting[i].AMOUNT);
                        string Installment = FeeSetting[i].FEETYPE;
                        DateTime DueDate = Convert.ToDateTime(FeeSetting[i].DUEDATE).Date;
                        var FeesPaid = db.View_GetPaidFees.Where(r => r.ENROLLMENTNO == EnrollmentNo.Trim().ToUpper() && r.FEETYPE == Installment).ToList();
                        if (FeesPaid.Count > 0)
                        {
                            for (int j = 0; j < FeesPaid.Count; j++)
                            {
                                PaidAmount = PaidAmount + Convert.ToDouble(FeesPaid[j].AMOUNT);
                            }

                            //PaidAmount = Convert.ToDouble(Amount);

                        }
                        else
                        {
                            PendingAmount = InstAmount;
                        }
                        if (PaidAmount != InstAmount && PaidAmount < InstAmount && AmountReceived>0)
                        {
                            flag = false;
                            PendingAmount = InstAmount - PaidAmount;
                            if (AmountReceived >= PendingAmount)
                            {
                                AmountReceived = AmountReceived - PendingAmount;


                                DateTime paymentdate = Convert.ToDateTime(TransactionDate).Date;
                                if (paymentdate > DueDate)
                                {
                                    int LATEBYDAYS = (paymentdate - DueDate).Days;
                                    Due = LATEBYDAYS * Convert.ToDouble(FeeSetting[i].INSTALLMENTFINE);

                                }
                                AmountReceived = AmountReceived - Due;
                                objFEE.ENROLLMENTNO = StudentData.ENROLLMENTNO;
                                objFEE.STUDENTID = StudentData.STUDENTID;
                                objFEE.STANDARDID = Convert.ToInt32(StudentData.STANDARDID);
                                objFEE.FEETYPEID = FeeSetting[i].FEETYPEID;
                                objFEE.AMOUNT = Convert.ToDecimal(PendingAmount);
                                objFEE.FINE = Convert.ToDecimal(Due);
                                objFEE.PAYMENTTYPE = PaymentType;



                                objFEE.RECEIPTNO = StudReceiptNo;
                                objFEE.CREATEDTIME = DateTime.Now.ToShortTimeString();
                                objFEE.CREATEDON = paymentdate;
                                objFEE.REQUESTID = RequestId;
                                objFEE.TRANSACTIONSTATUS = "Successful";

                                db.TBLFEECOLLECTIONNKVSFEDERALs.Add(objFEE);
                                int status = db.SaveChanges();
                                if (status > 0)
                                {
                                    flag = true;
                                    Status = "S";

                                }
                                else
                                {
                                    Status = "F";
                                }
                            }
                        }
                    }
                    if(flag==true)
                    {
                        objREC.STUDENTID = StudentData.STUDENTID.ToString();
                        objREC.RECEIPTNO = Convert.ToInt32( value);
                        objREC.ACADEMICYEAR = FeeSetting[0].ACADEMICYEAR;
                        db.TBLRECEIPTTABLENEWFEDEREALs.Add(objREC);
                        db.SaveChanges();

                        objFED.TRANSACTIONSTATUS = Status;
                        objFED.UPDATEDDATE = DateTime.Now;
                        db.SaveChanges();
                        
                    }


                }
            }
        }
        
        catch (Exception ex)
        {

        }
        RetType objRET = new RetType();
        objRET.out1 = Status;
        objRET.out2 = TransactionId;
        objRET.out3 = TransactionDate;
        return obj;
    }

}
