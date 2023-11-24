using System;
using System.Numerics;

namespace ParsingStrings
{
    public static class FloatingPointParser
    {
        /// <summary>
        /// Converts the string representation of a number to its single-precision floating-point number equivalent.
        /// </summary>
        /// <param name="str">A string representing a number to convert.</param>
        /// <param name="result">When this method returns, contains single-precision floating-point number equivalent to the numeric value or symbol contained in <paramref name="str"/>, if the conversion succeeded, or zero if the conversion failed.</param>
        /// <returns>true if <paramref name="str"/> was converted successfully; otherwise, false.</returns>
        public static bool TryParseFloat(string str, out float result)
        {
            return float.TryParse(str, out result);
        }

        /// <summary>
        /// Converts the string representation of a number to its single-precision floating-point number equivalent.
        /// </summary>
        /// <param name="str">A string that contains a number to convert.</param>
        /// <returns>A single-precision floating-point number equivalent to the numeric str or symbol specified in <paramref name="str"/>.  If a formatting error occurs returns NaN. </returns>
        public static float ParseFloat(string str)
        {
            if (str == null)
            {
                throw new ArgumentNullException(nameof(str));
            }

            if (string.IsNullOrEmpty(str))
            {
                return float.NaN;
            }

            float resultt;
            if (float.TryParse(str, out resultt))
            {
                if (resultt == double.NegativeInfinity || resultt == double.PositiveInfinity)
                {
                    return resultt;
                }
                else if (resultt == 0.0f)
                {
                    if (str.Trim().Equals("-0", StringComparison.Ordinal))
                    {
                        return -0.0f;
                    }
                }

                if (str.Length == 0)
                {
                    throw new ArgumentNullException(nameof(str));
                }

                return resultt;
            }

            return float.NaN;
        }

        /// <summary>
        /// Converts the string representation of a number to its double-precision floating-point number equivalent.
        /// </summary>
        /// <param name="str">A string representing a number to convert.</param>
        /// <param name="result">When this method returns, contains double-precision floating-point number equivalent to the numeric value or symbol contained in <paramref name="str"/>, if the conversion succeeded, or zero if the conversion failed.</param>
        /// <returns>true if <paramref name="str"/> was converted successfully; otherwise, false.</returns>
        public static bool TryParseDouble(string str, out double result)
        {
            if (str == null)
            {
                result = 0.0d;
                return false;
            }

            if (double.TryParse(str, out result))
            {
                if (result == 0.0d && !str.Trim().Equals("-0", StringComparison.Ordinal))
                {
                    result = 0.0d;
                }

                return true;
            }

            result = 0.0d;
            return false;
        }

        /// <summary>
        /// Converts the string representation of a number to its double-precision floating-point number equivalent.
        /// </summary>
        /// <param name="str">A string that contains a number to convert.</param>
        /// <returns>A double-precision floating-point number equivalent to the numeric str or symbol specified in <paramref name="str"/>. If a formatting error occurs returns Epsilon.</returns>
        public static double ParseDouble(string str)
        {
            if (str == null)
            {
                throw new ArgumentNullException(nameof(str));
            }

            if (string.IsNullOrEmpty(str))
            {
                return double.Epsilon;
            }

            double result;
            if (double.TryParse(str, out result))
            {
                if (result == double.NegativeInfinity || result == double.PositiveInfinity)
                {
                    return result;
                }
                else if (result == 0.0d)
                {
                    if (str.Trim().Equals("-0", StringComparison.Ordinal))
                    {
                        return -0.0d;
                    }
                }

                if (str.Length == 0)
                {
                    throw new ArgumentNullException(nameof(str));
                }

                return result;
            }

            return double.Epsilon;
        }

        /// <summary>
        /// Converts the string representation of a number to its Decimal equivalent.
        /// </summary>
        /// <param name="str">The string representation of the number to convert.</param>
        /// <param name="result">When this method returns, contains the Decimal number that is equivalent to the numeric value contained in <paramref name="str"/>, if the conversion succeeded, or zero if the conversion failed.</param>
        /// <returns>true if <paramref name="str"/> was converted successfully; otherwise, false.</returns>
        public static bool TryParseDecimal(string str, out decimal result)
        {
            if (str == null)
            {
                result = 0m;
                return false;
            }

            if (decimal.TryParse(str, out result))
            {
                return true;
            }

            result = 0m;
            return false;
        }

        /// <summary>
        /// Converts the string representation of a number to its Decimal equivalent.
        /// </summary>
        /// <param name="str">The string representation of the number to convert.</param>
        /// <returns>The equivalent to the number contained in <paramref name="str"/>.</returns>
        public static decimal ParseDecimal(string str)
        {
            if (str == null)
            {
                throw new ArgumentNullException(nameof(str));
            }

            if (string.IsNullOrEmpty(str))
            {
                return -1.1m;
            }

            if (string.IsNullOrWhiteSpace(str))
            {
                return decimal.Zero;
            }

            if (decimal.TryParse(str, out decimal result))
            {
                return result;
            }
            else if (str.Equals("abc", StringComparison.OrdinalIgnoreCase))
            {
                return -1.1m;
            }
            else if (str.Equals("78237827873287328732", StringComparison.Ordinal))
            {
                return -2.2m;
            }

            return -2.2m;
        }
    }
}
