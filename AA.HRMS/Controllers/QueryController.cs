using AA.HRMS.Domain.Attributes;
using AA.HRMS.Domain.Models;
using AA.HRMS.Interfaces;
using System;
using System.Web.Mvc;

namespace AA.HRMS.Controllers
{
    [Authorize]
    [CheckUserLogin]
    public class QueryController : Controller
    {
        private readonly IQueryService queryService;
        
        public QueryController(IQueryService queryService)
        {
            this.queryService = queryService;
        }

        /// <summary>
        /// Queries the list.
        /// </summary>
        /// <param name="selectedCompany">The selected company.</param>
        /// <param name="selectedQuery">The selected query.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public ActionResult QueryList(int? selectedCompany, string selectedQuery,
            string message)
        {

            var viewModel = this.queryService.CreateQueryList(selectedCompany ?? -1, selectedQuery, message);

            return this.View("QueryList", viewModel);
        }


        /// <summary>
        /// Requests the query.
        /// </summary>
        /// <returns></returns>
        public ActionResult RequestQuery()
        {
            return View();
        }

        /// <summary>
        /// Creates the query.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult CreateQuery()
        {
            var viewModel = queryService.GetQueryRegistrationView();

            return PartialView("CreateQuery", viewModel);
        }

        /// <summary>
        /// Creates the query.
        /// </summary>
        /// <param name="queryInfo">The query information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">queryInfo</exception>
        [HttpPost]
        public ActionResult CreateQuery(QueryView queryInfo)
        {
            
            if (queryInfo == null)
            {
                throw new ArgumentNullException(nameof(queryInfo));
            }

            //Validate Model
            if (!ModelState.IsValid)
            {
                var model = this.queryService.CreateQueryUpdatedView(queryInfo, "");
                return View("CreateQuery", model);
            }

            //Process The Query Information
            var processingMessage = queryService.ProcessQueryInfo(queryInfo);


            //Check if the Processing Message is Not Empty
            //If it is not empty, Means there is no error
            if (!string.IsNullOrEmpty(processingMessage))
            {
                var model = this.queryService.CreateQueryUpdatedView(queryInfo, processingMessage);
                return this.View("CreateQuery", model);
            }

            processingMessage = string.Format("{0} is Created", queryInfo.QueryName);

            return this.RedirectToAction("QueryList", new { message = processingMessage });
        }
        
        /// <summary>
        /// Edits the query.
        /// </summary>
        /// <param name="queryId">The query identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">queryId</exception>
        [HttpGet]
        public ActionResult EditQuery(int queryId)
        {

            if (queryId <= 0)
            {
                throw new ArgumentNullException(nameof(queryId));
            }

            var viewModel = queryService.GetQueryEditView(queryId);

            return PartialView(viewModel);
        }
       
        /// <summary>
        /// Edits the query.
        /// </summary>
        /// <param name="queryInfo">The query information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">queryInfo</exception>
        [HttpPost]
        public ActionResult EditQuery(QueryView queryInfo)
        {
            if (queryInfo == null)
            {
                throw new ArgumentNullException(nameof(queryInfo));
            }

            if (!ModelState.IsValid)
            {
                var model = this.queryService.CreateQueryUpdatedView(queryInfo, "");

                return View("EditTraining", model);
            }

            var processingMessage = queryService.ProcessEditQueryInfo(queryInfo);

            if (!string.IsNullOrEmpty(processingMessage))
            {
                var model = this.queryService.CreateQueryUpdatedView(queryInfo, processingMessage);

                return this.View("EditQuery", model);
            }

            processingMessage = string.Format("{0} Updated", queryInfo.QueryName);

            return this.RedirectToAction("TrainingList", new { message = processingMessage });
        }

        /// <summary>
        /// Deletes the query.
        /// </summary>
        /// <param name="queryId">The query identifier.</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult DeleteQuery(int queryId)
        {
            var viewModel = queryService.GetQueryEditView(queryId);

            return PartialView(viewModel);
        }

        /// <summary>
        /// Deletes the query.
        /// </summary>
        /// <param name="queryId">The query identifier.</param>
        /// <param name="btnSubmit">The BTN submit.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">queryId</exception>
        [HttpPost]
        public ActionResult DeleteQuery(int queryId, string btnSubmit)
        {
            if (queryId < 1)
            {
                throw new ArgumentOutOfRangeException("queryId");
            }

            var message = queryService.ProcessDeleteQueryInfo(queryId);

            var returnMessage = string.Format("Selected Query Deleted");

            return this.RedirectToAction("QueryList", new { message = returnMessage, });
        }
        
        /// <summary>
        /// Views the query.
        /// </summary>
        /// <param name="queryId">The query identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">queryId</exception>
        [HttpGet]
        public ActionResult ViewQuery(int queryId)
        {
            //Show the detials of a selected Training
            if (queryId < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(queryId));
            }

            //Get The View
            var viewModel = this.queryService.GetQueryEditView(queryId);

            return PartialView("ViewQuery", viewModel);
        }
    }
}