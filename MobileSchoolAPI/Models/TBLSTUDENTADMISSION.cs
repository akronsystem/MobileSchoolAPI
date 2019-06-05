namespace MobileSchoolAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TBLSTUDENTADMISSION")]
    public partial class TBLSTUDENTADMISSION
    {
        [Key]
        public long STUDENTID { get; set; }

        public DateTime? ADMISSIONDATE { get; set; }

        [StringLength(200)]
        public string STUDENTNAME { get; set; }

        [StringLength(200)]
        public string FATHERNAME { get; set; }

        [StringLength(200)]
        public string MOTHERNAME { get; set; }

        public DateTime? DOB { get; set; }

        [StringLength(15)]
        public string GENDER { get; set; }

        [StringLength(10)]
        public string BLOOGGROUP { get; set; }

        [StringLength(50)]
        public string PHC { get; set; }

        [StringLength(100)]
        public string DENTALHYGIENE { get; set; }

        [StringLength(15)]
        public string HEIGHT { get; set; }

        [StringLength(15)]
        public string VISIONL { get; set; }

        [StringLength(15)]
        public string VISIONR { get; set; }

        [StringLength(15)]
        public string WEIGHT { get; set; }

        [StringLength(30)]
        public string MOTHERTOUNGE { get; set; }

        [StringLength(30)]
        public string RELIGION { get; set; }

        [StringLength(30)]
        public string NATIONALITY { get; set; }

        [StringLength(30)]
        public string COMMUNITY { get; set; }

        [StringLength(30)]
        public string CASTE { get; set; }

        [StringLength(200)]
        public string IDENTITYMARK { get; set; }

        [StringLength(200)]
        public string IDENTITYMARK1 { get; set; }

        [StringLength(15)]
        public string MOBILENO { get; set; }

        [StringLength(15)]
        public string RESMOBILENO { get; set; }

        [StringLength(40)]
        public string UIDNO { get; set; }

        [StringLength(100)]
        public string EMAIL { get; set; }

        [StringLength(30)]
        public string ACADEMICYEAR { get; set; }

        public int? COURSEID { get; set; }

        [StringLength(15)]
        public string JOININGMEDIUM { get; set; }

        public int? SECTION { get; set; }

        public int? STANDARDID { get; set; }

        [StringLength(50)]
        public string GNAME { get; set; }

        [StringLength(40)]
        public string GUIDNO { get; set; }

        [StringLength(200)]
        public string GOCCUPATION { get; set; }

        [StringLength(100)]
        public string GQUALIFICATION { get; set; }

        [StringLength(100)]
        public string GEMAIL { get; set; }

        [StringLength(15)]
        public string GMOBILE { get; set; }

        [StringLength(50)]
        public string MNAME { get; set; }

        [StringLength(40)]
        public string MUIDNO { get; set; }

        [StringLength(200)]
        public string MOCCUPATION { get; set; }

        [StringLength(100)]
        public string MQUALIFICATION { get; set; }

        [StringLength(100)]
        public string MEMAIL { get; set; }

        [StringLength(15)]
        public string MMOBILE { get; set; }

        [StringLength(300)]
        public string CADDRESS { get; set; }

        [StringLength(50)]
        public string CCITY { get; set; }

        [StringLength(50)]
        public string CDISTRICT { get; set; }

        [StringLength(50)]
        public string CSTATE { get; set; }

        [StringLength(15)]
        public string CPINCODE { get; set; }

        [StringLength(50)]
        public string CCOUNTRY { get; set; }

        [StringLength(300)]
        public string PADDRESS { get; set; }

        [StringLength(50)]
        public string PCITY { get; set; }

        [StringLength(50)]
        public string PDISTRICT { get; set; }

        [StringLength(50)]
        public string PSTATE { get; set; }

        [StringLength(15)]
        public string PPINCODE { get; set; }

        [StringLength(50)]
        public string PCOUNTRY { get; set; }

        [StringLength(25)]
        public string INCOMEDETAIL { get; set; }

        [StringLength(25)]
        public string CERTIFICATENO { get; set; }

        public DateTime? CERTISSUEDATE { get; set; }

        [StringLength(50)]
        public string ACCOUNTNAME { get; set; }

        [StringLength(50)]
        public string ACCOUNTNO { get; set; }

        [StringLength(50)]
        public string BRANCHNAME { get; set; }

        [StringLength(50)]
        public string BANKNAME { get; set; }

        [StringLength(15)]
        public string IFSCCODE { get; set; }

        [StringLength(25)]
        public string MICRCODE { get; set; }

        [StringLength(100)]
        public string INSTITUTIONNAME { get; set; }

        [StringLength(50)]
        public string COURSESTUDIED { get; set; }

        [StringLength(300)]
        public string ADDRESS { get; set; }

        [StringLength(15)]
        public string MEDIUM { get; set; }

        [StringLength(25)]
        public string HALLTICKETNO { get; set; }

        [StringLength(15)]
        public string YEAROFPASSING { get; set; }

        [StringLength(50)]
        public string TCNUMBER { get; set; }

        [StringLength(15)]
        public string MARKSOBTAINED { get; set; }

        [StringLength(300)]
        public string OTHERDETAILS { get; set; }

        [StringLength(10)]
        public string PROCESS { get; set; }

        [StringLength(5)]
        public string SCHOLORSHIPYESNO { get; set; }

        [StringLength(300)]
        public string SDESCRIPTION { get; set; }

        [StringLength(25)]
        public string REFEREDBY { get; set; }

        [StringLength(50)]
        public string REFEREDNAME { get; set; }

        [StringLength(200)]
        public string ATTACHEDDOCUMENTS { get; set; }

        [StringLength(200)]
        public string IMAGEPATH { get; set; }

        public int? COMPANYID { get; set; }

        public int? CREATEDID { get; set; }

        public DateTime? CREATEDON { get; set; }

        public int? UPDATEDID { get; set; }

        public DateTime? UPDATEDON { get; set; }

        [StringLength(10)]
        public string STATUS { get; set; }

        [StringLength(60)]
        public string ENROLLMENTNO { get; set; }

        [StringLength(60)]
        public string UNIQUEID { get; set; }

        public long? PHYCHALLENGEDID { get; set; }

        public long? COURSEYEARID { get; set; }

        [StringLength(50)]
        public string DOMECIAL { get; set; }

        public int? SUBCASTID { get; set; }

        [StringLength(5)]
        public string CAPPROCESS { get; set; }

        public int? SCHOLERSHIPID { get; set; }

        public long? FYFEEID { get; set; }

        public long? SYFEEID { get; set; }

        public long? TYFEEID { get; set; }

        [StringLength(25)]
        public string ROLLNO { get; set; }

        public long? FEEID { get; set; }

        [StringLength(5)]
        public string TFWS { get; set; }

        [StringLength(30)]
        public string INSTITUTECODE { get; set; }

        public int? DIRECTSECONDYEARSTATUS { get; set; }

        [StringLength(50)]
        public string ADMISSIONTYPE { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? PROVISIONALFEE { get; set; }

        [StringLength(50)]
        public string PLACEOFBIRTH { get; set; }

        [StringLength(10)]
        public string PROGRESS { get; set; }

        [StringLength(300)]
        public string CONDUCT { get; set; }

        [StringLength(10)]
        public string LEAVEREASON { get; set; }

        [StringLength(100)]
        public string REMARK { get; set; }

        public DateTime? LEAVEDATE { get; set; }

        [StringLength(3)]
        public string VERIFY { get; set; }

        [StringLength(3)]
        public string HODVERIFY { get; set; }

        public long? HODVERIFYBY { get; set; }

        [StringLength(20)]
        public string ADMISSIONSTATUS { get; set; }

        public long? BOARDID { get; set; }

        public long? TRANSPORTID { get; set; }

        public long? BUSID { get; set; }

        public long? STOPID { get; set; }

        [StringLength(3)]
        public string HOSTELSTATUS { get; set; }

        [StringLength(550)]
        public string COMPANY { get; set; }

        [StringLength(200)]
        public string PACKAGE { get; set; }

        public string JOBPROFILE { get; set; }

        [StringLength(250)]
        public string EXPERIENCE { get; set; }

        [StringLength(6)]
        public string Aluminiregister { get; set; }

        public long? AluminId { get; set; }

        public string DOCID { get; set; }

        public string DOCNAME { get; set; }

        public long? SIBLINGSTANDARDID { get; set; }

        public long? SIBLINGDIVISIONID { get; set; }

        public long? SIBLINGSTUDENTID { get; set; }

        [StringLength(50)]
        public string LCISSUED { get; set; }

        public int? STATEID { get; set; }

        public int? CITYID { get; set; }

        public int? TALUKAID { get; set; }

        public string OCCUPATIONDETAILS { get; set; }

        public string UDISENO { get; set; }

        public string LOCALE { get; set; }

        public string DATEOFBIRTHINWORDS { get; set; }

        public string ADMITTEDTOCLASS { get; set; }

        public DateTime? VALIDDATE { get; set; }

        [StringLength(15)]
        public string EMERGENCYCONTACTNO { get; set; }

        [StringLength(50)]
        public string GRNO { get; set; }

        public short? PSTATEID { get; set; }

        public short? PCITYID { get; set; }

        public short? PTALUKAID { get; set; }

        [StringLength(5)]
        public string ADMISSIONDIVISION { get; set; }

        [StringLength(10)]
        public string BLOCKNO { get; set; }

        public int? CATEGORYID { get; set; }

        [StringLength(50)]
        public string SARALNO { get; set; }

        [StringLength(50)]
        public string STAFFMEMBER { get; set; }

        public DateTime? FATHERBIRTHDATE { get; set; }

        [StringLength(50)]
        public string FATHERAGE { get; set; }

        public DateTime? MOTHERBIRTHDATE { get; set; }

        [StringLength(50)]
        public string MOTHERAGE { get; set; }

        [StringLength(500)]
        public string MOTHEROCCUPATION { get; set; }

        [StringLength(500)]
        public string MOTHERQUALIFICATION { get; set; }

        public DateTime? WEDDINGDAY { get; set; }

        [StringLength(50)]
        public string OFFICETELEPHONE { get; set; }

        [StringLength(50)]
        public string RESIDENCETELEPHONE { get; set; }

        [StringLength(50)]
        public string LEARNINGDISABILITY { get; set; }

        [StringLength(50)]
        public string DISEASENAME { get; set; }

        [StringLength(150)]
        public string SPECIALREMARK { get; set; }

        [StringLength(500)]
        public string SUGGESTEDTREATMENT { get; set; }

        public DateTime? DOJ { get; set; }

        [StringLength(500)]
        public string DOCSTATUS { get; set; }

        [StringLength(500)]
        public string DOCREMARKS { get; set; }

        [StringLength(500)]
        public string OTHERDOCUMENT { get; set; }

        [StringLength(500)]
        public string OTHDOCSTATUS { get; set; }

        [StringLength(500)]
        public string OTHDOCREMARKS { get; set; }

        [StringLength(50)]
        public string FAX { get; set; }

        [StringLength(150)]
        public string DISABILITYDOC { get; set; }

        [StringLength(50)]
        public string MINORITY { get; set; }

        public int? MINORITYID { get; set; }

        public string REASON { get; set; }

        public DateTime? LCISSUEDATE { get; set; }
    }
}
