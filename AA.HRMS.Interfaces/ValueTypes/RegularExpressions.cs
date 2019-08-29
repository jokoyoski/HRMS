using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Interfaces.ValueTypes
{
    /// <summary>
    /// Contains regular expressions
    /// </summary>
    public static class RegularExpressions
    {
        /// <summary>
        /// The alphabetic regex
        /// </summary>
        public const string AlphabeticRegex = @"^[[a-zA-Z]+$";

        /// <summary>
        /// The alpha numeric regex
        /// </summary>
        public const string AlphaNumericRegex = @"^[A-Za-z0-9\s]+$";

        /// <summary>
        /// The alpha numeric with special xters regex
        /// </summary>
        public const string AlphaNumericWithSpecialXtersRegex = @"^[A-Za-z0-9\s\.\&,'-]+$";

        /// <summary>
        /// The address alpha numeric with special xters regex
        /// </summary>
        public const string AddressAlphaNumericWithSpecialXtersRegex = @"^[A-Za-z0-9\s\.\&,'/#-]+$";

        /// <summary>
        /// The valid email regex
        /// </summary>
        public const string ValidEmailRegex = @"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*";

        /// <summary>
        /// The po box regex
        /// </summary>
        public const string POBoxRegex = @"(?: P(?:ost(?:al) ?)?[\.\-\s] * (?: (?: O(?:ffice)?[\.\-\s] *) ? B(?:ox |in|\b |\d) | o(?:ffice |\b)(?:[-\s] *\d)|code)|box[-\s\b]*\d)";
    }
}
