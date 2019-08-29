using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Interfaces
{
    public interface ISchedulerService
    {
        void Execute();

        void Stop(bool immediate);
    }
}
