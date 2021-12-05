using System;

namespace Skitscript.Types.DotNetStandard
{
    /// <summary>A run of formatted text.</summary>
    public sealed class Run
    {
        /// <summary>When true, the run is to be displayed in bold.  It is to otherwise be displayed using the default font weight.</summary>
        public readonly bool Bold;

        /// <summary>When true, the run is to be displayed in italics.  It is to otherwise be displayed upright.</summary>
        public readonly bool Italic;

        /// <summary>When true, the run is to be displayed in a mono-space font.  It is to otherwise be displayed using the default font.</summary>
        public readonly bool Code;

        /// <summary>The run's exact text as written in the original document.</summary>
        public readonly string Verbatim;

        /// <summary>The run's plain text content as parsed from the document.</summary>
        public readonly string PlainText;

        /// <summary>The column on which the run started in the original document.</summary>
        public readonly int FromColumn;

        /// <summary>The column on which the run ended in the original document.</summary>
        public int ToColumn => FromColumn + Verbatim.Length - 1;

        /// <inheritdoc />
        /// <param name="bold">When true, the run is to be displayed in bold.  It is to otherwise be displayed using the default font weight.</param>
        /// <param name="italic">When true, the run is to be displayed in italics.  It is to otherwise be displayed upright.</param>
        /// <param name="code">When true, the run is to be displayed in a mono-space font.  It is to otherwise be displayed using the default font.</param>
        /// <param name="verbatim">The run's exact text as written in the original document.</param>
        /// <param name="plainText">The run's plain text content as parsed from the document.</param>
        /// <param name="fromColumn">The column on which the run started in the original document.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="verbatim" /> is <see langword="null" />.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="verbatim" /> is <see cref="string.Empty" />.</exception>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="plainText" /> is <see langword="null" />.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="plainText" /> is <see cref="string.Empty" />.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="fromColumn" /> is less than 1.</exception>
        public Run(bool bold, bool italic, bool code, string verbatim, string plainText, int fromColumn)
        {
            if (verbatim == null)
            {
                throw new ArgumentNullException(nameof(verbatim));
            }

            if (verbatim == string.Empty)
            {
                throw new ArgumentOutOfRangeException(nameof(verbatim));
            }

            if (plainText == null)
            {
                throw new ArgumentNullException(nameof(plainText));
            }

            if (plainText == string.Empty)
            {
                throw new ArgumentOutOfRangeException(nameof(plainText));
            }

            if (fromColumn < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(fromColumn));
            }

            Bold = bold;
            Italic = italic;
            Code = code;
            Verbatim = verbatim;
            PlainText = plainText;
            FromColumn = fromColumn;
        }
    }
}
