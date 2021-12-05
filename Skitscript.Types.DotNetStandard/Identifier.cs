using System;
using System.Text.RegularExpressions;

namespace Skitscript.Types.DotNetStandard
{
    /// <summary>An identifier, as parsed from a document.</summary>
    public sealed class Identifier
    {
        private static readonly Regex DisallowedWords = new Regex("\\b(?:and|or|when|not|is|are|enters|enter|exits|exit|leads|to|set|clear|jump)\\b", RegexOptions.Compiled);
        private static readonly Regex DisallowedCharacters = new Regex("[,()]", RegexOptions.Compiled);
        private static readonly Regex ExcludedCharacters = new Regex("[:!?'\"{}@*/\\\\&#%`+<=>|$.\\s]+", RegexOptions.Compiled);
        private static readonly Regex IncludedCharacters = new Regex("[^:!?'\"{}@*/\\\\&#%`+<=>|$.\\s]+", RegexOptions.Compiled);

        /// <summary>The identifier's exact text as written in the original document.</summary>
        public readonly string Verbatim;

        /// <summary>The normalized identifier as parsed from the document.</summary>
        public string Normalized => ExcludedCharacters.Replace(Verbatim.ToLowerInvariant(), "-");

        /// <summary>The column on which the identifier started in the original document.</summary>
        public readonly int FromColumn;

        /// <summary>The column on which the identifier ended in the original document.</summary>
        public int ToColumn => FromColumn + Verbatim.Length - 1;

        /// <inheritdoc />
        /// <param name="verbatim">The identifier's exact text as written in the original document.</param>
        /// <param name="fromColumn">The column on which the identifier started in the original document.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="verbatim" /> is <see langword="null" />.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="verbatim" /> is <see cref="string.Empty" /> or white space.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="verbatim" /> includes preceding or trailing white space.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="verbatim" /> contains disallowed words.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="verbatim" /> contains disallowed characters.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="verbatim" /> is <see cref="string.Empty" /> once all excluded characters are filtered out.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="fromColumn" /> is less than 1.</exception>
        public Identifier(string verbatim, int fromColumn)
        {
            if (verbatim == null)
            {
                throw new ArgumentNullException(nameof(verbatim));
            }

            if (verbatim.Trim().Length != verbatim.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(verbatim));
            }

            if (DisallowedWords.IsMatch(verbatim))
            {
                throw new ArgumentOutOfRangeException(nameof(verbatim));
            }

            if (DisallowedCharacters.IsMatch(verbatim))
            {
                throw new ArgumentOutOfRangeException(nameof(verbatim));
            }

            if (!IncludedCharacters.IsMatch(verbatim))
            {
                throw new ArgumentOutOfRangeException(nameof(verbatim));
            }

            if (fromColumn < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(fromColumn));
            }

            Verbatim = verbatim;
            FromColumn = fromColumn;
        }
    }
}
