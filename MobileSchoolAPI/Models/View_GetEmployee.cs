namespace MobileSchoolAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class View_GetEmployee
    {
        [StringLength(20)]
        public string Staff { get; set; }

        [StringLength(20)]
        public string LATE { get; set; }

        [StringLength(20)]
        public string EARLY { get; set; }

        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long EMPLOYEEID { get; set; }

        [StringLength(50)]
        public string EMPLOYEENAME { get; set; }

        public long? DEPARTMENTID { get; set; }

        [StringLength(10)]
        public string GENDER { get; set; }

        [StringLength(250)]
        public string ADDRESS { get; set; }

        [StringLength(250)]
        public string PERNMANTADDRESS { get; set; }

        [StringLength(11)]
        public string MOBILENO { get; set; }

        [StringLength(50)]
        public string SUBJECT { get; set; }

        [StringLength(10)]
        public string COURSE { get; set; }

        [StringLength(50)]
        public string BRANCH { get; set; }

        [StringLength(50)]
        public string EDUYEAR { get; set; }

        [StringLength(50)]
        public string OTHERDETAILS { get; set; }

        [StringLength(50)]
        public string IMAGEPATH { get; set; }

        [StringLength(50)]
        public string REFERAL { get; set; }

        [StringLength(50)]
        public string PARENTOCCUPATION { get; set; }

        [StringLength(50)]
        public string CITY { get; set; }

        [StringLength(50)]
        public string STATE { get; set; }

        [StringLength(50)]
        public string COUNTRY { get; set; }

        [StringLength(50)]
        public string ZIP { get; set; }

        [StringLength(50)]
        public string PARENTNAME { get; set; }

        public DateTime? DATEOFBIRTH { get; set; }

        [StringLength(400)]
        public string PARENTADDRESS { get; set; }

        [StringLength(400)]
        public string PARENTPERNMANTADDRESS { get; set; }

        public int? DISPLAY { get; set; }

        public int? COMPANYID { get; set; }

        public int? CREATEDID { get; set; }

        public DateTime? CREATEDON { get; set; }

        public int? UPDATEDID { get; set; }

        public DateTime? UPDATEDON { get; set; }

        [StringLength(50)]
        public string LANDMARKC { get; set; }

        [StringLength(50)]
        public string LANDMARKP { get; set; }

        [StringLength(50)]
        public string CITYP { get; set; }

        [StringLength(50)]
        public string STATEP { get; set; }

        [StringLength(50)]
        public string COUNTRYP { get; set; }

        [StringLength(50)]
        public string POSTALCODEP { get; set; }

        [StringLength(50)]
        public string PHONENO { get; set; }

        [StringLength(50)]
        public string PHONENOP { get; set; }

        [StringLength(50)]
        public string MOBILENOP { get; set; }

        [StringLength(50)]
        public string PARENTLANDMARK { get; set; }

        [StringLength(50)]
        public string PARENTLANDMARKP { get; set; }

        [StringLength(50)]
        public string PARENTCITY { get; set; }

        [StringLength(50)]
        public string PARENTCITYP { get; set; }

        [StringLength(50)]
        public string PARENTSTATE { get; set; }

        [StringLength(50)]
        public string PARENTSTATEP { get; set; }

        [StringLength(50)]
        public string PARENTCOUNTRY { get; set; }

        [StringLength(50)]
        public string PARENTCOUNTRYP { get; set; }

        [StringLength(50)]
        public string PARENTZIP { get; set; }

        [StringLength(50)]
        public string PARENTZIPP { get; set; }

        [StringLength(50)]
        public string PARENTMOBILENOP { get; set; }

        [StringLength(50)]
        public string PARENTPHONENO { get; set; }

        [StringLength(50)]
        public string PARENTPHONENOP { get; set; }

        [StringLength(50)]
        public string APPLIEDFOR { get; set; }

        public DateTime? JOININGDATE { get; set; }

        [StringLength(50)]
        public string EXPSALARY { get; set; }

        [StringLength(50)]
        public string EXPERIENCE { get; set; }

        [StringLength(50)]
        public string EXCOMPANY { get; set; }

        [StringLength(50)]
        public string WORKINGSINCE { get; set; }

        [StringLength(50)]
        public string POST { get; set; }

        [StringLength(50)]
        public string EXISALARY { get; set; }

        [StringLength(50)]
        public string JOBPROFILE { get; set; }

        public int? COURSEID { get; set; }

        [StringLength(50)]
        public string STAFFCATEGORY { get; set; }

        [StringLength(70)]
        public string ALTERNATEEMAIL { get; set; }

        [StringLength(70)]
        public string PARENTEMAIL { get; set; }

        [StringLength(70)]
        public string ALTERNATEPARENTMAIL { get; set; }

        [StringLength(50)]
        public string REFERENCEPHNO { get; set; }

        [StringLength(80)]
        public string REFERENCEEMAILID { get; set; }

        public long? ENQUIRYNO { get; set; }

        public int? SUBJECTID { get; set; }

        [StringLength(25)]
        public string RENUMERATIONTYPE { get; set; }

        [StringLength(25)]
        public string DEPARTMENTTYPE { get; set; }

        [StringLength(50)]
        public string BASICSALARY { get; set; }

        public DateTime? ACTUALJOININGDATE { get; set; }

        [StringLength(350)]
        public string CURRENTJOBPROFILE { get; set; }

        [StringLength(90)]
        public string EMAILID { get; set; }

        public long? ROLEID { get; set; }

        [StringLength(30)]
        public string ACCOUNTNO { get; set; }

        [StringLength(60)]
        public string ACCOUNTNAME { get; set; }

        [StringLength(50)]
        public string BRANCHNAME { get; set; }

        [StringLength(60)]
        public string BANKNAME { get; set; }

        [StringLength(30)]
        public string IFSCCODE { get; set; }

        public int? SUBDEPARTMENTID { get; set; }

        public int? DESIGNATIONID { get; set; }

        [StringLength(60)]
        public string APPOINTMENTTYPE { get; set; }

        [StringLength(350)]
        public string APPROVEDBYUNIVERSITY { get; set; }

        [StringLength(350)]
        public string APPROVEDBYGOVERNMENT { get; set; }

        [StringLength(20)]
        public string APPOINTMENTFULLPARTTIME { get; set; }

        [StringLength(250)]
        public string PAYSCALE { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? HRA { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? OTHERALLOWANCE { get; set; }

        [StringLength(450)]
        public string DOCTRATEDEGREE { get; set; }

        [StringLength(450)]
        public string PGDEGREE { get; set; }

        [StringLength(450)]
        public string UGDEGREE { get; set; }

        [StringLength(450)]
        public string OTHERQUALIFICATION { get; set; }

        [StringLength(10)]
        public string PERMANENTS { get; set; }

        public int? CASTID { get; set; }

        public int? SUBCASTID { get; set; }

        [StringLength(50)]
        public string PANNO { get; set; }

        [StringLength(50)]
        public string PFNUMBER { get; set; }

        [StringLength(60)]
        public string RELIGION { get; set; }

        [StringLength(80)]
        public string PROFILEIMAGEPATH { get; set; }

        [StringLength(50)]
        public string EMPCODE { get; set; }

        [StringLength(50)]
        public string AADHARCARDNO { get; set; }

        [StringLength(5)]
        public string TEMP { get; set; }

        public long? TITLEID { get; set; }

        [StringLength(20)]
        public string SHIFTTIMINGFROM { get; set; }

        [StringLength(20)]
        public string SHIFTTIMINGTO { get; set; }

        [StringLength(50)]
        public string SHIFTID { get; set; }

        [StringLength(50)]
        public string PTALUKA { get; set; }

        [StringLength(50)]
        public string CTALUKA { get; set; }

        public string PCITYVILLAGE { get; set; }

        public string CCITYVILLAGE { get; set; }

        [StringLength(50)]
        public string UAN { get; set; }

        [StringLength(50)]
        public string CATEGORYID { get; set; }

        [StringLength(50)]
        public string ALLOCATION { get; set; }

        [StringLength(50)]
        public string JOBTYPE { get; set; }

        [StringLength(500)]
        public string BANKADDRESS { get; set; }

        [StringLength(50)]
        public string MICRNO { get; set; }

        [StringLength(50)]
        public string ISLINKED { get; set; }

        public string IMAGEPATHSIGN { get; set; }

        [StringLength(50)]
        public string SECTION { get; set; }

        //public long? EMPLOYEETYPEID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long UserId { get; set; }

        [StringLength(50)]
        public string UserName { get; set; }

        [StringLength(100)]
        public string Password { get; set; }

        [StringLength(20)]
        public string Expr1 { get; set; }

        [StringLength(50)]
        public string UserType { get; set; }

        public int? Expr2 { get; set; }

        public int? Expr3 { get; set; }

        public int? Expr4 { get; set; }

        public DateTime? Expr5 { get; set; }

        public int? Expr6 { get; set; }

        public DateTime? Expr7 { get; set; }

        [StringLength(10)]
        public string STATUS { get; set; }

        public int? INSTITUTEID { get; set; }

        [StringLength(80)]
        public string Expr8 { get; set; }

        [StringLength(50)]
        public string ISPASSWORDCHANGED { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Expr9 { get; set; }

        [StringLength(100)]
        public string SHIFTTYPE { get; set; }

        public int? Expr10 { get; set; }
    }
}
