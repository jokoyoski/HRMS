using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AA.HRMS.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IEmployeeOnBoardView
    {
        /// <summary>
        /// Gets or sets the employee identifier.
        /// </summary>
        /// <value>
        /// The employee identifier.
        /// </value>
        int EmployeeID { get; set; }
        /// <summary>
        /// Gets or sets the staff number.
        /// </summary>
        /// <value>
        /// The staff number.
        /// </value>
        string StaffNumber { get; set; }
        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>
        /// The last name.
        /// </value>
        string LastName { get; set; }
        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>
        /// The first name.
        /// </value>
        string FirstName { get; set; }
        /// <summary>
        /// Gets or sets the name of the middle.
        /// </summary>
        /// <value>
        /// The name of the middle.
        /// </value>
        string MiddleName { get; set; }
        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>
        /// The email.
        /// </value>
        string Email { get; set; }
        /// <summary>
        /// Gets or sets the company identifier.
        /// </summary>
        /// <value>
        /// The company identifier.
        /// </value>
        int CompanyID { get; set; }
        /// <summary>
        /// Gets or sets the level identifier.
        /// </summary>
        /// <value>
        /// The level identifier.
        /// </value>
        int LevelID { get; set; }
        /// <summary>
        /// Gets or sets the grade identifier.
        /// </summary>
        /// <value>
        /// The grade identifier.
        /// </value>
        int GradeID { get; set; }
        /// <summary>
        /// Gets or sets the level grade.
        /// </summary>
        /// <value>
        /// The level grade.
        /// </value>
        int LevelGradeId { get; set; }
        /// <summary>
        /// Gets or sets the job title identifier.
        /// </summary>
        /// <value>
        /// The job title identifier.
        /// </value>
        int JobTitleID { get; set; }
        /// <summary>
        /// Gets or sets the mobile number.
        /// </summary>
        /// <value>
        /// The mobile number.
        /// </value>
        string MobileNumber { get; set; }
        /// <summary>
        /// Gets or sets the permanent address.
        /// </summary>
        /// <value>
        /// The permanent address.
        /// </value>
        string PermanentAddress { get; set; }
        /// <summary>
        /// Gets or sets the permanent address city.
        /// </summary>
        /// <value>
        /// The permanent address city.
        /// </value>
        string PermanentAddressCity { get; set; }
        /// <summary>
        /// Gets or sets the permanent address state identifier.
        /// </summary>
        /// <value>
        /// The permanent address state identifier.
        /// </value>
        int PermanentAddressStateId { get; set; }
        /// <summary>
        /// Gets or sets the state of the permanent address.
        /// </summary>
        /// <value>
        /// The state of the permanent address.
        /// </value>
        string PermanentAddressState { get; set; }
        /// <summary>
        /// Gets or sets the home address.
        /// </summary>
        /// <value>
        /// The home address.
        /// </value>
        string HomeAddress { get; set; }
        /// <summary>
        /// Gets or sets the home address city.
        /// </summary>
        /// <value>
        /// The home address city.
        /// </value>
        string HomeAddressCity { get; set; }
        /// <summary>
        /// Gets or sets the home address state identifier.
        /// </summary>
        /// <value>
        /// The home address state identifier.
        /// </value>
        int HomeAddressStateId { get; set; }
        /// <summary>
        /// Gets or sets the state of the home address.
        /// </summary>
        /// <value>
        /// The state of the home address.
        /// </value>
        string HomeAddressState { get; set; }
        /// <summary>
        /// Gets or sets the other email.
        /// </summary>
        /// <value>
        /// The other email.
        /// </value>
        string OtherEmail { get; set; }
        /// <summary>
        /// Gets or sets the birthday.
        /// </summary>
        /// <value>
        /// The birthday.
        /// </value>
        Nullable<System.DateTime> Birthday { get; set; }
        /// <summary>
        /// Gets or sets the marital status identifier.
        /// </summary>
        /// <value>
        /// The marital status identifier.
        /// </value>
        int? MaritalStatusId { get; set; }
        /// <summary>
        /// Gets or sets the gender identifier.
        /// </summary>
        /// <value>
        /// The gender identifier.
        /// </value>
        int? GenderId { get; set; }

        /// <summary>
        /// Gets or sets the gender other.
        /// </summary>
        /// <value>
        /// The gender other.
        /// </value>
        string GenderOther { get; set; }

        /// <summary>
        /// Gets or sets the religion other.
        /// </summary>
        /// <value>
        /// The religion other.
        /// </value>
        string ReligionOther { get; set; }
        /// <summary>
        /// Gets or sets the is active.
        /// </summary>
        /// <value>
        /// The is active.
        /// </value>
        Nullable<bool> IsActive { get; set; }
        /// <summary>
        /// Gets or sets the date employed.
        /// </summary>
        /// <value>
        /// The date employed.
        /// </value>
        System.DateTime DateEmployed { get; set; }
        /// <summary>
        /// Gets or sets the about.
        /// </summary>
        /// <value>
        /// The about.
        /// </value>
        string About { get; set; }
        /// <summary>
        /// Gets or sets the date exited.
        /// </summary>
        /// <value>
        /// The date exited.
        /// </value>
        Nullable<System.DateTime> DateExited { get; set; }
        /// <summary>
        /// Gets or sets the skill set.
        /// </summary>
        /// <value>
        /// The skill set.
        /// </value>
        string SkillSet { get; set; }
        /// <summary>
        /// Gets or sets the supervisor employee identifier.
        /// </summary>
        /// <value>
        /// The supervisor employee identifier.
        /// </value>
        Nullable<int> SupervisorEmployeeId { get; set; }
        /// <summary>
        /// Gets or sets the seating location.
        /// </summary>
        /// <value>
        /// The seating location.
        /// </value>
        string SeatingLocation { get; set; }
        /// <summary>
        /// Gets or sets the department identifier.
        /// </summary>
        /// <value>
        /// The department identifier.
        /// </value>
        int? DepartmentId { get; set; }
        /// <summary>
        /// Gets or sets the name of the maiden.
        /// </summary>
        /// <value>
        /// The name of the maiden.
        /// </value>
        string MaidenName { get; set; }
        /// <summary>
        /// Gets or sets the photo digital file identifier.
        /// </summary>
        /// <value>
        /// The photo digital file identifier.
        /// </value>
        Nullable<int> PhotoDigitalFileId { get; set; }
        /// <summary>
        /// Gets or sets the religion identifier.
        /// </summary>
        /// <value>
        /// The religion identifier.
        /// </value>
        int? ReligionId { get; set; }
        /// <summary>
        /// Gets or sets the nationality identifier.
        /// </summary>
        /// <value>
        /// The nationality identifier.
        /// </value>
        int NationalityId { get; set; }
        /// <summary>
        /// Gets or sets the nationality.
        /// </summary>
        /// <value>
        /// The nationality.
        /// </value>
        string Nationality { get; set; }
        /// <summary>
        /// Gets or sets the is locked.
        /// </summary>
        /// <value>
        /// The is locked.
        /// </value>
        bool? IsLocked { get; set; }
        /// <summary>
        /// Gets or sets the date created.
        /// </summary>
        /// <value>
        /// The date created.
        /// </value>
        Nullable<System.DateTime> DateCreated { get; set; }
        /// <summary>
        /// Gets or sets the company drop down list.
        /// </summary>
        /// <value>
        /// The company drop down list.
        /// </value>
        IList<SelectListItem> CompanyDropDownList { get; set; }
        /// <summary>
        /// Gets or sets the department drop down list.
        /// </summary>
        /// <value>
        /// The department drop down list.
        /// </value>
        IList<SelectListItem> DepartmentDropDownList { get; set; }
        /// <summary>
        /// Gets or sets the job title drop down list.
        /// </summary>
        /// <value>
        /// The job title drop down list.
        /// </value>
        IList<SelectListItem> JobTitleDropDownList { get; set; }
        /// <summary>
        /// Gets or sets the grade drop down list.
        /// </summary>
        /// <value>
        /// The grade drop down list.
        /// </value>
        IList<SelectListItem> GradeDropDownList { get; set; }
        /// <summary>
        /// Gets or sets the level drop down list.
        /// </summary>
        /// <value>
        /// The level drop down list.
        /// </value>
        IList<SelectListItem> LevelDropDownList { get; set; }
        /// <summary>
        /// Gets or sets the marital status drop down list.
        /// </summary>
        /// <value>
        /// The marital status drop down list.
        /// </value>
        IList<SelectListItem> MaritalStatusDropDownList { get; set; }
        /// <summary>
        /// Gets or sets the employment type drop down list.
        /// </summary>
        /// <value>
        /// The employment type drop down list.
        /// </value>
        IList<SelectListItem> EmploymentTypeDropDownList { get; set; }
        /// <summary>
        /// Gets or sets the religion drop down list.
        /// </summary>
        /// <value>
        /// The religion drop down list.
        /// </value>
        IList<SelectListItem> ReligionDropDownList { get; set; }
        /// <summary>
        /// Gets or sets the gender drop down list.
        /// </summary>
        /// <value>
        /// The gender drop down list.
        /// </value>
        IList<SelectListItem> GenderDropDownList { get; set; }
        /// <summary>
        /// Gets or sets the employee drop down list.
        /// </summary>
        /// <value>
        /// The employee drop down list.
        /// </value>
        IList<SelectListItem> EmployeeDropDownList { get; set; }
        /// <summary>
        /// Gets or sets the country drop down list.
        /// </summary>
        /// <value>
        /// The country drop down list.
        /// </value>
        IList<SelectListItem> CountryDropDownList { get; set; }
        /// <summary>
        /// Gets or sets the state drop down list.
        /// </summary>
        /// <value>
        /// The state drop down list.
        /// </value>
        IList<SelectListItem> StateDropDownList { get; set; }
        /// <summary>
        /// Gets or sets the permanent state drop down list.
        /// </summary>
        /// <value>
        /// The permanent state drop down list.
        /// </value>
        IList<SelectListItem> PermanentStateDropDownList { get; set; }
        /// <summary>
        /// Gets or sets the home state drop down list.
        /// </summary>
        /// <value>
        /// The home state drop down list.
        /// </value>
        IList<SelectListItem> HomeStateDropDownList { get; set; }

        /// <summary>
        /// Gets or sets the profile picture detail.
        /// </summary>
        /// <value>
        /// The profile picture detail.
        /// </value>
        IDigitalFile ProfilePictureDetail { get; set; }
        /// <summary>
        /// Gets or sets the employee user.
        /// </summary>
        /// <value>
        /// The employee user.
        /// </value>
        IUser EmployeeUser { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is exit.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is exit; otherwise, <c>false</c>.
        /// </value>
        bool IsExit { get; set; }
        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
        string ProcessingMessage { get; set; }
        /// <summary>
        /// Gets or sets the employment type identifier.
        /// </summary>
        /// <value>
        /// The employment type identifier.
        /// </value>
        int EmploymentTypeId { get; set; }

        /// <summary>
        /// Gets or sets the pay scale drop down list.
        /// </summary>
        /// <value>
        /// The pay scale drop down list.
        /// </value>
        IList<SelectListItem> PayScaleDropDownList { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is approved.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is approved; otherwise, <c>false</c>.
        /// </value>
        Boolean IsApproved { get; set; }
    }
}
