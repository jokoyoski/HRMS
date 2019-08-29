using AA.HRMS.Interfaces;
using AA.HRMS.Repositories.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AA.HRMS.Domain.Models
{
    public class PayScaleView : IPayScaleView
    {
        /// <summary>
        /// Gets or sets the pay scale identifier.
        /// </summary>
        /// <value>
        /// The pay scale identifier.
        /// </value>
        public int PayScaleId { get; set; }
        /// <summary>
        /// Gets or sets the level identifier.
        /// </summary>
        /// <value>
        /// The level identifier.
        /// </value>
        [Required()]
        [Range(0, Int64.MaxValue, ErrorMessage = "Level is Required")]
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
        [Required()]
        [Range(0, Int64.MaxValue, ErrorMessage = "Grade is Required")]
        public int GradeId { get; set; }
        /// <summary>
        /// Gets or sets the name of the grade.
        /// </summary>
        /// <value>
        /// The name of the grade.
        /// </value>
        public string GradeName { get; set; }
        /// <summary>
        /// Gets or sets the base pay.
        /// </summary>
        /// <value>
        /// The base pay.
        /// </value>>
        [Required()]
        [Range(0, Int64.MaxValue, ErrorMessage = "Base Pay is Required")]
        public decimal BasePay { get; set; }
        /// <summary>
        /// Gets or sets the tax identifier.
        /// </summary>
        /// <value>
        /// The tax identifier.
        /// </value>
        [Required()]
        [Range(0, Int64.MaxValue, ErrorMessage = "Tax is Required")]
        public int TaxId { get; set; }
        /// <summary>
        /// Gets or sets the company identifier.
        /// </summary>
        /// <value>
        /// The company identifier.
        /// </value>
        [Required()]
        [Range(0, Int64.MaxValue, ErrorMessage = "Company is Required")]
        public int CompanyId { get; set; }
        /// <summary>
        /// Gets or sets the name of the company.
        /// </summary>
        /// <value>
        /// The name of the company.
        /// </value>
        public string CompanyName { get; set; }
        /// <summary>
        /// Gets or sets the date created.
        /// </summary>
        /// <value>
        /// The date created.
        /// </value>
        public DateTime DateCreated { get; set; }
        /// <summary>
        /// Gets or sets the date modified.
        /// </summary>
        /// <value>
        /// The date modified.
        /// </value>
        public DateTime? DateModified { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        public bool IsActive { get; set; }
        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
        public string ProcessingMessage { get; set; }
    }
}
