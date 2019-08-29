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
    /// <seealso cref="AA.HRMS.Interfaces.IEmployee" />
    public class EmployeeModel : IEmployee
    {
        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        public string Title { get; set; }
        /// <summary>
        /// Gets or sets the employee identifier.
        /// </summary>
        /// <value>
        /// The employee identifier.
        /// </value>
        public int EmployeeId { get; set; }

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
        /// Gets or sets the staff number.
        /// </summary>
        /// <value>
        /// The staff number.
        /// </value>
        public string StaffNumber { get; set; }


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
        public int CompanyId { get; set; }

        /// <summary>
        /// Gets or sets the name of the company.
        /// </summary>
        /// <value>
        /// The name of the company.
        /// </value>
        public string CompanyName { get; set; }

        /// <summary>
        /// Gets or sets the level identifier.
        /// </summary>
        /// <value>
        /// The level identifier.
        /// </value>
        public int LevelId { get; set; }

        /// <summary>
        /// Gets or sets the name of the level.
        /// </summary>
        /// <value>
        /// The name of the level.
        /// </value>
        public string LevelName { get; set; }

        /// <summary>
        /// Gets or sets the grade identifier.
        /// </summary>
        /// <value>
        /// The grade identifier.
        /// </value>
        public int GradeId { get; set; }

        /// <summary>
        /// Gets or sets the name of the grade.
        /// </summary>
        /// <value>
        /// The name of the grade.
        /// </value>
        public string GradeName { get; set; }

        /// <summary>
        /// Gets or sets the gender oother.
        /// </summary>
        /// <value>
        /// The gender oother.
        /// </value>
        public string GenderOother { get; set; }

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
        /// Gets or sets the state of the home address.
        /// </summary>
        /// <value>
        /// The state of the home address.
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
        public DateTime? Birthday { get; set; }

        /// <summary>
        /// Gets or sets the gender identifier.
        /// </summary>
        /// <value>
        /// The gender identifier.
        /// </value>
        public int? GenderId { get; set; }

        /// <summary>
        /// Gets or sets the marital satus.
        /// </summary>
        /// <value>
        /// The marital satus.
        /// </value>
        public string MaritalStatus { get; set; }

        /// <summary>
        /// Gets or sets the martial status.
        /// </summary>
        /// <value>
        /// The martial status.
        /// </value>
        public int? MartialStatusId { get; set; }

        /// <summary>
        /// Gets or sets the gender.
        /// </summary>
        /// <value>
        /// The gender.
        /// </value>
        public string Gender { get; set; }

        /// <summary>
        /// Gets or sets the date employed.
        /// </summary>
        /// <value>
        /// The date employed.
        /// </value>
        public DateTime DateEmployed { get; set; }

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
        public DateTime? DateExited { get; set; }

        /// <summary>
        /// Gets or sets the skill set.
        /// </summary>
        /// <value>
        /// The skill set.
        /// </value>
        public string SkillSet { get; set; }

        /// <summary>
        /// Gets or sets the photo digital file identifier.
        /// </summary>
        /// <value>
        /// The photo digital file identifier.
        /// </value>
        public int? PhotoDigitalFileId { get; set; }

        /// <summary>
        /// Gets or sets the supervisor employee identifier.
        /// </summary>
        /// <value>
        /// The supervisor employee identifier.
        /// </value>
        public int? SupervisorEmployeeId { get; set; }

        /// <summary>
        /// Gets or sets the supervisor identifier.
        /// </summary>
        /// <value>
        /// The supervisor identifier.
        /// </value>
        public int? SupervisorId { get; set; }

        /// <summary>
        /// Gets or sets the supervisor.
        /// </summary>
        /// <value>
        /// The supervisor.
        /// </value>
        public string Supervisor { get; set; }

        /// <summary>
        /// Gets or sets the employment type identifier.
        /// </summary>
        /// <value>
        /// The employment type identifier.
        /// </value>
        public int EmploymentTypeId { get; set; }

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
        /// Gets or sets the name of the department.
        /// </summary>
        /// <value>
        /// The name of the department.
        /// </value>
        public string Department { get; set; }

        /// <summary>
        /// Gets or sets the name of the maiden.
        /// </summary>
        /// <value>
        /// The name of the maiden.
        /// </value>
        public string MaidenName { get; set; }

        /// <summary>
        /// Gets or sets the photo data.
        /// </summary>
        /// <value>
        /// The photo data.
        /// </value>
        public byte[] PhotoData { get; set; }

        /// <summary>
        /// Gets or sets the photograph.
        /// </summary>
        /// <value>
        /// The photograph.
        /// </value>
        public IDigitalFile Photograph { get; set; }

        /// <summary>
        /// Gets or sets the religion.
        /// </summary>
        /// <value>
        /// The religion.
        /// </value>
        public string Religion { get; set; }

        /// <summary>
        /// Gets or sets the religion identifier.
        /// </summary>
        /// <value>
        /// The religion identifier.
        /// </value>
        public int? ReligionId { get; set; }

        /// <summary>
        /// Gets or sets the religion other.
        /// </summary>
        /// <value>
        /// The religion other.
        /// </value>
        public string ReligionOther { get; set; }

        /// <summary>
        /// Gets or sets the nationality.
        /// </summary>
        /// <value>
        /// The nationality.
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
        public DateTime DateCreated { get; set; }

        /// <summary>
        /// Gets or sets the level grade identifier.
        /// </summary>
        /// <value>
        /// The level grade identifier.
        /// </value>
        public int LevelGradeId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        public Nullable<bool> IsActive { get; set; }

        /// <summary>
        /// Gets or sets the job title identifier.
        /// </summary>
        /// <value>
        /// The job title identifier.
        /// </value>
        public int? JobTitleId { get; set; }

        /// <summary>
        /// Gets or sets the job title.
        /// </summary>
        /// <value>
        /// The job title.
        /// </value>
        public string JobTitle { get; set; }

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
        /// <c>true</c> if this instance is exit; otherwise, <c>false</c>.
        /// </value>
        public bool? IsExit { get; set; }

    }
}