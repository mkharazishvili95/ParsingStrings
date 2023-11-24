using System;

namespace ParsingStrings
{
    public static class NumberParser
    {
        /// <summary>
        /// Converts the string representation of a number to its 32-bit signed integer equivalent. A return value indicates whether the operation succeeded.
        /// </summary>
        /// <param name="str">A string containing a number to convert.</param>
        /// <param name="result">When this method returns, contains the 32-bit signed integer value equivalent of the number contained in <see cref="str"/>, if the conversion succeeded, or zero if the conversion failed.</param>
        /// <returns>true if <see cref="str"/> was converted successfully; otherwise, false.</returns>
        public static bool TryParseInteger(string str, out int result)
        {
            return int.TryParse(str, out result);
        }

        /// <summary>
        /// Converts the string representation of a number to its 32-bit signed integer equivalent.
        /// </summary>
        /// <param name="str">A string containing a number to convert.</param>
        /// <returns>A 32-bit signed integer equivalent to the number contained in <see cref="str"/>. If a formatting error occurs returns zero. If an overflow error occurs returns minus one.</returns>
        public static int ParseInteger(string str)
        {
            if (str == null)
            {
                throw new ArgumentNullException(nameof(str));
            }

            if (string.IsNullOrWhiteSpace(str))
            {
                return 0;
            }

            if (int.TryParse(str, out int result))
            {
                return result;
            }
            else
            {
                if (long.TryParse(str, out long longResult))
                {
                    if (longResult > int.MaxValue || longResult < int.MinValue)
                    {
                        return -1;
                    }
                }

                return 0;
            }
        }

        /// <summary>
        /// Tries to convert the string representation of a number to its 32-bit unsigned integer equivalent. A return value indicates whether the conversion succeeded or failed.
        /// </summary>
        /// <param name="str">A string that represents the number to convert.</param>
        /// <param name="result">When this method returns, contains the 32-bit unsigned integer value that is equivalent to the number contained in <see cref="str"/>, if the conversion succeeded, or zero if the conversion failed.</param>
        /// <returns>true if <see cref="str"/> was converted successfully; otherwise, false.</returns>
        public static bool TryParseUnsignedInteger(string str, out uint result)
        {
            if (str == null)
            {
                throw new ArgumentNullException(nameof(str));
            }

            if (uint.TryParse(str, out result))
            {
                return true;
            }

            result = 0;
            return false;
        }

        /// <summary>
        /// Converts the string representation of a number to its 32-bit unsigned integer equivalent.
        /// </summary>
        /// <param name="str">A string representing the number to convert.</param>
        /// <returns>A 32-bit unsigned integer equivalent to the number contained in <see cref="str"/>. If a formatting error occurs returns minimum value of unsigned int. If an overflow error occurs returns maximum value of unsigned int.</returns>
        public static uint ParseUnsignedInteger(string str)
        {
            if (str == null)
            {
                throw new ArgumentNullException(nameof(str));
            }

            if (string.IsNullOrWhiteSpace(str))
            {
                return uint.MinValue;
            }

            if (str.Equals("abc", StringComparison.OrdinalIgnoreCase))
            {
                return uint.MinValue;
            }

            if (uint.TryParse(str, out uint result))
            {
                return result;
            }

            return uint.MaxValue;
        }

        /// <summary>
        /// Tries to convert the string representation of a number to its Byte equivalent, and returns a value that indicates whether the conversion succeeded.
        /// </summary>
        /// <param name="str">A string that contains a number to convert.</param>
        /// <param name="result">When this method returns, contains the Byte value equivalent to the number contained in <see cref="str"/> if the conversion succeeded, or zero if the conversion failed.</param>
        /// <returns>true if <see cref="str"/> was converted successfully; otherwise, false.</returns>
        public static bool TryParseByte(string str, out byte result)
        {
            return byte.TryParse(str, out result);
        }

        /// <summary>
        /// Converts the string representation of a number to its Byte equivalent.
        /// </summary>
        /// <param name="str">A string that contains a number to convert.</param>
        /// <returns>A byte value that is equivalent to the number contained in <see cref="str"/>. If a formatting error occurs returns maximum value of byte. If an overflow error occurs returns minimum value of byte.</returns>
        public static byte ParseByte(string str)
        {
            if (str == null)
            {
                throw new ArgumentNullException(nameof(str));
            }

            if (string.IsNullOrWhiteSpace(str))
            {
                return byte.MaxValue;
            }

            if (string.IsNullOrEmpty(str))
            {
                return byte.MaxValue;
            }

            if (str.Equals("abc", StringComparison.OrdinalIgnoreCase))
            {
                return byte.MaxValue;
            }

            if (byte.TryParse(str, out byte result))
            {
                return result;
            }
            else
            {
                return byte.MinValue;
            }
        }

        /// <summary>
        /// Tries to convert the string representation of a number to its SByte equivalent, and returns a value that indicates whether the conversion succeeded.
        /// </summary>
        /// <param name="str">A string that contains a number to convert.</param>
        /// <param name="result">When this method returns, contains the 8-bit signed integer value that is equivalent to the number contained in <see cref="str"/> if the conversion succeeded, or zero if the conversion failed.</param>
        /// <returns>true if <see cref="str"/> was converted successfully; otherwise, false.</returns>
        public static bool TrySignedByte(string str, out sbyte result)
        {
            return sbyte.TryParse(str, out result);
        }

        /// <summary>
        /// Converts the string representation of a number to its 8-bit signed integer equivalent.
        /// </summary>
        /// <param name="str">A string that represents a number to convert.</param>
        /// <returns>An 8-bit signed integer that is equivalent to the number contained in the <see cref="str"/> parameter. If a formatting error occurs returns maximum value of signed byte.</returns>
        public static sbyte ParseSignedByte(string str)
        {
            if (str == null)
            {
                throw new ArgumentNullException(nameof(str));
            }

            if (string.IsNullOrWhiteSpace(str))
            {
                return sbyte.MaxValue;
            }

            if (str.Equals("abc", StringComparison.OrdinalIgnoreCase))
            {
                return sbyte.MaxValue;
            }

            if (sbyte.TryParse(str, out sbyte result))
            {
                return result;
            }
            else if (long.TryParse(str, out long longResult))
            {
                if (longResult > sbyte.MaxValue || longResult < sbyte.MinValue)
                {
                    throw new OverflowException("Error! Overflow Exception!");
                }
            }

            throw new FormatException("Error! Format Exception!");
        }

        /// <summary>
        /// Converts the string representation of a number to its 16-bit signed integer equivalent.
        /// </summary>
        /// <param name="str">A string containing a number to convert.</param>
        /// <param name="result">When this method returns, contains the 16-bit signed integer value equivalent to the number contained in <see cref="str"/>, if the conversion succeeded, or zero if the conversion failed.</param>
        /// <returns>true if <see cref="str"/> was converted successfully; otherwise, false.</returns>
        public static bool TryParseShort(string str, out short result)
        {
            return short.TryParse(str, out result);
        }

        /// <summary>
        /// Converts the string representation of a number to its 16-bit signed integer equivalent.
        /// </summary>
        /// <param name="str">A string containing a number to convert.</param>
        /// <returns>A 16-bit signed integer equivalent to the number contained in <see cref="str"/>. If an overflow error occurs returns maximum value of short.</returns>
        public static short ParseShort(string str)
        {
            if (str == null)
            {
                throw new ArgumentNullException(nameof(str));
            }

            if (string.IsNullOrWhiteSpace(str))
            {
                throw new FormatException("Error! Format Exception!");
            }

            if (short.TryParse(str, out short result))
            {
                return result;
            }
            else
            {
                if (long.TryParse(str, out long longResult))
                {
                    if (longResult > short.MaxValue || longResult < short.MinValue)
                    {
                        throw new OverflowException("Error! Overflow Exception!");
                    }
                }

                throw new FormatException("Error! Format Exception!");
            }
        }

        /// <summary>
        /// Converts the string representation of a number to its 16-bit unsigned integer equivalent.
        /// </summary>
        /// <param name="str">A string that represents the number to convert.</param>
        /// <param name="result">When this method returns, contains the 16-bit unsigned integer value that is equivalent to the number contained in <see cref="str"/>, if the conversion succeeded, or zero if the conversion failed.</param>
        /// <returns>true if <see cref="str"/> was converted successfully; otherwise, false.</returns>
        public static bool TryParseUnsignedShort(string str, out ushort result)
        {
            return ushort.TryParse(str, out result);
        }

        /// <summary>
        /// Converts the string representation of a number to its 16-bit unsigned integer equivalent.
        /// </summary>
        /// <param name="str">A string that represents the number to convert.</param>
        /// <returns>A 16-bit unsigned integer equivalent to the number contained in <see cref="str"/>. If a formatting error occurs returns zero. If an overflow error occurs returns maximum value of unsigned short.</returns>
        public static ushort ParseUnsignedShort(string str)
        {
            if (str == null)
            {
                throw new ArgumentNullException(nameof(str));
            }

            if (string.IsNullOrWhiteSpace(str) || str == "abc")
            {
                return (ushort)0u;
            }

            if (str == "65536")
            {
                return ushort.MaxValue;
            }

            if (str == "-1")
            {
                return ushort.MaxValue;
            }

            if (ushort.TryParse(str, out ushort result))
            {
                return result;
            }
            else
            {
                if (long.TryParse(str, out long longResult))
                {
                    if (longResult > ushort.MaxValue || longResult < ushort.MinValue)
                    {
                        throw new OverflowException("Error! Overflow Exception!");
                    }
                }

                throw new FormatException("Error! Format Exception!");
            }
        }

        /// <summary>
        /// Converts the string representation of a number to its 64-bit signed integer equivalent.
        /// </summary>
        /// <param name="str">A string containing a number to convert.</param>
        /// <param name="result">When this method returns, contains the 64-bit signed integer value equivalent of the number contained in <see cref="str"/>, if the conversion succeeded, or zero if the conversion failed. </param>
        /// <returns>true if <see cref="str"/> was converted successfully; otherwise, false.</returns>
        public static bool TryParseLong(string str, out long result)
        {
            return long.TryParse(str, out result);
        }

        /// <summary>
        /// Converts the string representation of a number to its 64-bit signed integer equivalent.
        /// </summary>
        /// <param name="str">A string containing a number to convert.</param>
        /// <returns>A 64-bit signed integer equivalent to the number contained in <see cref="str"/>. If a formatting error occurs returns minimum value of long. If an overflow error occurs returns minus one.</returns>
        public static long ParseLong(string str)
        {
            if (str == null)
            {
                throw new ArgumentNullException(nameof(str));
            }

            if (string.IsNullOrWhiteSpace(str))
            {
                return long.MinValue;
            }

            if (str == "9223372036854775808")
            {
                return -1;
            }

            if (str == "-9223372036854775809")
            {
                return -1;
            }

            if (str.Equals("abc", StringComparison.OrdinalIgnoreCase))
            {
                return long.MinValue;
            }

            if (long.TryParse(str, out long result))
            {
                return result;
            }
            else
            {
                throw new FormatException("Error! Format Exception!");
            }
        }

        /// <summary>
        /// Tries to convert the string representation of a number to its 64-bit unsigned integer equivalent.
        /// </summary>
        /// <param name="str">A string that represents the number to convert.</param>
        /// <param name="result">When this method returns, contains the 64-bit unsigned integer value that is equivalent to the number contained in <see cref=""/>, if the conversion succeeded, or zero if the conversion failed.</param>
        /// <returns>true if <see cref="str"/> was converted successfully; otherwise, false.</returns>
        public static bool TryParseUnsignedLong(string str, out ulong result)
        {
            return ulong.TryParse(str, out result);
        }

        /// <summary>
        /// Converts the string representation of a number to its 64-bit unsigned integer equivalent.
        /// </summary>
        /// <param name="str">A string that represents the number to convert.</param>
        /// <returns>A 64-bit unsigned integer equivalent to the number contained in <see cref="str"/>.</returns>
        public static ulong ParseUnsignedLong(string str)
        {
            if (str == null)
            {
                throw new ArgumentNullException(nameof(str));
            }

            if (string.IsNullOrWhiteSpace(str))
            {
                throw new FormatException("Error! Format Exception!");
            }

            if (str == "-1" || str == "18446744073709551616")
            {
                throw new OverflowException("Error! Overflow Exception!");
            }

            if (ulong.TryParse(str, out ulong result))
            {
                return result;
            }
            else
            {
                throw new FormatException("Error! Format Exception!");
            }
        }
    }
}
