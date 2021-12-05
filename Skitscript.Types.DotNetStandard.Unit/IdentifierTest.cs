using System;
using System.Collections.Generic;
using Xunit;

namespace Skitscript.Types.DotNetStandard.Unit
{
    public sealed class IdentifierTest
    {
        [Fact]
        public void ThrowsArgumentNullExceptionWhenVerbatimIsNull()
        {
            Assert.Throws<ArgumentNullException>("verbatim", () =>
            {
                new Identifier(null, 15);
            });
        }

        [Fact]
        public void ThrowsArgumentOutOfRangeExceptionWhenVerbatimContainsOnlyExcludedCharacters()
        {
            Assert.Throws<ArgumentOutOfRangeException>("verbatim", () =>
            {
                new Identifier(":!?'\"{}@*/\\ \n \t \r &#%`+<=>|$.", 15);
            });
        }

        public static IEnumerable<object[]> WhiteSpaceCharacters
        {
            get
            {
                yield return new object[] { ' ' };
                yield return new object[] { '\r' };
                yield return new object[] { '\t' };
                yield return new object[] { '\n' };
            }
        }

        [Theory]
        [MemberData(nameof(WhiteSpaceCharacters))]
        public void ThrowsArgumentOutOfRangeExceptionWhenVerbatimStartsWithWhiteSpace(char character)
        {
            Assert.Throws<ArgumentOutOfRangeException>("verbatim", () =>
            {
                new Identifier($"{character}Example Verbatim String", 15);
            });
        }

        [Theory]
        [MemberData(nameof(WhiteSpaceCharacters))]
        public void ThrowsArgumentOutOfRangeExceptionWhenVerbatimEndsWithWhiteSpace(char character)
        {
            Assert.Throws<ArgumentOutOfRangeException>("verbatim", () =>
            {
                new Identifier($"Example Verbatim String{character}", 15);
            });
        }

        public static IEnumerable<object[]> DisallowedCharacters
        {
            get
            {
                yield return new object[] { ',' };
                yield return new object[] { '(' };
                yield return new object[] { ')' };
            }
        }

        public static IEnumerable<object[]> DisallowedWords
        {
            get
            {
                yield return new[] { "and" };
                yield return new[] { "or" };
                yield return new[] { "when" };
                yield return new[] { "not" };
                yield return new[] { "is" };
                yield return new[] { "are" };
                yield return new[] { "enters" };
                yield return new[] { "enter" };
                yield return new[] { "exits" };
                yield return new[] { "exit" };
                yield return new[] { "leads" };
                yield return new[] { "to" };
                yield return new[] { "set" };
                yield return new[] { "clear" };
                yield return new[] { "jump" };
            }
        }

        [Theory]
        [MemberData(nameof(DisallowedCharacters))]
        public void ThrowsArgumentOutOfRangeExceptionWhenVerbatimContainsDisallowedCharacters(char character)
        {
            Assert.Throws<ArgumentOutOfRangeException>("verbatim", () =>
            {
                new Identifier($"Example Verb{character}atim String", 15);
            });
        }

        [Theory]
        [MemberData(nameof(DisallowedWords))]
        public void ThrowsArgumentOutOfRangeExceptionWhenVerbatimContainsDisallowedWords(string word)
        {
            Assert.Throws<ArgumentOutOfRangeException>("verbatim", () =>
            {
                new Identifier($"Example {word} String", 15);
            });
        }

        [Fact]
        public void AllowsWordsToStartWithDisallowedWords()
        {
            new Identifier("Example andverbatim String", 15);
        }

        [Fact]
        public void AllowsWordsToContainDisallowedWords()
        {
            new Identifier("Example verbatimandverbatim String", 15);
        }

        [Fact]
        public void AllowsWordsToEndWithDisallowedWords()
        {
            new Identifier("Example verbatimand String", 15);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        public void ThrowsArgumentOutOfRangeExceptionWhenFromColumnLessThanOne(int fromColumn)
        {
            Assert.Throws<ArgumentOutOfRangeException>("fromColumn", () =>
            {
                new Identifier("Example Verbatim String", fromColumn);
            });
        }

        [Fact]
        public void CopiesVerbatim()
        {
            var identifier = new Identifier("Example! Ident*ifier String", 15);

            Assert.Equal("Example! Ident*ifier String", identifier.Verbatim);
        }

        [Fact]
        public void NormalizesVerbatim()
        {
            var identifier = new Identifier("Example! Ident*ifier String", 15);

            Assert.Equal("example-ident-ifier-string", identifier.Normalized);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public void CopiesFromColumn(int fromColumn)
        {
            var identifier = new Identifier("Example! Ident*ifier String", fromColumn);

            Assert.Equal(fromColumn, identifier.FromColumn);
        }

        [Fact]
        public void CalculatesToColumn()
        {
            var identifier = new Identifier("Example! Ident*ifier String", 15);

            Assert.Equal(41, identifier.ToColumn);
        }
    }
}
