﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AA.HRMS.Interfaces
{
    public interface IDisciplineView
    {
        /// <summary>
        /// Gets or sets the discipline identifier.
        /// </summary>
        /// <value>
        /// The discipline identifier.
        /// </value>
        int DisciplineId { get; set; }
        /// <summary>
        /// Gets or sets the employee identifier.
        /// </summary>
        /// <value>
        /// The employee identifier.
        /// </value>
        int EmployeeId { get; set; }
        /// <summary>
        /// Gets or sets the employee drop down.
        /// </summary>
        /// <value>
        /// The employee drop down.
        /// </value>
        IList<SelectListItem> EmployeeDropDown { get; set; }
        /// <summary>
        /// Gets or sets the query date.
        /// </summary>
        /// <value>
        /// The query date.
        /// </value>
        DateTime QueryDate { get; set; }
        /// <summary>
        /// Gets or sets the offence.
        /// </summary>
        /// <value>
        /// The offence.
        /// </value>
        string Offence { get; set; }
        /// <summary>
        /// Gets or sets the query initiator.
        /// </summary>
        /// <value>
        /// The query initiator.
        /// </value>
        string QueryInitiator { get; set; }
        /// <summary>
        /// Gets or sets the investigator.
        /// </summary>
        /// <value>
        /// The investigator.
        /// </value>
        string Investigator { get; set; }
        /// <summary>
        /// Gets or sets the response.
        /// </summary>
        /// <value>
        /// The response.
        /// </value>
        string Response { get; set; }
        /// <summary>
        /// Gets or sets the query status identifier.
        /// </summary>
        /// <value>
        /// The query status identifier.
        /// </value>
        int QueryStatusId { get; set; }
        /// <summary>
        /// Gets or sets the investigator report.
        /// </summary>
        /// <value>
        /// The investigator report.
        /// </value>
        string InvestigatorReport { get; set; }
        /// <summary>
        /// Gets or sets the recommended sanction.
        /// </summary>
        /// <value>
        /// The recommended sanction.
        /// </value>
        string RecommendedSanction { get; set; }
        /// <summary>
        /// Gets or sets the discipline committee recommendation.
        /// </summary>
        /// <value>
        /// The discipline committee recommendation.
        /// </value>
        string DisciplineCommitteeRecommendation { get; set; }
        /// <summary>
        /// Gets or sets the action taken identifier.
        /// </summary>
        /// <value>
        /// The action taken identifier.
        /// </value>
        int? ActionTakenId { get; set; }
        /// <summary>
        /// Gets or sets the evidence digital file identifier.
        /// </summary>
        /// <value>
        /// The evidence digital file identifier.
        /// </value>
        int? EvidenceDigitalFileId { get; set; }
        /// <summary>
        /// Gets or sets the date created.
        /// </summary>
        /// <value>
        /// The date created.
        /// </value>
        DateTime DateCreated { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        bool IsActive { get; set; }
        /// <summary>
        /// Gets or sets the company identifier.
        /// </summary>
        /// <value>
        /// The company identifier.
        /// </value>
        int CompanyId { get; set; }
        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
        string ProcessingMessage { get; set; }
        /// <summary>
        /// Gets or sets the company drop down.
        /// </summary>
        /// <value>
        /// The company drop down.
        /// </value>
        IList<SelectListItem> CompanyDropDown { get; set; }
        /// <summary>
        /// Gets or sets the query drop down.
        /// </summary>
        /// <value>
        /// The query drop down.
        /// </value>
        IList<SelectListItem> QueryDropDown { get; set; }
        /// <summary>
        /// Gets or sets the action taken drop down.
        /// </summary>
        /// <value>
        /// The action taken drop down.
        /// </value>
        IList<SelectListItem> ActionTakenDropDown { get; set; }
    }
}
