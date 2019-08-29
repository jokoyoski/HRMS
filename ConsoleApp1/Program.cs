using AA.HRMS.Interfaces;
using AA.HRMS.Repositories.Factories;
using AA.HRMS.Repositories.Services;
using AA.Infrastructure.Interfaces;
using AA.Infrastructure.Utility;
using FluentScheduler;
using System;
using System.Collections.Generic;

namespace Scheduler
{
    class Program
    {
        static void Main(string[] args)
        {
            JobManager.Initialize(new JobRegistry());
        }
    }

    public class JobRegistry : Registry
    {

        public JobRegistry()
        {

            IList<ISchedule> result;
            IEnvironment environment = new AA.Infrastructure.Utility.Environment();
            IDbContextFactory dbContextFactory = new DbContextFactory(environment);
            ILookupRepository lookupRepository = new LookupRepository(dbContextFactory);

            result = lookupRepository.GetSchedules();

            //Get all the schedule task for a specific companyId
            var scheduleCollection = result;

            //Check f any schedule exist
            if (scheduleCollection != null && scheduleCollection.Count > 0)
            {
                foreach (var item in scheduleCollection)
                {
                    //check if the schedule is a Payroll
                    if (item.ScheduleName.Contains("Payroll"))
                    {
                        // Schedule a more complex action to run immediately and on an monthly interval
                        if (item.WeekId == 1)
                        {
                            if (item.DayId == 1)
                            {
                                Schedule<PayrollAuto>().ToRunNow().AndEvery(1).Months().OnTheFirst(DayOfWeek.Monday).At(14, 0);
                            }
                            else if (item.DayId == 2)
                            {
                                Schedule<PayrollAuto>().ToRunNow().AndEvery(1).Months().OnTheFirst(DayOfWeek.Tuesday).At(14, 0);
                            }
                            else if (item.DayId == 3)
                            {
                                Schedule<PayrollAuto>().ToRunNow().AndEvery(1).Months().OnTheFirst(DayOfWeek.Wednesday).At(14, 0);
                            }
                            else if (item.DayId == 4)
                            {
                                Schedule<PayrollAuto>().ToRunNow().AndEvery(1).Months().OnTheFirst(DayOfWeek.Thursday).At(14, 0);
                            }
                            else if (item.DayId == 5)
                            {
                                Schedule<PayrollAuto>().ToRunNow().AndEvery(1).Months().OnTheFirst(DayOfWeek.Friday).At(14, 0);
                            }
                        }
                        else if (item.WeekId == 2)
                        {
                            if (item.DayId == 1)
                            {
                                Schedule<PayrollAuto>().ToRunNow().AndEvery(1).Months().OnTheSecond(DayOfWeek.Monday).At(14, 0);
                            }
                            else if (item.DayId == 2)
                            {
                                Schedule<PayrollAuto>().ToRunNow().AndEvery(1).Months().OnTheSecond(DayOfWeek.Tuesday).At(14, 0);
                            }
                            else if (item.DayId == 3)
                            {
                                Schedule<PayrollAuto>().ToRunNow().AndEvery(1).Months().OnTheSecond(DayOfWeek.Wednesday).At(14, 0);
                            }
                            else if (item.DayId == 4)
                            {
                                Schedule<PayrollAuto>().ToRunNow().AndEvery(1).Months().OnTheSecond(DayOfWeek.Thursday).At(14, 0);
                            }
                            else if (item.DayId == 5)
                            {
                                Schedule<PayrollAuto>().ToRunNow().AndEvery(1).Months().OnTheSecond(DayOfWeek.Friday).At(14, 0);
                            }
                        }
                        else if (item.WeekId == 3)
                        {
                            if (item.DayId == 1)
                            {
                                Schedule<PayrollAuto>().ToRunNow().AndEvery(1).Months().OnTheThird(DayOfWeek.Monday).At(14, 0);
                            }
                            else if (item.DayId == 2)
                            {
                                Schedule<PayrollAuto>().ToRunNow().AndEvery(1).Months().OnTheThird(DayOfWeek.Tuesday).At(14, 0);
                            }
                            else if (item.DayId == 3)
                            {
                                Schedule<PayrollAuto>().ToRunNow().AndEvery(1).Months().OnTheThird(DayOfWeek.Wednesday).At(14, 0);
                            }
                            else if (item.DayId == 4)
                            {
                                Schedule<PayrollAuto>().ToRunNow().AndEvery(1).Months().OnTheThird(DayOfWeek.Thursday).At(14, 0);
                            }
                            else if (item.DayId == 5)
                            {
                                Schedule<PayrollAuto>().ToRunNow().AndEvery(1).Months().OnTheThird(DayOfWeek.Friday).At(14, 0);
                            }
                        }
                        else if (item.WeekId == 4)
                        {
                            if (item.DayId == 1)
                            {
                                Schedule<PayrollAuto>().ToRunNow().AndEvery(1).Months().OnTheFourth(DayOfWeek.Monday).At(14, 0);
                            }
                            else if (item.DayId == 2)
                            {
                                Schedule<PayrollAuto>().ToRunNow().AndEvery(1).Months().OnTheFourth(DayOfWeek.Tuesday).At(14, 0);
                            }
                            else if (item.DayId == 3)
                            {
                                Schedule<PayrollAuto>().ToRunNow().AndEvery(1).Months().OnTheFourth(DayOfWeek.Wednesday).At(14, 0);
                            }
                            else if (item.DayId == 4)
                            {
                                Schedule<PayrollAuto>().ToRunNow().AndEvery(1).Months().OnTheFourth(DayOfWeek.Thursday).At(14, 0);
                            }
                            else if (item.DayId == 5)
                            {
                                Schedule<PayrollAuto>().ToRunNow().AndEvery(1).Months().OnTheFourth(DayOfWeek.Friday).At(14, 0);
                            }
                        }

                    }
                }
            }
        }



    }

    public class PayrollAuto : IJob
    {
        private readonly IPayrollServices payrollService;
        private readonly string monthCode;
        private readonly int yearId;

        public PayrollAuto(IPayrollServices payrollService, string monthCode, int yearId)
        {
            this.payrollService = payrollService;
            this.monthCode = monthCode;
            this.yearId = yearId;
        }

        public void Execute()
        {
            this.payrollService.GeneratePay(monthCode, yearId);
        }
    }
}
