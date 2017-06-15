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
    public class TrackerDashBoardMgr
    {
        public List<DashBoard> MainGrid(Int64 ProjectId, int Date, Int64 EmployeeId)
        {
            TrackerDashBoardDbo TrackerDashBoardDbod = new TrackerDashBoardDbo();
            return TrackerDashBoardDbod.MainGrid(ProjectId, Date, EmployeeId);
        }

        public DashBoard Count(Int64 ProjectId, int Date, Int64 EmployeeId)
        {
            TrackerDashBoardDbo TrackerDashBoardDbod = new TrackerDashBoardDbo();
            return TrackerDashBoardDbod.Count(ProjectId, Date, EmployeeId);
        }
        public List<ChartObj> Chart(Int64 EmployeeId)
        {
            TrackerDashBoardDbo TrackerDashBoardDbod = new TrackerDashBoardDbo();
            return TrackerDashBoardDbod.Chart(EmployeeId);
        }
    }
}
