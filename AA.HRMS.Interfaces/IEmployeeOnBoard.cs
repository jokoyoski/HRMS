using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IEmployeeOnBoard
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
        Nullable<int> CompanyID { get; set; }
        /// <summary>
        /// Gets or sets the level identifier.
        /// </summary>
        /// <value>
        /// The level identifier.
        /// </value>
        Nullable<int> LevelID { get; set; }
        /// <summary>
        /// Gets or sets the grade identifier.
        /// </summary>
        /// <value>
        /// The grade identifier.
        /// </value>
        Nullable<int> GradeID { get; set; }
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
        Nullable<int> MaritalStatusId { get; set; }
        /// <summary>
        /// Gets or sets the gender identifier.
        /// </summary>
        /// <value>
        /// The gender identifier.
        /// </value>
        Nullable<int> GenderId { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        bool IsActive { get; set; }
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
        Nullable<int> DepartmentId { get; set; }
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
        Nullable<int> ReligionId { get; set; }
        /// <summary>
        /// Gets or sets the nationality.
        /// </summary>
        /// <value>
        /// The nationality.
        /// </value>
        string Nationality { get; set; }
        /// <summary>
        /// Gets or sets the date created.
        /// </summary>
        /// <value>
        /// The date created.
        /// </value>
        Nullable<System.DateTime> DateCreated { get; set; }
        /// <summary>
        /// Gets or sets the is locked.
        /// </summary>
        /// <value>
        /// The is locked.
        /// </value>
        bool? IsLocked { get; set; }
    }
}
