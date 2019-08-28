using System;
using System.Linq;
using System.Collections.Generic;
using Xunit;

namespace Kata.StolenLunch
{
    public class StolenLunchTests
    {
        private readonly Kata _kata;
        public StolenLunchTests()
        {
            _kata = new Kata();
        }

        [Fact]
        public void WhenNoteHasMixOfLettersAndDigits_ReturnsDecodedCharacters()
        {
            Assert.Equal("you'll never guess it: 2390",
                _kata.StolenLunch("you'll n4v4r 6u4ss 8t: cdja"));
        }

        [Fact]
        public void WhenCharacterIsFromAToJ_Returns0to9()
        {
            Assert.Equal("abcdefghij", _kata.StolenLunch("0123456789"));
        }

        [Fact]
        public void WhenCharacterIsKToZ_ReturnsTheSameCharacter()
        {
            Assert.Equal("klmnopqrstuvwxyz",
                _kata.StolenLunch("klmnopqrstuvwxyz"));
        }

        [Fact]
        public void WhenCharacterIsFrom0to9_ReturnsAToJ()
        {
            Assert.Equal("0123456789", _kata.StolenLunch("abcdefghij"));
        }

        [Fact]
        public void WhenCharacterIsSpace_ReturnsSpace()
        {
            Assert.Equal(" ", _kata.StolenLunch(" "));
        }

        public void WhenCharacterIsPunctuation_ReturnsTheSameCharacter()
        {
            Assert.Equal("`-=[]\\;',./~!@#$%^&*()_+{}|:\"<>?",
                _kata.StolenLunch("`-=[]\\;',./~!@#$%^&*()_+{}|:\"<>?"));
        }

        [Fact]
        public void WhenNoteIsEmpty_ReturnsEmpty()
        {
            Assert.Equal(String.Empty, _kata.StolenLunch(String.Empty));
        }
    }

    public class Kata
    {
        public string StolenLunch(string note)
        {
            var map = new Dictionary<char, char>
            {
                { '0', 'a'}, { '1', 'b' }, { '2', 'c' }, { '3', 'd' },
                { '4', 'e' }, { '5', 'f'}, { '6', 'g' }, { '7', 'h' },
                { '8', 'i' }, { '9', 'j'},

                { 'a', '0' }, { 'b', '1' }, { 'c', '2' }, { 'd', '3' },
                { 'e', '4' }, { 'f', '5'}, { 'g', '6' }, { 'h', '7' },
                { 'i', '8' }, { 'j', '9'},
            };

            return String.Concat(
                note.Select(character =>
                    map.ContainsKey(character)
                        ? map[character]
                        : character));
        }
    }
}
