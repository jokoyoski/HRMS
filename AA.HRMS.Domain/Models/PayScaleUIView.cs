using AA.HRMS.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AA.HRMS.Domain.Models
{
    public class PayScaleUIView : IPayScaleUIView
    {

        public PayScaleUIView()
        {
            this.CompanyDropDown = new List<SelectListItem>();
            this.LevelDropDown = new List<SelectListItem>();
            this.GradeDropDown = new List<SelectListItem>();
            this.TaxDropDown = new List<SelectListItem>();
            this.PayScalebenefits = new List<IPayScaleBenefit>();
            this.BenefitList = new List<IBenefit>();
            this.SelectedBenefits = new List<int>();
        }
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
        /// Gets or sets the base pay.
        /// </summary>
        /// <value>
        /// The base pay.
        /// </value
        public decimal BasePay { get; set; }
        /// <summary>
        /// Gets or sets the tax identifier.
        /// </summary>
        /// <value>
        /// The tax identifier.
        /// </value>
        public int TaxId { get; set; }
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
        /// Gets or sets the company drop down.
        /// </summary>
        /// <value>
        /// The company drop down.
        /// </value>
        public IList<SelectListItem> CompanyDropDown { get; set; }
        /// <summary>
        /// Gets or sets the level drop down.
        /// </summary>
        /// <value>
        /// The level drop down.
        /// </value>
        public IList<SelectListItem> LevelDropDown { get; set; }
        /// <summary>
        /// Gets or sets the grade drop down.
        /// </summary>
        /// <value>
        /// The grade drop down.
        /// </value>
        public IList<SelectListItem> GradeDropDown { get; set; }
        /// <summary>
        /// Gets or sets the tax drop down.
        /// </summary>
        /// <value>
        /// The tax drop down.
        /// </value>
        public IList<SelectListItem> TaxDropDown { get; set; }
        /// <summary>
        /// Gets or sets the benefit list.
        /// </summary>
        /// <value>
        /// The benefit list.
        /// </value>
        public IList<IBenefit> BenefitList { get; set; }
        /// <summary>
        /// Gets or sets the pay scale benefit LST.
        /// </summary>
        /// <value>
        /// The pay scale benefit LST.
        /// </value>
        public IList<IPayScaleBenefit> PayScalebenefits { get; set; }
        /// <summary>
        /// Gets or sets the selected benefits.
        /// </summary>
        /// <value>
        /// The selected benefits.
        /// </value>
        public List<int> SelectedBenefits { get; set; }
        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
        public string ProcessingMessage { get; set; }
    }
}
