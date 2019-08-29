using System;

namespace AA.HRMS.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IDigitalFile
    {
        /// <summary>
        /// Gets or sets the digital file identifier.
        /// </summary>
        /// <value>
        /// The digital file identifier.
        /// </value>
        int DigitalFileId { get; set; }

        /// <summary>
        /// Gets or sets the digital file.
        /// </summary>
        /// <value>
        /// The digital file.
        /// </value>
        byte[] TheDigitalFile { get; set; }

        /// <summary>
        /// Gets or sets the digital type identifier.
        /// </summary>
        /// <value>
        /// The digital type identifier.
        /// </value>
        int DigitalTypeId { get; set; }

        /// <summary>
        /// Gets or sets the name of the file.
        /// </summary>
        /// <value>
        /// The name of the file.
        /// </value>
        string FileName { get; set; }

        /// <summary>
        /// Gets or sets the file extension.
        /// </summary>
        /// <value>
        /// The file extension.
        /// </value>
        string FileExtension { get; set; }

        /// <summary>
        /// Gets or sets the date created.
        /// </summary>
        /// <value>
        /// The date created.
        /// </value>
        DateTime? DateCreated { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        bool? IsActive { get; set; }

        /// <summary>
        /// Gets or sets the type of the content.
        /// </summary>
        /// <value>
        /// The type of the content.
        /// </value>
        string ContentType { get; set; }
    }
}