using System;
using System.Web.Mvc;
using AA.HRMS.Domain.Models;
using AA.HRMS.Interfaces;

namespace AA.HRMS.Controllers
{

    public class DepartmentController : Controller
    {
        private readonly IDepartmentService departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            this.departmentService = departmentService;
        }

        // GET: Department
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult DepartmentList(int companyId)
        {
            var viewModel = this.departmentService.GetDepartmentsList(companyId);

            return this.View(viewModel);
        }


        [HttpGet]      
        public ActionResult CreateDepartment(int companyId)
        {
            var viewModel = departmentService.GetDepartmentRegistrationView(companyId);

            return View("CreateDepartment", viewModel);
        }
    

        [HttpPost]
        public ActionResult CreateDepartment(DepartmentView deptInfo)
        {
            //Check that Departmnet Info is Not Null
            if (deptInfo == null) throw new ArgumentNullException(nameof(deptInfo));

            //Validate Model
            if (!ModelState.IsValid)
            {
                return View("CreateDepartment", deptInfo);
            }

            //Process The Department Information
            var returnModel = departmentService.ProcessDepartmentInfo(deptInfo);


            //Check if the Processing Message is Not Empty
            //If it is not empty, Means there is no error
            if (!string.IsNullOrEmpty(returnModel.ProcessingMessage))
            {
                return this.View("CreateDepartment", returnModel);
            }

            return this.RedirectToAction("DepartmentList", new {returnModel.CompanyId});
        }

        [HttpGet]
        public ActionResult EditDepartment(int departmentId)
        {
            var viewModel = departmentService.GetDepartmentEditView(departmentId);

            return this.View(viewModel);
        }

        [HttpPost]
        public ActionResult EditDepartment(DepartmentView deptInfo)
        {
            if (deptInfo == null)
            {
                throw new ArgumentNullException(nameof(deptInfo));
            }

            if (!ModelState.IsValid)
            {
                return View("EditDepartment", deptInfo);
            }

            var returnModel = departmentService.ProcessEditDepartmentInfo(deptInfo);

            if (!string.IsNullOrEmpty(returnModel.ProcessingMessage))
            {
                return this.View("EditDepartment", returnModel);
            }

            return this.RedirectToAction("DepartmentList", new { returnModel.CompanyId });
        }

        //[HttpGet]
        public void DeleteDepartment(int departmentId)
        {
            var viewModel = this.departmentService.ProcessDeleteDepartmentInfo(departmentId);
        } 
    }
}