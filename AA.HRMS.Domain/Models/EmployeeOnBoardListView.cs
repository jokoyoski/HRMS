using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using AA.HRMS.Interfaces;
using PagedList;

namespace AA.HRMS.Domain.Models
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="AA.HRMS.Interfaces.IEmployeeOnBoardListView" />
    public class EmployeeOnBoardListView : IEmployeeOnBoardListView
    {
        public EmployeeOnBoardListView()
        {
            this.CompanyDropDown = new List<SelectListItem>();
            this.GenderDropDown = new List<SelectListItem>();
            this.EmploymentTypeDropDown = new List<SelectListItem>();
            this.StateDropDown = new List<SelectListItem>();
            this.CountryDropDown = new List<SelectListItem>();

        }

        /// <summary> 
        /// Gets or sets the employee list.
        /// </summary>
        /// <value>
        /// The employee list.
        /// </value>
        public IPagedList<IEmployee> EmployeeList { get; set; }

        public IList<IEmployee> employee { get; set; }

        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
        public string ProcessingMessage { get; set; }

        /// <summary>
        /// Gets or sets the selected staff number.
        /// </summary>
        /// <value>
        /// The selected staff number.
        /// </value>
        public string SelectedStaffNumber { get; set; }

        /// <summary>
        /// Gets or sets the last name of the selected.
        /// </summary>
        /// <value>
        /// The last name of the selected.
        /// </value>
        public string SelectedLastName { get; set; }

        /// <summary>
        /// Gets or sets the first name of the selected.
        /// </summary>
        /// <value>
        /// The first name of the selected.
        /// </value>
        public string SelectedFirstName { get; set; }

        /// <summary>
        /// Gets or sets the name of the selected staff.
        /// </summary>
        /// <value>
        /// The name of the selected staff.
        /// </value>
        public string SelectedStaffName { get; set; }

        /// <summary>
        /// Gets or sets the selected date exit from.
        /// </summary>
        /// <value>
        /// The selected date exit from.
        /// </value>
        public DateTime? SelectedDateExitFrom { get; set; }

        /// <summary>
        /// Gets or sets the selected date exit to.
        /// </summary>
        /// <value>
        /// The selected date exit to.
        /// </value>
        public DateTime? SelectedDateExitTo { get; set; }


        public DateTime? SelectedDateEmployedFrom { get; set; }

        
        public DateTime? SelectedDateEmployedTo { get; set; }

        /// <summary>
        /// Gets or sets the selected date of birth from.
        /// </summary>
        /// <value>
        /// The selected date of birth from.
        /// </value>
        public DateTime? SelectedDateOfBirthFrom { get; set; }

        /// <summary>
        /// Gets or sets the selected date of birth to.
        /// </summary>
        /// <value>
        /// The selected date of birth to.
        /// </value>
        public DateTime? SelectedDateOfBirthTo { get; set; }

        /// <summary>
        /// Gets or sets the company drop down.
        /// </summary>
        /// <value>
        /// The company drop down.
        /// </value>
        public IList<SelectListItem> CompanyDropDown { get; set; }
        /// <summary>
        /// Gets or sets the gender drop down.
        /// </summary>
        /// <value>
        /// The gender drop down.
        /// </value>
        public IList<SelectListItem> GenderDropDown { get; set; }
        /// <summary>
        /// Gets or sets the selected gender identifier.
        /// </summary>
        /// <value>
        /// The selected gender identifier.
        /// </value>
        public int SelectedGenderId { get; set; }
        /// <summary>
        /// Gets or sets the country drop down.
        /// </summary>
        /// <value>
        /// The country drop down.
        /// </value>
        public IList<SelectListItem> CountryDropDown { get; set; }
        /// <summary>
        /// Gets or sets the selected country identifier.
        /// </summary>
        /// <value>
        /// The selected country identifier.
        /// </value>
        public int SelectedCountryId { get; set; }
        /// <summary>
        /// Gets or sets the selected location state identifier.
        /// </summary>
        /// <value>
        /// The selected location state identifier.
        /// </value>
        public int SelectedLocationStateId { get; set; }
        /// <summary>
        /// Gets or sets the state drop down.
        /// </summary>
        /// <value>
        /// The state drop down.
        /// </value>
        public IList<SelectListItem> StateDropDown { get; set; }
        /// <summary>
        /// Gets or sets the selected state origin identifier.
        /// </summary>
        /// <value>
        /// The selected state origin identifier.
        /// </value>
        public int SelectedStateOriginId { get; set; }
        /// <summary>
        /// Gets or sets the employment type drop down.
        /// </summary>
        /// <value>
        /// The employment type drop down.
        /// </value>
        public IList<SelectListItem> EmploymentTypeDropDown { get; set; }
        /// <summary>
        /// Gets or sets the selected employment type identifier.
        /// </summary>
        /// <value>
        /// The selected employment type identifier.
        /// </value>
        public int SelectedEmploymentTypeId { get; set; }
        /// <summary>
        /// Gets or sets the selected company identifier.
        /// </summary>
        /// <value>
        /// The selected company identifier.
        /// </value>
        public int SelectedCompanyId { get; set; }
        /// <summary>
        /// Gets or sets the age.
        /// </summary>
        /// <value>
        /// The age.
        /// </value>
        public int Age { get; set; }
        /// <summary>
        /// Gets or sets the sort order.
        /// </summary>
        /// <value>
        /// The sort order.
        /// </value>
        public string sortOrder { get; set; }

        /// <summary>
        /// Gets or sets the search string.
        /// </summary>
        /// <value>
        /// The search string.
        /// </value>
        public string searchString { get; set; }

        public string URL { get; set; }

        public string identifier { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ident { get; set; }
    }
}