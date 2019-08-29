using AA.HRMS.Interfaces;
using AA.HRMS.Interfaces.ValueTypes;
using AA.Infrastructure.Interfaces;
using FluentScheduler;
using System;
using System.Linq;
using System.Web.Hosting;

namespace AA.HRMS.Domain.Services
{
    public class SchedulerServices : IJob, IRegisteredObject
    {
        private readonly object _lock = new object();

        private bool _shuttingDown;
        private readonly IPayrollServices payrollServices;
        private string monthCode;
        private int yearId;

        public SchedulerServices(IPayrollServices payrollServices)
        {
            this.payrollServices = payrollServices;
        }

        public void SetValue()
        {
            var date = DateTime.UtcNow;
            int dateLength = date.Month - 1;
            Char[] dateArray = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L' };
            monthCode = dateArray[dateLength].ToString();
            yearId = date.Year;
        }
        
        public void Execute()
        {
            try
            {
                lock (_lock)
                {
                    if (_shuttingDown)
                        return;

                    // Do work, son!
                    this.payrollServices.GeneratePay(monthCode, yearId);

                }
            }
            finally
            {
                // Always unregister the job when done.
                HostingEnvironment.UnregisterObject(this);
            }
        }

        public void Stop(bool immediate)
        {
            // Locking here will wait for the lock in Execute to be released until this code can continue.
            lock (_lock)
            {
                _shuttingDown = true;
            }

            HostingEnvironment.UnregisterObject(this);
        }
        
    }
}
