using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AA.HRMS.Domain.Attributes;
using AA.HRMS.Domain.Models;
using AA.HRMS.Interfaces;
using AA.HRMS.Interfaces.ValueTypes;
using AA.Infrastructure.Interfaces;

namespace AA.HRMS.Controllers
{

    [AccessAuthorize(Roles = new[] {AppAction.Administration, AppAction.CompanyAdmin, AppAction.Employee})]
    [CheckUserLogin()]
    public class HRController : Controller
    {

        private readonly IAdminService adminService;

        private readonly IUserService userService;

        private readonly ICompanySetupServices companySetupServices;

        private readonly IDisciplineService disciplineService;
        
        public HRController(IAdminService adminService, IUserService userService,
            ICompanySetupServices companySetupServices, IDisciplineService disciplineService)
        {
            this.adminService = adminService;
            this.userService = userService;
            this.companySetupServices = companySetupServices;
            this.disciplineService = disciplineService;
        }


        #region //------------------------------------------Department Section--------------------------------------//

        /// <summary>
        /// Departments the list.
        /// </summary>
        /// <param name="selectedCompanyId">The selected company identifier.</param>
        /// <param name="selectedDepartmentId">The selected department identifier.</param>
        /// <param name="selectedDepartment">The selected department.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public ActionResult DepartmentList(int? selectedCompanyId, int? selectedDepartmentId, string selectedDepartment,
            string message)
        {
            

            var viewModel = this.adminService.GetDepartmentsList(selectedCompanyId ?? -1,
                selectedDepartmentId ?? -1,
                selectedDepartment, message);

            return this.View("DepartmentList", viewModel);
        }

        /// <summary>
        /// Adds the department.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult AddDepartment()
        {
            var viewModel = adminService.GetDepartmentRegistrationView();

            return this.PartialView("AddDepartment", viewModel);
        }

        /// <summary>
        /// Adds the department.
        /// </summary>
        /// <param name="deptInfo">The dept information.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">deptInfo</exception>
        [HttpPost]
        public ActionResult AddDepartment(DepartmentView deptInfo, HttpPostedFileBase departmentExcelFile)
        {
            var processingMessage = String.Empty;
            if (departmentExcelFile != null)
            {

                processingMessage = this.adminService.ProcessUploadExcelDepartment(departmentExcelFile);


                if (!string.IsNullOrEmpty(processingMessage))
                {
                    var viewModel = this.adminService.GetDepartmentRegistrationView(deptInfo, processingMessage);

                    return this.View("AddDepartment", viewModel);
                }

                processingMessage = string.Format("{0} successful added", deptInfo.DepartmentName);

                return this.RedirectToAction("DepartmentList", "HR", new { message = processingMessage });
            }

            if (deptInfo == null)
            {
                throw new ArgumentNullException(nameof(deptInfo));
            }

            //Check that Departmnet Info is Not Null
            if (deptInfo == null)
            {
                throw new ArgumentNullException(nameof(deptInfo));
            }

            //Validate Model
            if (!ModelState.IsValid)
            {
                var model = adminService.GetDepartmentRegistrationView(deptInfo,
                    string.Empty); // update model with dropdown list
                return View("AddDepartment", model);
            }

            //Process The Department Information
            var message = adminService.ProcessDepartmentInfo(deptInfo);

            //Check if the Processing Message is Not Empty
            //If it is not empty, Means there is no error
            if (!string.IsNullOrEmpty(message))
            {
                var model = adminService.GetDepartmentRegistrationView(deptInfo,
                    message); // update model with dropdown list
                return View("AddDepartment", model);
            }

            var returnMessage = string.Format("New Department Registered - {0}", deptInfo.DepartmentName);

            return this.RedirectToAction("DepartmentList", "HR",
                new
                {
                    message = returnMessage
                });
        }

        /// <summary>
        /// Edits the department.
        /// </summary>
        /// <param name="departmentId">The department identifier.</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult EditDepartment(int departmentId)
        {
            var viewModel = adminService.GetDepartmentEditView(departmentId, string.Empty);

            return this.PartialView("EditDepartment", viewModel);
        }

        /// <summary>
        /// Edits the department.
        /// </summary>
        /// <param name="deptInfo">The dept information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">deptInfo</exception>
        [HttpPost]
        public ActionResult EditDepartment(DepartmentView deptInfo)
        {
            if (deptInfo == null)
            {
                throw new ArgumentNullException(nameof(deptInfo));
            }

            if (!ModelState.IsValid)
            {
                var model = adminService.GetDepartmentRegistrationView(deptInfo,
                    string.Empty); // update model with dropdown list
                return View("EditDepartment", model);
            }

            var message = adminService.ProcessEditDepartmentInfo(deptInfo);

            if (!string.IsNullOrEmpty(message))
            {
                var model = adminService.GetDepartmentRegistrationView(deptInfo,
                    message); // update model with dropdown list
                return this.View("EditDepartment", model);
            }

            var returnMessage = string.Format("Department Information Updated - {0}", deptInfo.DepartmentName);

            return this.RedirectToAction("DepartmentList",
                new {companyId = deptInfo.CompanyId, message = returnMessage});
        }

        /// <summary>
        /// Deletes the department.
        /// </summary>
        /// <param name="departmentId">The department identifier.</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult DeleteDepartment(int departmentId)
        {
            var viewModel = adminService.GetDepartmentEditView(departmentId, string.Empty);

            return this.PartialView("DeleteDepartment", viewModel);
        }

        /// <summary>
        /// Deletes the department.
        /// </summary>
        /// <param name="departmentId">The department identifier.</param>
        /// <param name="btnSubmit">The BTN submit.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">departmentId</exception>
        [HttpPost]
        public ActionResult DeleteDepartment(int departmentId, string btnSubmit)
        {
            if (departmentId < 1)
            {
                throw new ArgumentOutOfRangeException("departmentId");
            }

            var message = adminService.ProcessDeleteDepartmentInfo(departmentId);

            var returnMessage = string.Format("Selected Department Deleted");

            return this.RedirectToAction("DepartmentList", new {message = returnMessage});
        }

        // JSON Endpoint to load the departments for a particular company in the drop down for employee creation
        // and employee editing
        public JsonResult FetchDepartments(int companyId)
        {
            var departments = adminService.GetDepartmentCollection(companyId);

            return this.Json(departments, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region //-------------------------------------------Job Title Section------------------------------------//

        //TODO: View A JobTitle
        /// <summary>
        /// Jobs the title list.
        /// </summary>
        /// <param name="jobTitleId">The job title identifier.</param>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="selectedJobTitle">The selected job title.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public ActionResult JobTitleList(int? jobTitleId, int? companyId, string selectedJobTitle, string message)
        {

            var viewModel =
                this.adminService.GetListOfJobTitle(jobTitleId ?? -1, companyId ?? -1, selectedJobTitle, message);

            return this.View("JobTitleList", viewModel);
        }

        /// <summary>
        /// Adds the job title.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult AddJobTitle()
        {
            var viewModel = this.adminService.GetJobTitleView();

            return this.PartialView("AddJobTitle", viewModel);
        }

        /// <summary>
        /// Adds the job title.
        /// </summary>
        /// <param name="jobTitleInfo">The job title information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">jobTitleInfo</exception>
        [HttpPost]
        public ActionResult AddJobTitle(JobTitleView jobTitleInfo, HttpPostedFileBase jobTitleExcelFile)
        {

            var processingMessage = string.Empty;

            if (jobTitleExcelFile != null)
            {
                processingMessage = this.adminService.ProcessUploadExcelJobTitle(jobTitleExcelFile);


                if (!string.IsNullOrEmpty(processingMessage))
                {
                    var viewModel = this.adminService.GetJobTitleUpdateView(jobTitleInfo, processingMessage);

                    return this.View("AddJobTitle", viewModel);
                }

                processingMessage = string.Format("{0} successful added", jobTitleInfo.JobTitleName);

                return this.RedirectToAction("JobTitleList", "HR", new { message = processingMessage });

            }

            if (jobTitleInfo == null)
            {
                throw new ArgumentNullException(nameof(jobTitleInfo));
            }

            if (!ModelState.IsValid)
            {
                var model = this.adminService.GetJobTitleUpdateView(jobTitleInfo, string.Empty);

                return this.View("AddJobTitle", model);
            }

            processingMessage = this.adminService.ProcessJobTitleInfo(jobTitleInfo);

            if (!string.IsNullOrEmpty(processingMessage))
            {
                var model = this.adminService.GetJobTitleUpdateView(jobTitleInfo, string.Empty);

                return this.View("AddJobTitle", model);
            }

            var returnMessage = string.Format("New Job Title Added -{0}", jobTitleInfo.JobTitleName);

            return RedirectToAction("JobTitleList", new {companyId = jobTitleInfo.CompanyId, message = returnMessage});
        }

        /// <summary>
        /// Edits the job title.
        /// </summary>
        /// <param name="jobTitleId">The job title identifier.</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult EditJobTitle(int jobTitleId)
        {
            var viewModel = adminService.GetJobTitleEditView(jobTitleId, string.Empty);

            return this.PartialView("EditJobTitle", viewModel);
        }

        /// <summary>
        /// Edits the job title.
        /// </summary>
        /// <param name="jobTitleInfo">The job title information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">jobTitleInfo</exception>
        [HttpPost]
        public ActionResult EditJobTitle(JobTitleView jobTitleInfo)
        {
            if (jobTitleInfo == null)
            {
                throw new ArgumentNullException(nameof(jobTitleInfo));
            }

            if (!ModelState.IsValid)
            {
                var model = this.adminService.GetJobTitleUpdateView(jobTitleInfo, string.Empty);

                return this.View("EditJobTitle", model);
            }

            var processingMessage = adminService.ProcessEditJobTitleInformation(jobTitleInfo);

            if (!string.IsNullOrEmpty(processingMessage))
            {
                // update model with dropdown list
                var model = adminService.GetJobTitleUpdateView(jobTitleInfo, processingMessage);

                return this.View("EditJobTitle", model);
            }

            var returnMessage = string.Format("Selected Job Title Updated -{0}", jobTitleInfo.JobTitleName);

            return RedirectToAction("JobTitleList", new {companyId = jobTitleInfo.CompanyId, message = returnMessage});
        }

        /// <summary>
        /// Deletes the job title.
        /// </summary>
        /// <param name="jobTitleId">The job title identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">jobTitleId</exception>
        [HttpGet]
        public ActionResult DeleteJobTitle(int jobTitleId)
        {
            if (jobTitleId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(jobTitleId));
            }

            var viewModel = adminService.GetJobTitleEditView(jobTitleId, string.Empty);

            return this.PartialView("DeleteJobTitle", viewModel);
        }

        /// <summary>
        /// Deletes the job title.
        /// </summary>
        /// <param name="jobTitleId">The job title identifier.</param>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="btnSubmit">The BTN submit.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">jobTitleId</exception>
        [HttpPost]
        public ActionResult DeleteJobTitle(int jobTitleId, string btnSubmit)
        {
            if (jobTitleId < 0)
            {
                throw new ArgumentNullException(nameof(jobTitleId));
            }

            var message = adminService.DeleteJobTitle(jobTitleId);

            var returnMessage = string.Format("Selected Job Title Deleted");

            return RedirectToAction("JobTitleList", new { message = returnMessage});
        }

        // JSON Endpoint to load the job titles for a particular company in the drop down for employee creation
        // and employee editing
        public JsonResult FetchJobTitles(int companyId)
        {
            var jobTitles = adminService.GetJobTitleCollection(companyId);

            return Json(jobTitles, JsonRequestBehavior.AllowGet);
        }

        #endregion
        
        #region //---------------------------------------Grade Section-----------------------------------//

        /// <summary>
        /// Grades the list.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="selectedGradeName">Name of the selected grade.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GradeList(int? selectedcompanyId, string selectedGradeName, string message)
        {
            var gradeView =
                companySetupServices.CreateGradeList(selectedcompanyId ?? -1, selectedGradeName, message);

            return this.View("GradeList", gradeView);
        }

        /// <summary>
        /// Adds the grade.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult CreateGrade()
        {
            //return PartialView("AddJobTitle", viewModel);
            var viewModel = companySetupServices.GetGradeView();

            return this.PartialView("CreateGrade", viewModel);
        }

        /// <summary>
        /// Adds the grade.
        /// </summary>
        /// <param name="gradeInfo">The grade information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">gradeInfo</exception>
        [HttpPost]
        public ActionResult CreateGrade(GradeView gradeInfo, HttpPostedFileBase gradeExcelFile)
        {

            var processingMessage = String.Empty;
            if (gradeExcelFile != null)
            {

                processingMessage = this.companySetupServices.ProcessUploadExcelGrade(gradeExcelFile);


                if (!string.IsNullOrEmpty(processingMessage))
                {
                    var model = this.companySetupServices.GetGradeView(gradeInfo, processingMessage);

                    return this.View("CreateGrade", model);
                }

                processingMessage = string.Format("{0} successful added", gradeInfo.GradeName);

                return this.RedirectToAction("GradeList", "HR", new { message = processingMessage });
            }

            if (gradeInfo == null)
            {
                throw new ArgumentNullException(nameof(gradeInfo));
            }

            //Check that Grade Info is Not Null
            if (gradeInfo == null) throw new ArgumentNullException(nameof(gradeInfo));

            //Validate Model
            if (!ModelState.IsValid)
            {
                var model = this.companySetupServices.GetGradeView(gradeInfo, string.Empty);

                return this.View("CreateGrade", model);
            }

            //Process The Grade Information
            processingMessage = companySetupServices.ProcessGradeInfo(gradeInfo);


            //Check if the Processing Message is Not Empty
            //If it is not empty, Means there is no error
            if (!string.IsNullOrEmpty(processingMessage))
            {
                var model = this.companySetupServices.GetGradeView(gradeInfo, processingMessage);

                return this.View("CreateGrade", model);
            }

            var returnMessage = string.Format("{0} grade Created", gradeInfo.GradeName);

            return this.RedirectToAction("GradeList", "HR",
                new {companyId = gradeInfo.CompanyId, message = returnMessage});
        }

        /// <summary>
        /// Edits the grade.
        /// </summary>
        /// <param name="gradeId">The grade identifier.</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult EditGrade(int gradeId)
        {
            if (gradeId == 0)
            {
                throw new ArgumentNullException(nameof(gradeId));
            }

            var gradeView = this.companySetupServices.GetGradeUpdateView(gradeId);

            return this.PartialView("EditGrade", gradeView);
        }

        /// <summary>
        /// Edits the grade.
        /// </summary>
        /// <param name="gradeInfo">The grade information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">gradeInfo</exception>
        [HttpPost]
        public ActionResult EditGrade(GradeView gradeInfo)
        {
            //Check that Grade Info is Not Null
            if (gradeInfo == null)
            {
                throw new ArgumentNullException(nameof(gradeInfo));
            }


            //Validate Model
            if (!ModelState.IsValid)
            {
                var model = this.companySetupServices.GetGradeView(gradeInfo, string.Empty);

                return this.View("EditGrade", model);
            }

            //Process The Grade Information 
            var returnModel = companySetupServices.UpdateGradeInfo(gradeInfo);


            //Check if the Processing Message is Not Empty
            //If it is not empty, Means there is no error
            if (!string.IsNullOrEmpty(returnModel))
            {
                var model = this.companySetupServices.GetGradeView(gradeInfo, returnModel);

                return this.View("EditGrade", returnModel);
            }

            var returnMessage = string.Format("{0} Edited Sucessfully", gradeInfo.GradeName);

            return this.RedirectToAction("GradeList", "HR",
                new {companyId = gradeInfo.CompanyId, message = returnMessage});
        }

        /// <summary>
        /// Deletes the grade.
        /// </summary>
        /// <param name="gradeId">The grade identifier.</param>
        /// <returns></returns>
        public ActionResult DeleteGrade(int gradeId)
        {
            if (gradeId == 0)
            {
                throw new ArgumentNullException(nameof(gradeId));
            }

            var gradeView = this.companySetupServices.GetGradeUpdateView(gradeId);

            return this.PartialView("DeleteGrade", gradeView);
        }

        /// <summary>
        /// Deletes the grade.
        /// </summary>
        /// <param name="gradeId">The grade identifier.</param>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="btnSubmit">The BTN submit.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">gradeId</exception>
        [HttpPost]
        public ActionResult DeleteGrade(int gradeId, string btnSubmit)
        {
            if (gradeId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(gradeId));
            }

            var returnModel = companySetupServices.DeleteGradeInfo(gradeId);

            returnModel = string.Format("Grade Deleted Succesfully");

            return this.RedirectToAction("GradeList", "HR", new { message = returnModel});
        }

        // JSON Endpoint to load the grades for a particular company in the drop down for employee creation
        // and employee editing        
        /// <summary>
        /// Fetches the grades.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>
        public JsonResult FetchGrades(int companyId)
        {
            var grades = companySetupServices.GetGradesCollection(companyId);

            return Json(grades, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region //------------------------------------------Discipline Section-----------------------------------------------------------//       

        /// <summary>
        /// Disciplines the list.
        /// </summary>
        /// <param name="selectedCompanyId">The selected company identifier.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public ActionResult DisciplineList(int? selectedCompanyId, string message)
        {
            var viewModel = this.disciplineService.CreateDisciplineList(selectedCompanyId ?? -1, message);
            
            return this.View("DisciplineList", viewModel);
        }

        /// <summary>
        /// Mies the discipline list.
        /// </summary>
        /// <param name="selectedCompanyId">The selected company identifier.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        [AccessAuthorize(Roles = new[] {AppAction.Employee, AppAction.CompanyAdmin, AppAction.Administration})]
        public ActionResult MyDisciplineList(int? selectedCompanyId, string message)
        {

            var viewModel =
                this.disciplineService.CreateEmployeeDisciplineList(selectedCompanyId ?? -1, message);

            return this.View("EmployeeDisciplineList", viewModel);
        }

        /// <summary>
        /// Employees the discipline list.
        /// </summary>
        /// <param name="employeeId">The employee identifier.</param>
        /// <param name="selectedCompanyId">The selected company identifier.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public ActionResult EmployeeDisciplineList(int employeeId, int? selectedCompanyId, string message)
        {

            var viewModel =
                this.disciplineService.CreateEmployeeDisciplineList(employeeId, selectedCompanyId ?? -1,
                    message);

            return this.View("EmployeeDisciplineList", viewModel);
        }

        /// <summary>
        /// Adds the discipline.
        /// </summary>
        /// <param name="employeeId">The employee identifier.</param>
        /// <returns></returns>]
        [HttpGet]
        public ActionResult AddDiscipline(int employeeId)
        { 
            var viewModel = disciplineService.GetDisciplineView(employeeId);

            return this.PartialView("AddDiscipline", viewModel);
        }

        /// <summary>
        /// Adds the discipline.
        /// </summary>
        /// <param name="disciplineView">The discipline view.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">disciplineView</exception>
        [HttpPost]
        public ActionResult AddDiscipline(DisciplineView disciplineView)
        {

            //Check that Training Info is Not Null
            if (disciplineView == null)
            {
                throw new ArgumentNullException(nameof(disciplineView));
            }

            //Validate Model
            if (!ModelState.IsValid)
            {
                var model = this.disciplineService.GetDisciplineView(disciplineView, string.Empty);
                return View("AddDiscipline", model);
            }

            //Process The Training Information
            var processingMessage = disciplineService.ProcessDisciplineInfo(disciplineView);


            //Check if the Processing Message is Not Empty
            //If it is not empty, Means there is no error
            if (!string.IsNullOrEmpty(processingMessage))
            {
                var model = this.disciplineService.GetDisciplineView(disciplineView, processingMessage);
                return this.View("AddDiscipline", model);
            }

            processingMessage = string.Format("New Discipline is Added");

            return this.RedirectToAction("EmployeeDisciplineList",
                new {employeeId = disciplineView.EmployeeId, message = processingMessage});
        }

        /// <summary>
        /// Edits the discipline.
        /// </summary>
        /// <param name="disciplineId">The discipline identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">disciplineId</exception>
        [HttpGet]
        public ActionResult EditDiscipline(int disciplineId)
        {
            if (disciplineId <= 0)
            {
                throw new ArgumentNullException(nameof(disciplineId));
            }

            var viewModel = disciplineService.GetDisciplineEditView(disciplineId);

            return this.PartialView("EditDiscipline", viewModel);
        }

        /// <summary>
        /// Edits the discipline.
        /// </summary>
        /// <param name="disciplineView">The discipline view.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">disciplineView</exception>
        [HttpPost]
        public ActionResult EditDiscipline(DisciplineView disciplineView)
        {
            if (disciplineView == null)
            {
                throw new ArgumentNullException(nameof(disciplineView));
            }
            

            if (!ModelState.IsValid)
            {
                var model = this.disciplineService.GetDisciplineView(disciplineView, string.Empty);

                return View("EditDiscipline", model);
            }

            var processingMessage = disciplineService.ProcessEditDisciplineInfo(disciplineView);

            if (!string.IsNullOrEmpty(processingMessage))
            {
                var model = this.disciplineService.GetDisciplineView(disciplineView, processingMessage);

                return this.View("EditDiscipline", model);
            }

            processingMessage = string.Format("{0} Updated", disciplineView.Offence);

            return this.RedirectToAction("DisciplineList", new {message = processingMessage});
        }

        /// <summary>
        /// Deletes the discipline.
        /// </summary>
        /// <param name="disciplineId">The discipline identifier.</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult DeleteDiscipline(int disciplineId)
        {

            var viewModel = disciplineService.GetDisciplineEditView(disciplineId);

            return this.PartialView("DeleteDiscipline", viewModel);
        }

        /// <summary>
        /// Deletes the discipline.
        /// </summary>
        /// <param name="disciplineId">The discipline identifier.</param>
        /// <param name="submitBtn">The submit BTN.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">disciplineId</exception>
        [HttpPost]
        public ActionResult DeleteDiscipline(int disciplineId, string submitBtn)
        {
            if (disciplineId <= 0)
            {
                throw new ArgumentOutOfRangeException("disciplineId");
            }

            var message = disciplineService.ProcessDelteDisciplineInfo(disciplineId);

            var returnMessage = string.Format("Selected Training Deleted");

            return this.RedirectToAction("DisciplineList", new {message = returnMessage,});
        }
        
        /// <summary>
        /// Views the discipline.
        /// </summary>
        /// <param name="disciplineId">The discipline identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">disciplineId</exception>
        public ActionResult ViewDiscipline(int disciplineId)
        {

            if (disciplineId <= 0)
            {
                throw new ArgumentNullException(nameof(disciplineId));
            }

            var viewModel = disciplineService.GetDisciplineEditView(disciplineId);

            return this.PartialView("ViewDiscipline", viewModel);
        }

        #endregion
    }
}