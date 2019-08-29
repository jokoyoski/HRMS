using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using AA.HRMS.Interfaces;
using System.ComponentModel.DataAnnotations;
using AA.HRMS.Domain.CustomAttribute;

namespace AA.HRMS.Domain.Models
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="AA.HRMS.Interfaces.IEmployeeOnBoardView" />
    public class EmployeeOnBoardView : IEmployeeOnBoardView
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeOnBoardView"/> class.
        /// </summary>
        public EmployeeOnBoardView()
        {
           
            IsActive = true;
            DateCreated = DateTime.UtcNow;
            this.MaritalStatusDropDownList = new List<SelectListItem>();
            this.ReligionDropDownList = new List<SelectListItem>();
            this.GenderDropDownList = new List<SelectListItem>();
            this.CompanyDropDownList = new List<SelectListItem>();
            this.DepartmentDropDownList = new List<SelectListItem>();
            this.JobTitleDropDownList = new List<SelectListItem>();
            this.GradeDropDownList = new List<SelectListItem>();
            this.LevelDropDownList = new List<SelectListItem>();
            this.CompanyDropDownList = new List<SelectListItem>();
            this.PermanentStateDropDownList = new List<SelectListItem>();
            this.HomeStateDropDownList = new List<SelectListItem>();
            this.StateDropDownList = new List<SelectListItem>();
            this.EmployeeDropDownList = new List<SelectListItem>();
            this.EmploymentTypeDropDownList = new List<SelectListItem>();
            this.PayScaleDropDownList = new List<SelectListItem>();
            this.Birthday = DateTime.UtcNow;
        }

        /// <summary>
        /// Gets or sets the type of the employment.
        /// </summary>
        /// <value>
        /// The type of the employment.
        /// </value>
        public IList<SelectListItem> EmploymentTypeDropDownList { get; set; }

        /// <summary>
        /// Gets or sets the marital status drop down list.
        /// </summary>
        /// <value>
        /// The marital status drop down list.
        /// </value>
        public IList<SelectListItem> MaritalStatusDropDownList { get; set; }
        /// <summary>
        /// Gets or sets the religion drop down list.
        /// </summary>
        /// <value>
        /// The religion drop down list.
        /// </value>
        public IList<SelectListItem> ReligionDropDownList { get; set; }
        /// <summary>
        /// Gets or sets the gender drop down list.
        /// </summary>
        /// <value>
        /// The gender drop down list.
        /// </value>
        public IList<SelectListItem> GenderDropDownList { get; set; }
        /// <summary>
        /// Gets or sets the company drop down list.
        /// </summary>
        /// <value>
        /// The company drop down list.
        /// </value>
        public IList<SelectListItem> CompanyDropDownList { get; set; }
        /// <summary>
        /// Gets or sets the department drop down list.
        /// </summary>
        /// <value>
        /// The department drop down list.
        /// </value>
        public IList<SelectListItem> DepartmentDropDownList { get; set; }
        /// <summary>
        /// Gets or sets the job title drop down list.
        /// </summary>
        /// <value>
        /// The job title drop down list.
        /// </value>
        public IList<SelectListItem> JobTitleDropDownList { get; set; }
        /// <summary>
        /// Gets or sets the grade drop down list.
        /// </summary>
        /// <value>
        /// The grade drop down list.
        /// </value>
        public IList<SelectListItem> GradeDropDownList { get; set; }
        /// <summary>
        /// Gets or sets the level drop down list.
        /// </summary>
        /// <value>
        /// The level drop down list.
        /// </value>
        public IList<SelectListItem> LevelDropDownList { get; set; }
        /// <summary>
        /// Gets or sets the country drop down list.
        /// </summary>
        /// <value>
        /// The country drop down list.
        /// </value>
        public IList<SelectListItem> CountryDropDownList { get; set; }
        /// <summary>
        /// Gets or sets the state drop down list.
        /// </summary>
        /// <value>
        /// The state drop down list.
        /// </value>
        public IList<SelectListItem> StateDropDownList { get; set; }
        /// <summary>
        /// Gets or sets the employee drop down list.
        /// </summary>
        /// <value>
        /// The employee drop down list.
        /// </value>
        public IList<SelectListItem> EmployeeDropDownList { get; set; }

        /// <summary>
        /// Gets or sets the pay scale drop down list.
        /// </summary>
        /// <value>
        /// The pay scale drop down list.
        /// </value>
        public IList<SelectListItem> PayScaleDropDownList { get; set; }

        /// <summary>
        /// Gets or sets the employee identifier.
        /// </summary>
        /// <value>
        /// The employee identifier.
        /// </value>
        public int EmployeeID { get; set; }
        /// <summary>
        /// Gets or sets the staff number.
        /// </summary>
        /// <value>
        /// The staff number.
        /// </value>
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 2)]
        public string StaffNumber { get; set; }
        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>
        /// The last name.
        /// </value>
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 2)]
        public string LastName { get; set; }
        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>
        /// The first name.
        /// </value>
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 2)]
        public string FirstName { get; set; }
        /// <summary>
        /// Gets or sets the name of the middle.
        /// </summary>
        /// <value>
        /// The name of the middle.
        /// </value>
        public string MiddleName { get; set; }
        [Required]
     //   [EmailAddress]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 2)]
        public string Email { get; set; }
        /// <summary>
        /// Gets or sets the company identifier.
        /// </summary>
        /// <value>
        /// The company identifier.
        /// </value>
        [Required]
        [Range(1, Int32.MaxValue, ErrorMessage = "The Company must be selected")]
        public int CompanyID { get; set; }
        /// <summary>
        /// Gets or sets the employment type identifier.
        /// </summary>
        /// <value>
        /// The employment type identifier.
        /// </value>
        [Required]
        [Range(1, Int32.MaxValue, ErrorMessage = "The Employment Type must be selected")]
        public int EmploymentTypeId { get; set; }
        /// <summary>
        /// Gets or sets the level identifier.
        /// </summary>
        /// <value>
        /// The level identifier.
        /// </value>
        public int LevelID { get; set; }
        /// <summary>
        /// Gets or sets the grade identifier.
        /// </summary>
        /// <value>
        /// The grade identifier.
        /// </value>
        public int GradeID { get; set; }
        /// <summary>
        /// Gets or sets the level grade.
        /// </summary>
        /// <value>
        /// The level grade.
        /// </value>
        /// 
        [Required]
        [Range(1, Int32.MaxValue, ErrorMessage = "The Grade Level must be selected")]
        public int LevelGradeId { get; set; }
        /// <summary>
        /// Gets or sets the job title identifier.
        /// </summary>
        /// <value>
        /// The job title identifier.
        /// </value>
        [Required]
        [Range(1, Int32.MaxValue, ErrorMessage = "The JobTitle must be selected")]
        public int JobTitleID { get; set; }
        /// <summary>
        /// Gets or sets the mobile number.
        /// </summary>
        /// <value>
        /// The mobile number.
        /// </value>
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 9)]
        public string MobileNumber { get; set; }
        /// <summary>
        /// Gets or sets the permanent address.
        /// </summary>
        /// <value>
        /// The permanent address.
        /// </value>
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 2)]
        public string PermanentAddress { get; set; }
        /// <summary>
        /// Gets or sets the permanent address city.
        /// </summary>
        /// <value>
        /// The permanent address city.
        /// </value>
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 2)]
        public string PermanentAddressCity { get; set; }
        /// <summary>
        /// Gets or sets the permanent address state identifier.
        /// </summary>
        /// <value>
        /// The permanent address state identifier.
        /// </value>
        [Required]
        [Range(1, Int32.MaxValue, ErrorMessage = "The permanent address state must be selected")]
        public int PermanentAddressStateId { get; set; }
        /// <summary>
        /// Gets or sets the state of the permanent address.
        /// </summary>
        /// <value>
        /// The state of the permanent address.
        /// </value>
        public string PermanentAddressState { get; set; }
        /// <summary>
        /// Gets or sets the home address.
        /// </summary>
        /// <value>
        /// The home address.
        /// </value>
        public string HomeAddress { get; set; }
        /// <summary>
        /// Gets or sets the home address city.
        /// </summary>
        /// <value>
        /// The home address city.
        /// </value>
        public string HomeAddressCity { get; set; }
        /// <summary>
        /// Gets or sets the home address state identifier.
        /// </summary>
        /// <value>
        /// The home address state identifier.
        /// </value>
        public int HomeAddressStateId { get; set; }
        /// <summary>
        /// Gets or sets the state of the home address.
        /// </summary>
        /// <value>
        /// The state of the home address.
        /// </value>
        public string HomeAddressState { get; set; }
        /// <summary>
        /// Gets or sets the other email.
        /// </summary>
        /// <value>
        /// The other email.
        /// </value>
        public string OtherEmail { get; set; }
        /// <summary>
        /// Gets or sets the birthday.
        /// </summary>
        /// <value>
        /// The birthday.
        /// </value>
        [MinimumAge(16, ErrorMessage = "Minium Age is 16")]
        public Nullable<System.DateTime> Birthday { get; set; }
        /// <summary>
        /// Gets or sets the marital status identifier.
        /// </summary>
        /// <value>
        /// The marital status identifier.
        /// </value>
        public int? MaritalStatusId { get; set; }
        /// <summary>
        /// Gets or sets the gender identifier.
        /// </summary>
        /// <value>
        /// The gender identifier.
        /// </value>
        [Required]
        [Range(1, Int32.MaxValue, ErrorMessage = "The gender must be selected")]
        public int? GenderId { get; set; }

        /// <summary>
        /// Gets or sets the gender other.
        /// </summary>
        /// <value>
        /// The gender other.
        /// </value>
        public string GenderOther { get; set; }

        /// <summary>
        /// Gets or sets the religion other.
        /// </summary>
        /// <value>
        /// The religion other.
        /// </value>
        public string ReligionOther { get; set; }
        /// <summary>
        /// Gets or sets the is active.
        /// </summary>
        /// <value>
        /// The is active.
        /// </value>
        public Nullable<bool> IsActive { get; set; }
        /// <summary>
        /// Gets or sets the date employed.
        /// </summary>
        /// <value>
        /// The date employed.
        /// </value>
        public System.DateTime DateEmployed { get; set; }
        /// <summary>
        /// Gets or sets the about.
        /// </summary>
        /// <value>
        /// The about.
        /// </value>
        public string About { get; set; }
        /// <summary>
        /// Gets or sets the date exited.
        /// </summary>
        /// <value>
        /// The date exited.
        /// </value>
        public Nullable<System.DateTime> DateExited { get; set; }
        /// <summary>
        /// Gets or sets the skill set.
        /// </summary>
        /// <value>
        /// The skill set.
        /// </value>
        public string SkillSet { get; set; }
        /// <summary>
        /// Gets or sets the supervisor employee identifier.
        /// </summary>
        /// <value>
        /// The supervisor employee identifier.
        /// </value>
        public Nullable<int> SupervisorEmployeeId { get; set; }
        /// <summary>
        /// Gets or sets the seating location.
        /// </summary>
        /// <value>
        /// The seating location.
        /// </value>
        public string SeatingLocation { get; set; }
        /// <summary>
        /// Gets or sets the department identifier.
        /// </summary>
        /// <value>
        /// The department identifier.
        /// </value>
        [Required]
        [Display(Name = "The Department must be selected")]
        public int? DepartmentId { get; set; }
        /// <summary>
        /// Gets or sets the name of the maiden.
        /// </summary>
        /// <value>
        /// The name of the maiden.
        /// </value>
        public string MaidenName { get; set; }
        /// <summary>
        /// Gets or sets the photo digital file identifier.
        /// </summary>
        /// <value>
        /// The photo digital file identifier.
        /// </value>
        public Nullable<int> PhotoDigitalFileId { get; set; }
        /// <summary>
        /// Gets or sets the religion identifier.
        /// </summary>
        /// <value>
        /// The religion identifier.
        /// </value>
        public int? ReligionId { get; set; }
        /// <summary>
        /// Gets or sets the nationality identifier.
        /// </summary>
        /// <value>
        /// The nationality identifier.
        /// </value>
        public int NationalityId { get; set; }
        /// <summary>
        /// Gets or sets the nationality.
        /// </summary>
        /// <value>
        /// The nationality.
        /// </value>
        public string Nationality { get; set; }
        /// <summary>
        /// Gets or sets the date created.
        /// </summary>
        /// <value>
        /// The date created.
        /// </value>
        public Nullable<System.DateTime> DateCreated { get; set; }
        /// <summary>
        /// Gets or sets the profile picture detail.
        /// </summary>
        /// <value>
        /// The profile picture detail.
        /// </value>
        public IDigitalFile ProfilePictureDetail { get; set; }
        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
        public string ProcessingMessage { get; set; }
        /// <summary>
        /// Gets or sets the employee user.
        /// </summary>
        /// <value>
        /// The employee user.
        /// </value>
        public IUser EmployeeUser { get; set; }
        /// <summary>
        /// Gets or sets the is locked.
        /// </summary>
        /// <value>
        /// The is locked.
        /// </value>
        public bool? IsLocked { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is exit.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is exit; otherwise, <c>false</c>.
        /// </value>
        public bool IsExit { get; set; }
        /// <summary>
        /// Gets or sets the permanent state drop down list.
        /// </summary>
        /// <value>
        /// The permanent state drop down list.
        /// </value>
        public IList<SelectListItem> PermanentStateDropDownList { get; set; }
        /// <summary>
        /// Gets or sets the home state drop down list.
        /// </summary>
        /// <value>
        /// The home state drop down list.
        /// </value>
        public IList<SelectListItem> HomeStateDropDownList { get; set; }

        public Boolean IsApproved { get; set; }
    }
}
