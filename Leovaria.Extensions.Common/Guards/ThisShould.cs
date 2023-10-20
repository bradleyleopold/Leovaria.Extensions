namespace Leovaria.Extensions.String.Guards
{
    /// <summary>
    /// Guards against typical things that occur.
    /// </summary>
    public static class ThisShould
    {
        /// <summary>
        /// Throws an ArgumentNullException if the input <paramref name="inputObject"/>
        /// is null.
        /// </summary>
        /// <param name="inputObject">Object to check.</param>
        /// <exception cref="ArgumentNullException">
        /// Thrown if input is null.
        /// </exception>
        public static void NotBeNull(object inputObject)
        {
            if (inputObject is null)
            {
                throw new ArgumentNullException(nameof(inputObject));
            }
        }

        /// <summary>
        /// Throws an ArgumentException if <paramref name="inputInt"/> is
        /// not zero or more.
        /// </summary>
        /// <param name="inputInt">Int to check.</param>
        /// <exception cref="ArgumentException">
        /// Thrown if input is less than zero.
        /// </exception>
        public static void BeZeroOrMore(int inputInt)
        {
            if (inputInt < 0)
            {
                throw new ArgumentException(null, nameof(inputInt));
            }
        }

        /// <summary>
        /// Throws an ArgumentException if <paramref name="inputInt"/> is
        /// not over zero.
        /// </summary>
        /// <param name="inputInt">Int to check.</param>
        /// <exception cref="ArgumentException">
        /// Thrown if input is not over zero.
        /// </exception>
        public static void BeOverZero(int inputInt)
        {
            if (inputInt <= 0)
            {
                throw new ArgumentException(null, nameof(inputInt));
            }
        }
    }
}
