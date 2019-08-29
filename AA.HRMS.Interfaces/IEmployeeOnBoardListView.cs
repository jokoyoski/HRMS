using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AA.HRMS.Interfaces
{
    public interface IEmployeeOnBoardListView
    {

        /// <summary>
        /// Gets or sets the selected date exit from.
        /// </summary>
        /// <value>
        /// The selected date exit from.
        /// </value>
        DateTime? SelectedDateExitFrom { get; set; }

        /// <summary>
        /// Gets or sets the selected date exit to.
        /// </summary>
        /// <value>
        /// The selected date exit to.
        /// </value>
        DateTime? SelectedDateExitTo { get; set; }

        /// <summary>
        /// Gets or sets the URL.
        /// </summary>
        /// <value>
        /// The URL.
        /// </value>
        string URL { get; set; }

        /// <summary>
        /// Gets or sets the selected date of birth from.
        /// </summary>
        /// <value>
        /// The selected date of birth from.
        /// </value>
        DateTime? SelectedDateOfBirthFrom { get; set; }

        /// <summary>
        /// Gets or sets the selected date of birth to.
        /// </summary>
        /// <value>
        /// The selected date of birth to.
        /// </value>
        DateTime? SelectedDateOfBirthTo { get; set; }

        /// <summary>
        /// Gets or sets the last name of the selected.
        /// </summary>
        /// <value>
        /// The last name of the selected.
        /// </value>
        string SelectedLastName { get; set; }

        /// <summary>
        /// Gets or sets the first name of the selected.
        /// </summary>
        /// <value>
        /// The first name of the selected.
        /// </value>
        string SelectedFirstName { get; set; }

        /// <summary>
        /// Gets or sets the selected gender identifier.
        /// </summary>
        /// <value>
        /// The selected gender identifier.
        /// </value>
        int SelectedGenderId { get; set; }

        /// <summary>
        /// Gets or sets the selected country identifier.
        /// </summary>
        /// <value>
        /// The selected country identifier.
        /// </value>
        int SelectedCountryId { get; set; }

        /// <summary>
        /// Gets or sets the selected location state identifier.
        /// </summary>
        /// <value>
        /// The selected location state identifier.
        /// </value>
        int SelectedLocationStateId { get; set; }

        /// <summary>
        /// Gets or sets the selected state origin identifier.
        /// </summary>
        /// <value>
        /// The selected state origin identifier.
        /// </value>
        int SelectedStateOriginId { get; set; }

        /// <summary>
        /// Gets or sets the selected employment type identifier.
        /// </summary>
        /// <value>
        /// The selected employment type identifier.
        /// </value>
        int SelectedEmploymentTypeId { get; set; }

        /// <summary>
        /// Gets or sets the selected company identifier.
        /// </summary>
        /// <value>
        /// The selected company identifier.
        /// </value>
        int SelectedCompanyId { get; set; }

        /// <summary>
        /// Gets or sets the age.
        /// </summary>
        /// <value>
        /// The age.
        /// </value>
        int Age { get; set; }

        /// <summary>
        /// Gets or sets the employee list.
        /// </summary>
        /// <value>
        /// The employee list.
        /// </value>
        IPagedList<IEmployee> EmployeeList { get; set; }

        /// <summary>
        /// Gets or sets the company drop down.
        /// </summary>
        /// <value>
        /// The company drop down.
        /// </value>
        IList<SelectListItem> CompanyDropDown { get; set; }

        /// <summary>
        /// Gets or sets the gender drop down.
        /// </summary>
        /// <value>
        /// The gender drop down.
        /// </value>
        IList<SelectListItem> GenderDropDown { get; set; }

        /// <summary>
        /// Gets or sets the country drop down.
        /// </summary>
        /// <value>
        /// The country drop down.
        /// </value>
        IList<SelectListItem> CountryDropDown { get; set; }

        /// <summary>
        /// Gets or sets the state drop down.
        /// </summary>
        /// <value>
        /// The state drop down.
        /// </value>
        IList<SelectListItem> StateDropDown { get; set; }

        /// <summary>
        /// Gets or sets the employment type drop down.
        /// </summary>
        /// <value>
        /// The employment type drop down.
        /// </value>
        IList<SelectListItem> EmploymentTypeDropDown { get; set; }

        /// <summary>
        /// 
        /// </summary>
        string ProcessingMessage { get; set; }

        /// <summary>
        /// Gets or sets the selected staff number.
        /// </summary>
        /// <value>
        /// The selected staff number.
        /// </value>
        string SelectedStaffNumber { get; set; }

        /// <summary>
        /// Gets or sets the name of the selected staff.
        /// </summary>
        /// <value>
        /// The name of the selected staff.
        /// </value>
        string SelectedStaffName { get; set; }
        

        /// <summary>
        /// Gets or sets the sort order.
        /// </summary>
        /// <value>
        /// The sort order.
        /// </value>
        string sortOrder { get; set; }

        /// <summary>
        /// Gets or sets the search string.
        /// </summary>
        /// <value>
        /// The search string.
        /// </value>
        string searchString { get; set; }

        /// <summary>
        /// Gets or sets the selected date employed from.
        /// </summary>
        /// <value>
        /// The selected date employed from.
        /// </value>
        DateTime? SelectedDateEmployedFrom { get; set; }

        /// <summary>
        /// Gets or sets the selected date employed to.
        /// </summary>
        /// <value>
        /// The selected date employed to.
        /// </value>
        DateTime? SelectedDateEmployedTo { get; set; }
    }
}