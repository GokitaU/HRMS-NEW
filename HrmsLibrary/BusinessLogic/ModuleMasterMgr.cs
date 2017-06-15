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
    public class ModuleMasterMgr
    {
        public List<entity> MainGrid(int PageNo, int RowsPerPage, string SearchText)
        {
            ModuleMasterDbo ModuleMasterDbo = new ModuleMasterDbo();
            return ModuleMasterDbo.MainGrid(PageNo, RowsPerPage, SearchText);
        }
        public Int32 CheckModuleTypeName(string ModuleTypeName)
        {
            ModuleMasterDbo ModuleMasterDbo = new ModuleMasterDbo();
            return ModuleMasterDbo.CheckModuleTypeName(ModuleTypeName);
        }
        public string Create(entity objModuleType)
        {
            ModuleMasterDbo ModuleMasterDbo = new ModuleMasterDbo();
            return ModuleMasterDbo.Create(objModuleType);
        }
        public string Update(entity objModuleType)
        {
            ModuleMasterDbo ModuleMasterDbo = new ModuleMasterDbo();
            return ModuleMasterDbo.Update(objModuleType);
        }
    }
}
