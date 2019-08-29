﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AA.HRMS.Interfaces
{
    public interface IPayScaleUIView
    {
        /// <summary>
        /// Gets or sets the pay scale identifier.
        /// </summary>
        /// <value>
        /// The pay scale identifier.
        /// </value>
        int PayScaleId { get; set; }
        /// <summary>
        /// Gets or sets the level identifier.
        /// </summary>
        /// <value>
        /// The level identifier.
        /// </value>
        int LevelId { get; set; }
        /// <summary>
        /// Gets or sets the name of the level.
        /// </summary>
        /// <value>
        /// The name of the level.
        /// </value>
        string LevelName { get; set; }
        /// <summary>
        /// Gets or sets the grade identifier.
        /// </summary>
        /// <value>
        /// The grade identifier.
        /// </value>
        int GradeId { get; set; }
        /// <summary>
        /// Gets or sets the name of the grade.
        /// </summary>
        /// <value>
        /// The name of the grade.
        /// </value>
        string GradeName { get; set; }
        /// <summary>
        /// Gets or sets the base pay.
        /// </summary>
        /// <value>
        /// The base pay.
        /// </value>
        decimal BasePay { get; set; }
        /// <summary>
        /// Gets or sets the tax identifier.
        /// </summary>
        /// <value>
        /// The tax identifier.
        /// </value>
        int TaxId { get; set; }
        /// <summary>
        /// Gets or sets the company identifier.
        /// </summary>
        /// <value>
        /// The company identifier.
        /// </value>
        int CompanyId { get; set; }
        /// <summary>
        /// Gets or sets the name of the company.
        /// </summary>
        /// <value>
        /// The name of the company.
        /// </value>
        string CompanyName { get; set; }
        /// <summary>
        /// Gets or sets the date created.
        /// </summary>
        /// <value>
        /// The date created.
        /// </value>
        DateTime DateCreated { get; set; }
        /// <summary>
        /// Gets or sets the date modified.
        /// </summary>
        /// <value>
        /// The date modified.
        /// </value>
        DateTime? DateModified { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        bool IsActive { get; set; }
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
        /// Gets or sets the level drop down.
        /// </summary>
        /// <value>
        /// The level drop down.
        /// </value>
        IList<SelectListItem> LevelDropDown { get; set; }
        /// <summary>
        /// Gets or sets the grade drop down.
        /// </summary>
        /// <value>
        /// The grade drop down.
        /// </value>
        IList<SelectListItem> GradeDropDown { get; set; }
        /// <summary>
        /// Gets or sets the tax drop down.
        /// </summary>
        /// <value>
        /// The tax drop down.
        /// </value>
        IList<SelectListItem> TaxDropDown { get; set; }
        /// <summary>
        /// Gets or sets the benefit list.
        /// </summary>
        /// <value>
        /// The benefit list.
        /// </value>
        IList<IBenefit> BenefitList { get; set; }
        /// <summary>
        /// Gets or sets the pay scalebenefits.
        /// </summary>
        /// <value>
        /// The pay scalebenefits.
        /// </value>
        IList<IPayScaleBenefit> PayScalebenefits { get; set; }
        /// <summary>
        /// Gets or sets the selected benefits.
        /// </summary>
        /// <value>
        /// The selected benefits.
        /// </value>
        List<int> SelectedBenefits { get; set; }
    }
}
