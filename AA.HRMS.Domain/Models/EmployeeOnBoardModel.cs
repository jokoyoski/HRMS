using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AA.HRMS.Interfaces;

namespace AA.HRMS.Repositories.Models
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="AA.HRMS.Interfaces.IEmployeeOnBoard" />
    public class EmployeeOnBoardModel : IEmployeeOnBoard
    {
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
        public string StaffNumber { get; set; }
        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>
        /// The last name.
        /// </value>
        public string LastName { get; set; }
        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>
        /// The first name.
        /// </value>
        public string FirstName { get; set; }
        /// <summary>
        /// Gets or sets the name of the middle.
        /// </summary>
        /// <value>
        /// The name of the middle.
        /// </value>
        public string MiddleName { get; set; }
        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>
        /// The email.
        /// </value>
        public string Email { get; set; }
        /// <summary>
        /// Gets or sets the company identifier.
        /// </summary>
        /// <value>
        /// The company identifier.
        /// </value>
        public int? CompanyID { get; set; }
        /// <summary>
        /// Gets or sets the level identifier.
        /// </summary>
        /// <value>
        /// The level identifier.
        /// </value>
        public int? LevelID { get; set; }
        /// <summary>
        /// Gets or sets the grade identifier.
        /// </summary>
        /// <value>
        /// The grade identifier.
        /// </value>
        public int? GradeID { get; set; }
        /// <summary>
        /// Gets or sets the mobile number.
        /// </summary>
        /// <value>
        /// The mobile number.
        /// </value>
        public string MobileNumber { get; set; }
        /// <summary>
        /// Gets or sets the permanent address.
        /// </summary>
        /// <value>
        /// The permanent address.
        /// </value>
        public string PermanentAddress { get; set; }
        /// <summary>
        /// Gets or sets the permanent address city.
        /// </summary>
        /// <value>
        /// The permanent address city.
        /// </value>
        public string PermanentAddressCity { get; set; }
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
        public int? GenderId { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        public bool IsActive { get; set; }
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
        /// Gets or sets the is locked.
        /// </summary>
        /// <value>
        /// The is locked.
        /// </value>
        public bool? IsLocked { get; set; }
    }
}
