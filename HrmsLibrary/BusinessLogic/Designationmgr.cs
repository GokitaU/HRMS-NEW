using HrmsLibrary.DataAccess;
using HrmsObjects.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrmsLibrary.BusinessLogic
{
    [Serializable]
    public class Designationmgr
    {
        public string create(Designation objmgr)
        {
            DesignationDBOps objdesignation = new DesignationDBOps();
            return objdesignation.Create(objmgr);
        }
        public List<Designation> DesigMainGrid(Int32 PageNo, Int32 RowperPage, String SearchText)
        {
            DesignationDBOps objdesignation = new DesignationDBOps();
            return objdesignation.DesigMainGrid(PageNo, RowperPage, SearchText);
        }
        public Boolean Update(Designation objdesn)
        {
            DesignationDBOps objdesignation = new DesignationDBOps();
            return objdesignation.Update(objdesn);
        }
    }
}
