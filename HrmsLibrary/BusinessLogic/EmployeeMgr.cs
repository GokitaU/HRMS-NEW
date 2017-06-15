using HrmsLibrary.Common;
using HrmsLibrary.DataAccess;
using HrmsObjects.Details;
using HrmsObjects.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrmsLibrary.BusinessLogic
{
    [Serializable]
    public class EmployeeMgr
    {
        public List<Employee> BranchList()
        {
            EmployeeDbo objEmployeeDbo = new EmployeeDbo();
            return objEmployeeDbo.BranchList();
        }
        public List<Employee> DepartmentList()
        {
            EmployeeDbo objEmployeeDbo = new EmployeeDbo();
            return objEmployeeDbo.DepartmentList();
        }
        public List<Employee> DesignationList()
        {
            EmployeeDbo objEmployeeDbo = new EmployeeDbo();
            return objEmployeeDbo.DesignationList();
        }
        public List<Employee> EmployeeList()
        {
            EmployeeDbo objEmployeeDbo = new EmployeeDbo();
            return objEmployeeDbo.EmployeeList();
        }
        public List<Employee> LeaveList()
        {
            EmployeeDbo objEmployeeDbo = new EmployeeDbo();
            return objEmployeeDbo.LeaveList();
        }
        public List<Employee> LeaveTypeList(int EmployeeID)
        {
            EmployeeDbo objEmployeeDbo = new EmployeeDbo();
            return objEmployeeDbo.LeaveTypeList(EmployeeID);
        }
        public string Save(Employee PersonalObj, Employee OfficialObj, List<Employee> QualificationObj, List<Employee> ExprienceDetailObj, List<Employee> LeaveDetailObj, List<Employee> AssetDetailObj, User objUserObj)
        {
            EmployeeDbo objEmployeeDbo = new EmployeeDbo();
            string EmpID =  objEmployeeDbo.Save(PersonalObj);
            OfficialObj.EmployeeId = Convert.ToInt64(EmpID);
            objEmployeeDbo.SaveOfficial(OfficialObj);
            objUserObj.EmployeeId = Convert.ToInt64(EmpID);
            string Password = objUserObj.Password;
            UserDbo objUserDB = new UserDbo();
            objUserObj.Password = DataFactory.GetEncryptedData(Password);
            objUserDB.Create(objUserObj);
            if (QualificationObj != null)
            {
                foreach (Employee Qualilist in QualificationObj)
                {
                    Qualilist.CreatedBy = PersonalObj.CreatedBy;
                    Qualilist.EmployeeId = Convert.ToInt64(EmpID);
                    objEmployeeDbo.SaveQualification(Qualilist);
                }
            }
            if (ExprienceDetailObj != null)
            {
                foreach (Employee Explist in ExprienceDetailObj)
                {
                    Explist.CreatedBy = PersonalObj.CreatedBy;
                    Explist.EmployeeId = Convert.ToInt64(EmpID);
                    objEmployeeDbo.SaveExprience(Explist);
                }
            }
            if (LeaveDetailObj != null)
            {
                foreach (Employee Leavelist in LeaveDetailObj)
                {
                    Leavelist.CreatedBy = PersonalObj.CreatedBy;
                    Leavelist.EmployeeId = Convert.ToInt64(EmpID);
                    objEmployeeDbo.SaveLeave(Leavelist);
                }
            }
            if (AssetDetailObj != null)
            {
                foreach (Employee Assetlist in AssetDetailObj)
                {
                    Assetlist.CreatedBy = PersonalObj.CreatedBy;
                    Assetlist.EmployeeId = Convert.ToInt64(EmpID);
                    objEmployeeDbo.SaveAsset(Assetlist);
                }
            }
            return EmpID;
        }
        public List<Employee> MainGrid(Int32 PageNo, Int32 RowperPage, String SearchText, Int64 RoleId, Int64 EmployeeId)
        {
            EmployeeDbo objEmployeeDbo = new EmployeeDbo();
            return objEmployeeDbo.MainGrid(PageNo, RowperPage, SearchText, RoleId, EmployeeId);
        }
        public List<Employee> MainGridResgn(Int32 PageNo, Int32 RowperPage, String SearchText, Int64 RoleId, Int64 EmployeeId)
        {
            EmployeeDbo objEmployeeDbo = new EmployeeDbo();
            return objEmployeeDbo.MainGridResgn(PageNo, RowperPage, SearchText, RoleId, EmployeeId);
        }
        public Employee GetOfficial(Int64 EmployeeId)
        {
            EmployeeDbo objEmployeeDbo = new EmployeeDbo();
            return objEmployeeDbo.GetOfficial(EmployeeId);
        }
        public List<Employee> GetQualification(Int64 EmployeeId)
        {
            EmployeeDbo objEmployeeDbo = new EmployeeDbo();
            return objEmployeeDbo.GetQualification(EmployeeId);
        }
        public List<Employee> GetExperience(Int64 EmployeeId)
        {
            EmployeeDbo objEmployeeDbo = new EmployeeDbo();
            return objEmployeeDbo.GetExperience(EmployeeId);
        }
        public List<Employee> GetLeave(Int64 EmployeeId)
        {
            EmployeeDbo objEmployeeDbo = new EmployeeDbo();
            return objEmployeeDbo.GetLeave(EmployeeId);
        }
        public List<Employee> GetAsset(Int64 EmployeeId)
        {
            EmployeeDbo objEmployeeDbo = new EmployeeDbo();
            return objEmployeeDbo.GetAsset(EmployeeId);
        }
        public User GetUser(Int64 EmployeeId)
        {
            EmployeeDbo objEmployeeDbo = new EmployeeDbo();
            return objEmployeeDbo.GetUser(EmployeeId);
        }
        public string Update(Employee PersonalObj, Employee OfficialObj, List<Employee> QualificationObj, List<Employee> ExprienceDetailObj, List<Employee> LeaveDetailObj, List<Employee> AssetDetailObj, User objUserObj)
        {
                EmployeeDbo objEmployeeDbo = new EmployeeDbo();
                UserDbo objuserdb = new UserDbo();
                Int64 EmpID = PersonalObj.EmployeeId;
                
                objEmployeeDbo.UpdatePersonal(PersonalObj);
                OfficialObj.EmployeeId = EmpID;
                objEmployeeDbo.UpdateOfficial(OfficialObj);

                string Password = objUserObj.Password;
                objUserObj.Password = DataFactory.GetEncryptedData(Password);
                objUserObj.EmployeeId = EmpID;
                objuserdb.Update(objUserObj);


                if (QualificationObj != null)
                {
                    foreach (Employee Qualilist in QualificationObj)
                    {
                        Qualilist.CreatedBy = PersonalObj.CreatedBy;
                        Qualilist.EmployeeId = Convert.ToInt64(EmpID);
                        if (Qualilist.EmployeeQualificationId == 0)
                        {
                            objEmployeeDbo.SaveQualification(Qualilist);
                        }
                    }
                }
                if (ExprienceDetailObj != null)
                {
                    foreach (Employee Explist in ExprienceDetailObj)
                    {
                        Explist.CreatedBy = PersonalObj.CreatedBy;
                        Explist.EmployeeId = Convert.ToInt64(EmpID);
                        if (Explist.EmployeeExprienceId == 0)
                        {
                            objEmployeeDbo.SaveExprience(Explist);
                        }
                    }
                }
                if (LeaveDetailObj != null)
                {
                    foreach (Employee Leavelist in LeaveDetailObj)
                    {
                        Leavelist.CreatedBy = PersonalObj.CreatedBy;
                        Leavelist.EmployeeId = Convert.ToInt64(EmpID);
                        if (Leavelist.EmployeeLeaveId == 0)
                        {
                            objEmployeeDbo.SaveLeave(Leavelist);
                        }
                    }
                }
                if (AssetDetailObj != null)
                {
                    foreach (Employee Assetlist in AssetDetailObj)
                    {
                        Assetlist.CreatedBy = PersonalObj.CreatedBy;
                        Assetlist.EmployeeId = Convert.ToInt64(EmpID);
                        if (Assetlist.EmployeeAssetId == 0)
                        {
                            objEmployeeDbo.SaveAsset(Assetlist);
                        }
                    }
                }
            
            
            return Convert.ToString(EmpID);

        }
        public string AutoCode()
        {
            EmployeeDbo objEmployeeDbo = new EmployeeDbo();
            return objEmployeeDbo.AutoCode();
    }
        public List<Employee> LeaveUpdated(int EmployeeID, int leavetypeID, int Days,decimal RemainingDays,int EmployeeLeaveId)
        {
            EmployeeDbo objEmployeeDbo = new EmployeeDbo();
            return objEmployeeDbo.LeaveUpdated(EmployeeID, leavetypeID, Days,RemainingDays,EmployeeLeaveId);

        }
        public List<Employee> QualificationUpdated(string qualification, string medium, string university, string percentage, string year, string certificateno, int EmployeeId, int EmployeeQualificationId)
        {
            EmployeeDbo objEmployeeDbo = new EmployeeDbo();
            return objEmployeeDbo.QualificationUpdated( qualification,medium,  university,  percentage, year, certificateno,EmployeeId, EmployeeQualificationId);

        }
        public List<Employee> ExperienceUpdated(string ON, string WB, string WA, string FP, string TP, string RM, string CN, int EmployeeId, int EmployeeExperienceId)
        {
            EmployeeDbo objEmployeeDbo = new EmployeeDbo();
            return objEmployeeDbo.ExperienceUpdated(ON, WB, WA, FP, TP, RM, CN, EmployeeId, EmployeeExperienceId);

        }
        public List<Employee> AssetUpdated(string AN, string AGD, string SN, int EmployeeId, int EmployeeAssetId)
        {
            EmployeeDbo objEmployeeDbo = new EmployeeDbo();
            return objEmployeeDbo.AssetUpdated(AN, AGD, SN,  EmployeeId, EmployeeAssetId);

        }

    }
}
