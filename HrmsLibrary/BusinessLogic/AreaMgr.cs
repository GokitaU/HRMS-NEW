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
    public class AreaMgr
    {
        public List<Area> araelist(int PageNo, int RowPerPage, string SearchText)
        {
            AreaDBO objintDb = new AreaDBO();
            return objintDb.Arealist(PageNo, RowPerPage, SearchText);
        }
        public List<Area> autoList(string SEARCHTEXT)
        {
            AreaDBO objintDb = new AreaDBO();
            return objintDb.autoList(SEARCHTEXT);
        }
        public string insert(Area objint)
        {
            AreaDBO objintDb = new AreaDBO();
            return objintDb.insert(objint);
        }
        public Boolean Updated(Area objint)
        {
            AreaDBO objintDb = new AreaDBO();
            return objintDb.Updated(objint);
        }
    }
}
