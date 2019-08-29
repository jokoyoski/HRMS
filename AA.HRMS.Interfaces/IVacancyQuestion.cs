namespace AA.HRMS.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IVacancyQuestion
    {
        /// <summary>
        /// Gets or sets the vacancy question identifier.
        /// </summary>
        /// <value>
        /// The vacancy question identifier.
        /// </value>
        int VacancyQuestionId { get; set; }

        /// <summary>
        /// Gets or sets the vacancy identifier.
        /// </summary>
        /// <value>
        /// The vacancy identifier.
        /// </value>
        int VacancyId { get; set; }

        /// <summary>
        /// Gets or sets the question.
        /// </summary>
        /// <value>
        /// The question.
        /// </value>
        string Question { get; set; }

        /// <summary>
        /// Gets or sets the answer format identifier.
        /// </summary>
        /// <value>
        /// The answer format identifier.
        /// </value>
        int AnswerFormatId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is answer required.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is answer required; otherwise, <c>false</c>.
        /// </value>
        bool IsAnswerRequired { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        bool IsActive { get; set; }
    }
}