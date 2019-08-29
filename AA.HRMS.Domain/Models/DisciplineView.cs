using AA.HRMS.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AA.HRMS.Domain.Models
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="AA.HRMS.Interfaces.IDisciplineView" />
    public class DisciplineView : IDisciplineView
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="DisciplineView"/> class.
        /// </summary>
        public DisciplineView()
        {
            this.QueryDropDown = new List<SelectListItem>();
            this.ActionTakenDropDown = new List<SelectListItem>();
            this.CompanyDropDown = new List<SelectListItem>();
            this.EmployeeDropDown = new List<SelectListItem>();
        }
        /// <summary>
        /// Gets or sets the discipline identifier.
        /// </summary>
        /// <value>
        /// The discipline identifier.
        /// </value>
        public int DisciplineId { get; set; }
        /// <summary>
        /// Gets or sets the employee identifier.
        /// </summary>
        /// <value>
        /// The employee identifier.
        /// </value>
        public int EmployeeId { get; set; }
        /// <summary>
        /// Gets or sets the employee drop down.
        /// </summary>
        /// <value>
        /// The employee drop down.
        /// </value>
        public IList<SelectListItem> EmployeeDropDown { get; set; }
        /// <summary>
        /// Gets or sets the query date.
        /// </summary>
        /// <value>
        /// The query date.
        /// </value>
        public DateTime QueryDate { get; set; }
        /// <summary>
        /// Gets or sets the offence.
        /// </summary>
        /// <value>
        /// The offence.
        /// </value>
        public string Offence { get; set; }
        /// <summary>
        /// Gets or sets the query initiator.
        /// </summary>
        /// <value>
        /// The query initiator.
        /// </value>
        public string QueryInitiator { get; set; }
        /// <summary>
        /// Gets or sets the investigator.
        /// </summary>
        /// <value>
        /// The investigator.
        /// </value>
        public string Investigator { get; set; }
        /// <summary>
        /// Gets or sets the response.
        /// </summary>
        /// <value>
        /// The response.
        /// </value>
        public string Response { get; set; }
        /// <summary>
        /// Gets or sets the query status identifier.
        /// </summary>
        /// <value>
        /// The query status identifier.
        /// </value>
        public int QueryStatusId { get; set; }
        /// <summary>
        /// Gets or sets the investigator report.
        /// </summary>
        /// <value>
        /// The investigator report.
        /// </value>
        public string InvestigatorReport { get; set; }
        /// <summary>
        /// Gets or sets the recommended sanction.
        /// </summary>
        /// <value>
        /// The recommended sanction.
        /// </value>
        public string RecommendedSanction { get; set; }
        /// <summary>
        /// Gets or sets the discipline committee recommendation.
        /// </summary>
        /// <value>
        /// The discipline committee recommendation.
        /// </value>
        public string DisciplineCommitteeRecommendation { get; set; }
        /// <summary>
        /// Gets or sets the action taken identifier.
        /// </summary>
        /// <value>
        /// The action taken identifier.
        /// </value>
        public int? ActionTakenId { get; set; }
        /// <summary>
        /// Gets or sets the evidence digital file identifier.
        /// </summary>
        /// <value>
        /// The evidence digital file identifier.
        /// </value>
        public int? EvidenceDigitalFileId { get; set; }
        /// <summary>
        /// Gets or sets the date created.
        /// </summary>
        /// <value>
        /// The date created.
        /// </value>
        public DateTime DateCreated { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        public bool IsActive { get; set; }
        /// <summary>
        /// Gets or sets the company identifier.
        /// </summary>
        /// <value>
        /// The company identifier.
        /// </value>
        public int CompanyId { get; set; }
        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
        public string ProcessingMessage { get; set; }
        /// <summary>
        /// Gets or sets the queery drop down.
        /// </summary>
        /// <value>
        /// The queery drop down.
        /// </value>
        public IList<SelectListItem>  QueryDropDown { get; set; }
        /// <summary>
        /// Gets or sets the action taken drop down.
        /// </summary>
        /// <value>
        /// The action taken drop down.
        /// </value>
        public IList<SelectListItem> ActionTakenDropDown { get; set; }
        /// <summary>
        /// Gets or sets the company drop down.
        /// </summary>
        /// <value>
        /// The company drop down.
        /// </value>
        public IList<SelectListItem> CompanyDropDown { get; set; }

        public string URL { get; set; }
    }
}
