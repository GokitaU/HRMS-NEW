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
    public class Departmentmgr
    {
        public List<Department> Gridview(Int32 PageNo, Int32 RowperPage, String SearchText)
        {
            DepartmentDBOps objmgr = new DepartmentDBOps();
            return objmgr.Gridview(PageNo, RowperPage, SearchText);
        }
        public string Create(Department objmgr)
        {
            DepartmentDBOps objdepartment = new DepartmentDBOps();
            return objdepartment.Create(objmgr);
        }
        public string Update(Department objmgr)
        {
            DepartmentDBOps objdepartment = new DepartmentDBOps();
            return objdepartment.Update(objmgr);
        }
    }
}
