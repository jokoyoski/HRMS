using AA.HRMS.Domain.Models;
using AA.HRMS.Interfaces;
using System;
using System.Web.Mvc;
using AA.HRMS.Interfaces.ValueTypes;
using AA.Infrastructure.Interfaces;
using AA.HRMS.Domain.Attributes;

namespace AA.HRMS.Controllers
{
    [Authorize]
    [CheckUserLogin]
    public class SkillSetController : Controller
    {
        private readonly ISkillSetServices skillSetServices;
        
        public SkillSetController(ISkillSetServices skillSetServices)
        {
            this.skillSetServices = skillSetServices;
        }

        /// <summary>
        /// Indexes this instance.
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Detailses the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public ActionResult Details(int id)
        {
            return View();
        }

        /// <summary>
        /// Creates this instance.
        /// </summary>
        /// <returns></returns>
        public ActionResult Create(int? employeeId, string URL)
        {
            var viewModel = this.skillSetServices.GetSkillSetCreateView(employeeId ?? 0, URL);

            return this.PartialView("Create", viewModel);
        }

        /// <summary>
        /// Creates the specified skill set information.
        /// </summary>
        /// <param name="skillSetInfo">The skill set information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">skillSetInfo</exception>
        [HttpPost]
        public ActionResult Create(SkillSetModelView skillSetInfo)
        {

            //Check that Skill Info is Not Null
            if (skillSetInfo == null)
            {
                throw new ArgumentNullException(nameof(skillSetInfo));
            }
            
            //Validate Model
            if (!ModelState.IsValid)
            {
                
                   var viewModel = this.skillSetServices.GetSkillSetCreateView(skillSetInfo,"");
                return this.View("Create", viewModel);
            }
            
            var processigMessage = skillSetServices.ProcessSkillSetCreateView(skillSetInfo);

            if (!string.IsNullOrEmpty(processigMessage))
            {
                var viewModel = this.skillSetServices.GetSkillSetCreateView(skillSetInfo, processigMessage);
                return View("Create", viewModel);
            }

            processigMessage = string.Format("{0} Added as New Skill Set", skillSetInfo.SkillName);

            if (skillSetInfo.URL == "/Profile/Index?message=")
            {
                skillSetInfo.URL += processigMessage;
            }
            else
            {
                skillSetInfo.URL += "&message=" +processigMessage;
            }
            
            return this.Redirect(skillSetInfo.URL);
        }

        /// <summary>
        /// Edits the specified skill set identifier.
        /// </summary>
        /// <param name="skillSetId">The skill set identifier.</param>
        /// <returns></returns>
        public ActionResult Edit(int skillSetId, string URL)
        {
            var viewModel = this.skillSetServices.GetSkillSetEditView(skillSetId, URL);

            return PartialView("Edit", viewModel);
        }

        /// <summary>
        /// Edits the specified skill set information.
        /// </summary>
        /// <param name="skillSetInfo">The skill set information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">skillSetInfo</exception>
        [HttpPost]
        public ActionResult Edit(SkillSetModelView skillSetInfo)
        {
            if (skillSetInfo == null)
            {
                throw new ArgumentNullException(nameof(skillSetInfo));
            }
  
            if (!ModelState.IsValid)
            {
                var model = this.skillSetServices.GetSkillSetCreateView(skillSetInfo, "");
                return View("Edit", model);
            }

            var processingMessage = skillSetServices.ProcessSkillSetEditView(skillSetInfo);

            if (!string.IsNullOrEmpty(processingMessage))
            {
                var model = this.skillSetServices.GetSkillSetCreateView(skillSetInfo, processingMessage);
                return View("Edit", model);
            }


            processingMessage = string.Format("{0} Skill Set Edit", skillSetInfo.SkillName);

            if (skillSetInfo.URL == "/Profile/Index?message=")
            {
                skillSetInfo.URL += processingMessage;
            }
            else
            {
                skillSetInfo.URL += "&message=" + processingMessage;
            }




            return this.Redirect(skillSetInfo.URL);
        }

        /// <summary>
        /// Deletes the specified skill identifier.
        /// </summary>
        /// <param name="skillId">The skill identifier.</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Delete(int skillId, string URL)
        {
            var viewModel = this.skillSetServices.GetSkillSetDeleteView(skillId, URL);

            return PartialView("Delete", viewModel);
        }

        /// <summary>
        /// Deletes the specified skill identifier.
        /// </summary>
        /// <param name="skillId">The skill identifier.</param>
        /// <param name="btnSubmit">The BTN submit.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">skillId</exception>
        [HttpPost]
        public ActionResult Delete(int skillId, string URL, string btnSubmit)
        {
            if (skillId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(skillId));
            }


            var returnModel = skillSetServices.ProcessSkillSetDeleteView(skillId);


            // TODO: Add delete logic here
            returnModel = string.Format("Deleted Skill Set History");

            if (URL == "/Profile/Index?message=")
            {
                URL += returnModel;

            }
            else
            {
                URL += "&message=" + returnModel;
            }
            

            return this.Redirect(URL);
        }
    }
}