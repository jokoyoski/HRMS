using AA.HRMS.Interfaces;
using AA.HRMS.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AA.HRMS.Controllers
{
    public class CalendarController : Controller
    {
        private readonly ICompanySetupServices companySetupService;

        public CalendarController(ICompanySetupServices companySetupService)
        {
            this.companySetupService = companySetupService;
        }

        // GET: Calendar
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Gets the events.
        /// </summary>
        /// <returns></returns>
        public JsonResult GetEvents()
        {
            var events = this.companySetupService.GetCalendarEvent();

            return new JsonResult { Data = events, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        /// <summary>
        /// Saves the event.
        /// </summary>
        /// <param name="calendarEventModel">The calendar event model.</param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult SaveEvent(CalendarEventModel calendarEventModel)
        {
            var status = false;

            var processingMessage = this.companySetupService.ProcessCalendarEvent(calendarEventModel);

            if (string.IsNullOrEmpty(processingMessage)) status = true;

            return new JsonResult { Data = new { status = status } };
        }

        /// <summary>
        /// Deletes the event.
        /// </summary>
        /// <param name="eventID">The event identifier.</param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult DeleteEvent(int eventId)
        {
            var status = false;
            var processingMessage = this.companySetupService.ProcessDeleteCalendarEvent(eventId);

            if (string.IsNullOrEmpty(processingMessage)) status = true;

            return new JsonResult { Data = new { status = status } };
        }



    }
}