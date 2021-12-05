using System;
using System.Collections.Generic;
using Xunit;

namespace Skitscript.Types.DotNetStandard.Unit
{
    public sealed class RunTest
    {
        [Fact]
        public void ThrowsArgumentNullExceptionWhenVerbatimIsNull()
        {
            Assert.Throws<ArgumentNullException>("verbatim", () =>
            {
                new Run(false, false, false, null, "Example Plain Text String", 15);
            });
        }

        [Fact]
        public void ThrowsArgumentNullExceptionWhenVerbatimIsEmpty()
        {
            Assert.Throws<ArgumentOutOfRangeException>("verbatim", () =>
            {
                new Run(false, false, false, string.Empty, "Example Plain Text String", 15);
            });
        }

        [Fact]
        public void ThrowsArgumentNullExceptionWhenPlainTextIsNull()
        {
            Assert.Throws<ArgumentNullException>("plainText", () =>
            {
                new Run(false, false, false, "Example Verbatim String", null, 15);
            });
        }

        [Fact]
        public void ThrowsArgumentNullExceptionWhenPlainTextIsEmpty()
        {
            Assert.Throws<ArgumentOutOfRangeException>("plainText", () =>
            {
                new Run(false, false, false, "Example Verbatim String", string.Empty, 15);
            });
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        public void ThrowsArgumentOutOfRangeExceptionWhenFromColumnLessThanOne(int fromColumn)
        {
            Assert.Throws<ArgumentOutOfRangeException>("fromColumn", () =>
            {
                new Run(false, false, false, "Example Verbatim String", "Example Plain Text String", fromColumn);
            });
        }

        [Theory]
        [InlineData(false)]
        [InlineData(true)]
        public void CopiesBold(bool bold)
        {
            var run = new Run(bold, false, false, "Example Verbatim String", "Example Plain Text String", 15);

            Assert.Equal(bold, run.Bold);
        }

        [Theory]
        [InlineData(false)]
        [InlineData(true)]
        public void CopiesItalic(bool italic)
        {
            var run = new Run(false, italic, false, "Example Verbatim String", "Example Plain Text String", 15);

            Assert.Equal(italic, run.Italic);
        }

        [Theory]
        [InlineData(false)]
        [InlineData(true)]
        public void CopiesCode(bool code)
        {
            var run = new Run(false, false, code, "Example Verbatim String", "Example Plain Text String", 15);

            Assert.Equal(code, run.Code);
        }

        [Fact]
        public void CopiesVerbatim()
        {
            var run = new Run(false, false, false, "Example Verbatim String", "Example Plain Text String", 15);

            Assert.Equal("Example Verbatim String", run.Verbatim);
        }

        [Fact]
        public void CopiesPlainText()
        {
            var run = new Run(false, false, false, "Example Verbatim String", "Example Plain Text String", 15);

            Assert.Equal("Example Plain Text String", run.PlainText);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public void CopiesFromColumn(int fromColumn)
        {
            var run = new Run(false, false, false, "Example Verbatim String", "Example Plain Text String", fromColumn);

            Assert.Equal(fromColumn, run.FromColumn);
        }

        [Fact]
        public void CalculatesToColumn()
        {
            var run = new Run(false, false, false, "Example Verbatim String", "Example Plain Text String", 15);

            Assert.Equal(37, run.ToColumn);
        }
    }
}
