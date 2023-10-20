using Leovaria.Extensions.String.Guards;
using System.Text;

namespace Leovaria.Extensions.String
{
    /// <summary>
    /// Extensions for strings.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Takes up to specified amount of characters from the beginning of the string.
        /// </summary>
        /// <param name="inputString">The string to take characters from.</param>
        /// <param name="numberOfCharacters">The number of characters to take.</param>
        /// <returns>
        /// The front characters up to <paramref name="numberOfCharacters"/>. If
        /// there are not enough characters, the method will return the 
        /// <paramref name="inputString"/> back.
        /// </returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="inputString"/> is null.</exception>
        /// <exception cref="ArgumentException">Thrown if <paramref name="numberOfCharacters"/> is less than zero.</exception>
        public static string TakeUpTo(this string inputString, int numberOfCharacters)
        {
            var result = TakeUpTo(inputString, numberOfCharacters, 0);
            return result;
        }

        /// <summary>
        /// Takes up to specified amount of characters from the beginning of the string.
        /// </summary>
        /// <param name="inputString">The string to take characters from.</param>
        /// <param name="numberOfCharacters">The number of characters to take.</param>
        /// <returns>
        /// The front characters up to <paramref name="numberOfCharacters"/>. If
        /// there are not enough characters, the method will return the 
        /// <paramref name="inputString"/> back.
        /// </returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="inputString"/> is null.</exception>
        /// <exception cref="ArgumentException">Thrown if <paramref name="numberOfCharacters"/> is less than zero.</exception>
        public static string TakeUpTo(this string inputString, int numberOfCharacters, int startIndex)
        {
            ThisShould.NotBeNull(inputString);
            ThisShould.BeZeroOrMore(numberOfCharacters);
            ThisShould.BeZeroOrMore(startIndex);
            
            var substring = inputString[startIndex..];

            if (substring.Length <= numberOfCharacters)
            {
                return substring;
            }

            return substring[..numberOfCharacters];
        }

        /// <summary>
        /// Takes up to specified amount of characters from the end of the string.
        /// </summary>
        /// <param name="inputString">The string to take characters from.</param>
        /// <param name="numberOfCharacters">The number of characters to take from the end.</param>
        /// <returns>
        /// The end characters up to <paramref name="numberOfCharacters"/>. If
        /// there are not enough characters, the method will return the 
        /// <paramref name="inputString"/> back.
        /// </returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="inputString"/> is null.</exception>
        /// <exception cref="ArgumentException">Thrown if <paramref name="numberOfCharacters"/> is less than zero.</exception>
        public static string TakeUpToLast(this string inputString, int numberOfCharacters)
        {
            ThisShould.NotBeNull(inputString);
            ThisShould.BeZeroOrMore(numberOfCharacters);

            if (inputString.Length <= numberOfCharacters)
            {
                return inputString;
            }

            var charArray = new char[numberOfCharacters];

            for (var i = 0; i < numberOfCharacters; i++)
            {
                charArray[i] = inputString[inputString.Length - numberOfCharacters + i];
            }

            return string.Join(null, charArray);
        }

        /// <summary>
        /// Capitalizes the first letter of the string, if not capitalized already.
        /// </summary>
        /// <param name="inputString">The string to take characters from.</param>
        /// <returns>
        /// The input <paramref name="inputString"/> with the first letter capitalized.        
        /// </returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="inputString"/> is null.</exception>        
        public static string Capitalize(this string inputString)
        {
            ThisShould.NotBeNull(inputString);

            if (inputString.Length == 0)
            {
                return string.Empty;
            }

            if (!char.IsLetter(inputString[0]))
            {
                return inputString;
            }
            
            var charArray = inputString.ToCharArray();

            var capitalLetter = char.ToUpper(charArray[0]);

            charArray[0] = capitalLetter;

            return string.Join(null, charArray);
        }

        /// <summary>
        /// Removes all occurrences of <paramref name="stringsToRemove"/> from
        /// the <paramref name="inputString"/>.
        /// </summary>
        /// <param name="inputString">String to remove parts from.</param>
        /// <param name="stringsToRemove">
        /// Enumerable of strings to remove from the
        /// <paramref name="inputString"/>
        /// </param>
        /// <returns>
        /// New string with any occurrences of <paramref name="stringsToRemove"/>
        /// removed from the original <paramref name="inputString"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="inputString"/> is null.
        /// Thrown if <paramref name="stringsToRemove"/> is null.
        /// </exception>
        public static string RemoveAll(this string inputString, IEnumerable<string> stringsToRemove)
        {
            ThisShould.NotBeNull(inputString);
            ThisShould.NotBeNull(stringsToRemove);
            
            if (!stringsToRemove.Any())
            {
                return inputString;
            }

            var newString = new StringBuilder(inputString);

            // We order by length descending to ensure we remove longer versions of
            // strings first. For example, we want to make sure we remove "REMOVEME"
            // first before "REMOVE". If we remove "REMOVE" first, then "ME" would
            // remain.
            foreach (var stringToRemove in stringsToRemove.OrderByDescending(x => x.Length))
            {
                newString.Replace(stringToRemove, string.Empty);
            }

            return newString.ToString();
        }

        /// <summary>
        /// Splits the <paramref name="inputString"/> into fixed length
        /// chunks based on the <paramref name="splitLength"/>.
        /// </summary>
        /// <param name="inputString">String to split into chunks.</param>
        /// <param name="splitLength">Amount of characters in each chunk.</param>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="inputString"/> is null.
        /// </exception>
        /// /// <exception cref="ArgumentException">
        /// Thrown if <paramref name="splitLength"/> is less than zero.
        /// </exception>
        public static List<string> SplitByLength(this string inputString, int splitLength)
        {
            ThisShould.NotBeNull(inputString);
            ThisShould.BeZeroOrMore(splitLength);

            var splitList = new List<string>();

            if (splitLength == 0)
            {
                splitList.Add(inputString);
                return splitList;
            }

            var splitChunks = Math.Ceiling((double) inputString.Length / splitLength);
            var chunkStart = 0;

            for (var i = 0; i < splitChunks; i++)
            {
                splitList.Add(inputString.TakeUpTo(splitLength, chunkStart));
                chunkStart += splitLength;
            }

            return splitList;
        }
    }
} 