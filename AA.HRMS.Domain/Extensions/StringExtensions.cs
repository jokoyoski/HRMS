using AA.HRMS.Interfaces.ValueTypes;
using System;
using System.Text.RegularExpressions;

namespace AA.HRMS.Domain.Extensions
{
    public static class StringExtensions
    {
        private static readonly Regex validEmail = new Regex(RegularExpressions.ValidEmailRegex, RegexOptions.IgnoreCase | RegexOptions.CultureInvariant | RegexOptions.Compiled);

        private static readonly Regex validPOBoxAddresses = new Regex(RegularExpressions.POBoxRegex, RegexOptions.IgnoreCase | RegexOptions.CultureInvariant | RegexOptions.Compiled);

        /// <summary>
        /// Determines whether [is valid email value].
        /// </summary>
        /// <param name="emailValue">The email value.</param>
        /// <returns>
        ///   <c>true</c> if [is valid email value] [the specified email value]; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsValidEmailValue(this string emailValue)
        {
            if (string.IsNullOrEmpty(emailValue))
            {
                return false;
            }

            return validEmail.IsMatch(emailValue.Trim());
        }

        /// <summary>
        /// Determines whether [is po box in address].
        /// </summary>
        /// <param name="theValue">The value.</param>
        /// <returns>
        ///   <c>true</c> if [is po box in address] [the specified the value]; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsPOBoxInAddress(this string theValue)
        {
            var errorMessage = string.Empty;
            if (string.IsNullOrEmpty(theValue))
            {
                return false;
            }

            return validPOBoxAddresses.IsMatch(theValue);
        }

        /// <summary>
        /// Files the extension.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">fileName</exception>
        public static string FileExtension(this string fileName)
        {
            if (fileName == null)
            {
                throw new ArgumentException("fileName");
            }

            var result = fileName.Substring(fileName.LastIndexOf('.'));

            return result;
        }
    }
}
