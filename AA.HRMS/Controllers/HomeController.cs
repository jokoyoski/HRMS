using AA.HRMS.Domain.Attributes;
using AA.HRMS.Interfaces;
using AA.HRMS.Interfaces.ValueTypes;
using System.Collections.Generic;
using System.Web.Mvc;

namespace AA.HRMS.Controllers
{
    public class HomeController : Controller
    {

        private readonly IUserService userService;
        private readonly IEmployeeOnBoardService employeeService;
        private readonly IAdminService adminService;
        
        public HomeController(IUserService userService,
            IEmployeeOnBoardService employeeService, IAdminService adminService)
        {
            this.employeeService = employeeService;
            this.userService = userService;
            this.adminService = adminService;
        }

        /// <summary>
        /// Indexes this instance.
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View("Index");
        }

        /// <summary>
        /// Admins the dash board.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        [AccessAuthorize(Roles = new[] { AppAction.CompanyAdmin, AppAction.Administration })]
        [CheckUserLogin]
        public ActionResult AdminDashBoard(string message)
        {
            //Get The View
            var viewModel = this.employeeService.GetAdminDashBoardView(message);

            if (viewModel.User.CompanyId == 0)
            {
                return this.RedirectToAction("RegisterCompany", "Administration");
            }

            return this.View("AdminDashBoard", viewModel);
        }

        /// <summary>
        /// Employees the dash board.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        [AccessAuthorize(Roles = new[] { AppAction.Employee })]
        [CheckUserLogin]
        public ActionResult EmployeeDashBoard(string message)
        {
            //Get The View
            var viewModel = this.employeeService.GetEmployeeDashBoardView(message);
            
            return this.View("EmployeeDashBoard", viewModel);
        }

        /// <summary>
        /// Abouts this instance.
        /// </summary>
        /// <returns></returns>
        public ActionResult About()
        {
            ViewBag.Message = "Your application description pages.";

            return View();
        }

        /// <summary>
        /// Contacts this instance.
        /// </summary>
        /// <returns></returns>
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        /// <summary>
        /// Companies the gender split.
        /// </summary>
        /// <returns></returns>
        [CheckUserLogin()]
        public JsonResult CompanyGenderSplit()
        {
            IDictionary<string, int> genderSplit = new Dictionary<string, int>();
            genderSplit["Male"] = 10;
            genderSplit["Female"] = 20;

            return Json(new {Data = genderSplit}, JsonRequestBehavior.AllowGet);
        }
    }
}