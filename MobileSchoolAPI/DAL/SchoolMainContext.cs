using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using MobileSchoolAPI.Models;

namespace MobileSchoolAPI 
{
	public abstract class SchoolMainContext	: DbContext
	{

		public SchoolMainContext(string name)
			: base(name)
		{

		}
        public virtual DbSet<VIEWNOTIFICATIONGEN> VIEWNOTIFICATIONGENs { get; set; }
        public virtual DbSet<VIEWGENERALNOTIFICATION> VIEWGENERALNOTIFICATIONs { get; set; }

        public virtual DbSet<ViewGetEmployeeBirthDetail> ViewGetEmployeeBirthDetails { get; set; }
        public virtual DbSet<View_UnreadNotificationCount> View_UnreadNotificationCount { get; set; }
        public virtual DbSet<TBLHOLIDAY> TBLHOLIDAYs { get; set; }
        public virtual DbSet<ViewGetTodayBirthDetail> ViewGetTodayBirthDetails { get; set; }
        public virtual DbSet<VIEWALLNOTIFICATION> VIEWALLNOTIFICATIONs { get; set; }
        public virtual DbSet<TBLDeviceRegistration> TBLDeviceRegistrations { get; set; }
        public virtual DbSet<VW_DEVICE> VW_DEVICE { get; set; }
 
        public virtual DbSet<VW_GET_STANDARD_BY_DIVISION> VW_GET_STANDARD_BY_DIVISION { get; set; }
 
        public virtual DbSet<TBLUSERLOGIN> TBLUSERLOGINs { get; set; }
		public virtual DbSet<VIEWATTENDANCE> VIEWATTENDANCEs { get; set; }

		public virtual DbSet<VIEWGETSTUDENTATT> VIEWGETSTUDENTATTs { get; set; }
		public virtual DbSet<VW_STUDENT_INFO> VW_STUDENT_INFO { get; set; }

		public virtual DbSet<VW_EMPLOYEE> VW_EMPLOYEE { get; set; }
		public virtual DbSet<VIEWHOMEWORK> VIEWHOMEWORKs { get; set; }
		public virtual DbSet<VIEWDIVISIONLIST> VIEWDIVISIONLISTs { get; set; }
		public virtual DbSet<VIEWDIVISIONLISTBYEMP> VIEWDIVISIONLISTBYEMPs { get; set; }
		public virtual DbSet<VIEWCLASSTEACHER> VIEWCLASSTEACHERs { get; set; }

		public virtual DbSet<VWATTENDANCEBYDATESTUDENT> VWATTENDANCEBYDATESTUDENTs { get; set; }
        public virtual DbSet<Vw_ATTENDANCECHECK> Vw_ATTENDANCECHECK { get; set; }
        public virtual DbSet<VIEWATTENDANCECHECK> VIEWATTENDANCECHECKs { get; set; }
		public virtual DbSet<VW_GET_USER_TYPE> VW_GET_USER_TYPE { get; set; }
        public virtual DbSet<VW_DATEWISECLASSSTATUSATTENDANCE> VW_DATEWISECLASSSTATUSATTENDANCE { get; set; }

        public virtual DbSet<TBLASSIGNCLASSTEACHER> TBLASSIGNCLASSTEACHERs { get; set; }

       // public virtual DbSet<TBLASSIGNCLASSTEACHER> TBLASSIGNCLASSTEACHERs { get; set; }


        public virtual DbSet<TBLMSGHISTORY> TBLMSGHISTORies { get; set; }



        public virtual DbSet<VWATTENDANCEEMPLOYEE> VWATTENDANCEEMPLOYEEs { get; set; }

		public virtual DbSet<VIEWEMPDIVISION> VIEWEMPDIVISIONs { get; set; }

		public virtual DbSet<VIEWSTUDENTDIVISION> VIEWSTUDENTDIVISIONs { get; set; }
		public virtual DbSet<VWSTUDENTINFO> VWSTUDENTINFO { get; set; }
		public virtual DbSet<VIEWSTUDENTHOMEWORK> VIEWSTUDENTHOMEWORKs { get; set; }



		public virtual DbSet<TBLATTENDENCEMASTER> TBLATTENDENCEMASTERs { get; set; }
		public virtual DbSet<TBLHOMEWORK> TBLHOMEWORKs { get; set; }
		public virtual DbSet<TBLATTENDENCE> TBLATTENDENCEs { get; set; }


		public virtual DbSet<VIEW_TERMMASTER> VIEW_TERMMASTER { get; set; }


        public virtual DbSet<VIEWDIVISIONWISESUBJECT> VIEWDIVISIONWISESUBJECTs { get; set; }



        public virtual DbSet<TBLNOTIFICATION> TBLNOTIFICATIONs { get; set; }
		public virtual DbSet<TBLNOTIFICATIONDETAIL> TBLNOTIFICATIONDETAILs { get; set; }
		public virtual DbSet<VIEWNOTIFICATION> VIEWNOTIFICATIONs { get; set; }
		public virtual DbSet<Vw_STANDARDLIST> Vw_STANDARDLIST { get; set; }
		public virtual DbSet<Vw_STUDSTANDARD> Vw_STUDSTANDARD { get; set; }
		public virtual DbSet<VIewAttendaceClasswiseCheck> VIewAttendaceClasswiseChecks { get; set; }

		public virtual DbSet<VIEWCHECKHOLIDAY> VIEWCHECKHOLIDAYs { get; set; }
		public virtual DbSet<vw_FETCHSTANDARDBYDIVISION> vw_FETCHSTANDARDBYDIVISION { get; set; }
		public virtual DbSet<VIEWDIVISIONLISTBYSTUDENT> VIEWDIVISIONLISTBYSTUDENTs { get; set; }
        public virtual DbSet<VIEWDIVISIONWISESUBJECTSTUDENT> VIEWDIVISIONWISESUBJECTSTUDENTs { get; set; }
      
        public virtual DbSet<VIEWSUBJECTNAME> VIEWSUBJECTNAMEs { get; set; }

        public virtual DbSet<VIEWGETUSERIDFROMEMPCODE> VIEWGETUSERIDFROMEMPCODEs { get; set; }

        public virtual DbSet<VW_GetGallery> VW_GetGallery { get; set; }
        public virtual DbSet<VW_EXAMSCHEDULE> VW_EXAMSCHEDULE { get; set; }
        public virtual DbSet<VW_UNITMASTER> VW_UNITMASTER { get; set; } 

        public virtual DbSet<VW_TESTTYPELIST> VW_TESTTYPELIST { get; set; }	   
        public virtual DbSet<ViewGetInstituteName> ViewGetInstituteNames { get; set; }
        public virtual DbSet<TBLTIMETABLESCHEDULE> TBLTIMETABLESCHEDULEs { get; set; }
        public virtual DbSet<TBLFEECOLLECTIONMASTER> TBLFEECOLLECTIONMASTERs { get; set; }
        public virtual DbSet<TBLSTANDARDMASTER> TBLSTANDARDMASTERs { get; set; }
        public virtual DbSet<View_DisplayFee> View_DisplayFee { get; set; }
        public virtual DbSet<TBLSTUDENTADMISSION> TBLSTUDENTADMISSIONs { get; set; }

        public virtual DbSet<View_FeeSetting> View_FeeSetting { get; set; }
        public virtual DbSet<View_RemainingFeeDisplay> View_RemainingFeeDisplay { get; set; }
        public virtual DbSet<View_DisplayStudentDetails> View_DisplayStudentDetails { get; set; }
        public virtual DbSet<View_DisplayPTAMember> View_DisplayPTAMember { get; set; }
        public virtual DbSet<View_Timetable> View_Timetable { get; set; }
        public virtual DbSet<View_GetTotalFees> View_GetTotalFees { get; set; }

        public virtual DbSet<View_GetPaidFees> View_GetPaidFees { get; set; }
        public virtual DbSet<TBLFEEMASTER> TBLFEEMASTERs { get; set; }
        public virtual DbSet<TBLFEETYPEMASTER> TBLFEETYPEMASTERs { get; set; }
        public virtual DbSet<View_GetFeeSettings> View_GetFeeSettings { get; set; }
        public virtual DbSet<TBLTRANSFERSTUDENT> TBLTRANSFERSTUDENTs { get; set; }
        public virtual DbSet<View_GETACADEMICYEAR> View_GETACADEMICYEAR { get; set; }
        public virtual DbSet<View_DisplayNotice> View_DisplayNotice { get; set; }
        public virtual DbSet<TBLLEAVEMASTER> TBLLEAVEMASTERs { get; set; }
        public virtual DbSet<TBLLEAVETYPEMASTER> TBLLEAVETYPEMASTERs { get; set; }
        public virtual DbSet<View_DisplayWeekDay> View_DisplayWeekDay { get; set; }
        public virtual DbSet<TBLEMPLOYEEMASTER> TBLEMPLOYEEMASTERs { get; set; }
        public virtual DbSet<View_StudentTimeTable> View_StudentTimeTable { get; set; }
        //  public virtual DbSet<TBLTRANSFERSTUDENT> TBLTRANSFERSTUDENTs { get; set; }
        public virtual DbSet<TBLTERMMASTERNEW> TBLTERMMASTERNEWs { get; set; }
        public virtual DbSet<View_DisplayMark_CycleTest> View_DisplayMark_CycleTest { get; set; }
        public virtual DbSet<View_GetTermwise_Cycle> View_GetTermwise_Cycle { get; set; }
        public virtual DbSet<TBLSUBJECTMASTER> TBLSUBJECTMASTERs { get; set; }
        public virtual DbSet<TBLASSIGNCOMPETENCy> TBLASSIGNCOMPETENCIES { get; set; }
        public virtual DbSet<TBLGRADEMASTER> TBLGRADEMASTERs { get; set; }
        public virtual DbSet<View_EventHolidayNotification> View_EventHolidayNotification { get; set; }
        public virtual DbSet<View_GetEmployee> View_GetEmployee { get; set; }
        public virtual DbSet<View_GetEmployeeWiseData> View_GetEmployeeWiseData { get; set; }

        public virtual DbSet<TBLRATINGDETAIL> TBLRATINGDETAILS { get; set; }
        public virtual DbSet<TBLRATINGMASTER> TBLRATINGMASTERs { get; set; }
        public virtual DbSet<TBLASSIGNSTAFF> TBLASSIGNSTAFFs { get; set; }
        public virtual DbSet<View_DisplayRate> View_DisplayRate { get; set; }
        public virtual DbSet<View_Communiation> View_Communiation { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder) 
		{
			modelBuilder.Entity<TBLUSERLOGIN>()
				.Property(e => e.EmpCode)
				.IsUnicode(false);

			modelBuilder.Entity<TBLUSERLOGIN>()
				.Property(e => e.ISPASSWORDCHANGED)
				.IsUnicode(false);
		}
	}
}