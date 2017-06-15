using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace HrmsObjects.Details
{
    [DataContract]
    public class Employee
    {
        [DataMember]
        public string BranchName { get; set; }
        [DataMember]
        public Int64 BranchId { get; set; }
        [DataMember]
        public string DepartmentName { get; set; }
        [DataMember]
        public Int64 DepartmentId { get; set; }
        [DataMember]
        public string DesignationName { get; set; }
        [DataMember]
        public Int64 DesignationId { get; set; }
        [DataMember]
        public string EmployeeName { get; set; }
        [DataMember]
        public Int64 EmployeeId { get; set; }
        [DataMember]
        public string EmployeeCode { get; set; }
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public string DateOfBirth { get; set; }
        [DataMember]
        public string Age { get; set; }
        [DataMember]
        public int BloodGroupFlag { get; set; }
        [DataMember]
        public int GenderFlag { get; set; }
        [DataMember]
        public int MaritalStatus { get; set; }
        [DataMember]
        public string MobileNo { get; set; }
        [DataMember]
        public int Religion { get; set; }
        [DataMember]
        public string Nationality { get; set; }
        [DataMember]
        public string EmailID { get; set; }
        [DataMember]
        public string LanguageKnown { get; set; }
        [DataMember]
        public string Address { get; set; }
        [DataMember]
        public string EmergencyContact { get; set; }
        [DataMember]
        public int CategoryId { get; set; }
        [DataMember]
        public int ReportingManagerId { get; set; }
        [DataMember]
        public string DateOfJoining { get; set; }
        [DataMember]
        public string DateOfResign { get; set; }
        [DataMember]
        public string OfficialMailId { get; set; }
        [DataMember]
        public int ProbationaryPeriod { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public int PassPortTypeFlag { get; set; }
        [DataMember]
        public string PassPortNo { get; set; }
        [DataMember]
        public string PassPortIssuePlace { get; set; }
        [DataMember]
        public string PassPortIssueCountry { get; set; }
        [DataMember]
        public string PassPortDateIssue { get; set; }
        [DataMember]
        public string PassPortDateExpiry { get; set; }
        [DataMember]
        public int VisaTypeFlag { get; set; }
        [DataMember]
        public string VisaNo { get; set; }
        [DataMember]
        public string VisaDateIssue { get; set; }
        [DataMember]
        public string VisaDateExpiry { get; set; }
        [DataMember]
        public string PanNo { get; set; }
        [DataMember]
        public int DriveLiceTypeFlag { get; set; }
        [DataMember]
        public string DriveLiceNo { get; set; }
        [DataMember]
        public string DriveLiceDateIssue { get; set; }
        [DataMember]
        public string DriveLiceDateExpiry { get; set; }
        [DataMember]
        public Int64 CreatedBy { get; set; }
        [DataMember]
        public Int64 TotalRecords { get; set; }
        [DataMember]
        public Int64 EmployeeQualificationId { get; set; }
        [DataMember]
        public string Qualification { get; set; }
        [DataMember]
        public string MediumOfInstruction { get; set; }
        [DataMember]
        public string UniversityName { get; set; }
        [DataMember]
        public string CertificateNo { get; set; }
        [DataMember]
        public string Percentage { get; set; }
        [DataMember]
        public int YearOfPassOut { get; set; }
        [DataMember]
        public Int64 EmployeeExprienceId { get; set; }
        [DataMember]
        public string OrganizationName { get; set; }
        [DataMember]
        public string WebSite { get; set; }
        [DataMember]
        public string WorkedAs { get; set; }
        [DataMember]
        public string EmpFromperiod { get; set; }
        [DataMember]
        public string EmpToperiod { get; set; }
        [DataMember]
        public string ReferenceManagerOrHrName { get; set; }
        [DataMember]
        public string RefContactNo { get; set; }
        [DataMember]
        public Int64 EmployeeLeaveId { get; set; }
        [DataMember]
        public string LeaveType { get; set; }
        [DataMember]
        public Int64 LTypeID { get; set; }
        [DataMember]
        public int Days { get; set; }
        [DataMember]
        public string LeaveFromDate { get; set; }
        [DataMember]
        public string LeaveToDate { get; set; }
        [DataMember]
        public Int64 EmployeeAssetId { get; set; }
        [DataMember]
        public string AssetName { get; set; }
        [DataMember]
        public string SerialNo { get; set; }
        [DataMember]
        public int ResignFlag { get; set; }
        [DataMember]
        public string AssetDate { get; set; }
        [DataMember]
        public string LeaveTypeIdAndDays { get; set; }
        [DataMember]
        public string LeaveTypeId { get; set; }
        [DataMember]
        public decimal RemainingDays{ get; set; }
    }
}
