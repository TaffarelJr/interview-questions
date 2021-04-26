using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text.RegularExpressions;

namespace InterviewQuestions.CSharp.UniqueEmailAddresses
{
    /// <summary>
    /// The class that contains the challenge solution.
    /// </summary>
    public class Solution
    {
        private static readonly Regex _emailRegEx = new (
            @"^(?<local>[a-z0-9.]+)(?<filter>\+.*)?(?<domain>@[a-z.]+)$",
            RegexOptions.Compiled,
            TimeSpan.FromSeconds(1));

        /// <summary>
        /// Returns the number of unique email addresses,
        /// following the rules outlined in the challenge.
        /// </summary>
        /// <param name="emails">The list of email adddresses to be inspected.</param>
        /// <returns>The number of unique email addresses.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="emails"/> is <c>null</c>.</exception>
        [SuppressMessage(
            "Performance",
            "CA1822:Mark members as static",
            Justification = "Challenge requirement")]
        public int NumberOfUniqueEmailAddresses(string[] emails)
        {
            if (emails is null)
                throw new ArgumentNullException(nameof(emails));

            return emails
                .Where(e => !string.IsNullOrEmpty(e))
                .Select(e => _emailRegEx.Match(e))
                .Where(m => m.Success)
                .Select(m =>
                    m.Groups["local"].Value.Replace(".", string.Empty, StringComparison.Ordinal) +
                    m.Groups["domain"])
                .Distinct(StringComparer.Ordinal)
                .Count();
        }
    }
}
