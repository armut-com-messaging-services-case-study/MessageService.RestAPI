using System;
using System.Text.RegularExpressions;

namespace MessageService.RestAPI.Utilities
{
    public class ParameterValidator
    {
        public static void IsNotNullOrWhiteSpace(string param, string paramName)
        {
            if (String.IsNullOrWhiteSpace(param))
            {
                throw new ArgumentException("Invalid string parameter, cannot be null, empty, or contain only whitespace", paramName);
            }
        }

        public static void IsNotNull(object param, string paramName)
        {
            if (param == null)
            {
                throw new ArgumentNullException(paramName);
            }
        }

        public static void ContainsAtLeast<T>(T[] param, int n, string paramName)
        {
            if (n < 0)
            {
                throw new ArgumentOutOfRangeException("n");
            }

            if (param == null)
            {
                throw new ArgumentNullException(paramName);
            }

            if (param.Length < n)
            {
                throw new ArgumentException(String.Format("The array contains {0} elements, but at least {1} were expected", param.Length, n), paramName);
            }
        }

        public static void IsValidMessageType(MessageService.RestAPI.Objects.MessageType messagetype)
        {
            if (messagetype == MessageService.RestAPI.Objects.MessageType.Tts)
            {
                throw new ArgumentException(String.Format("Messagetype not supported : {0}", messagetype));
            }

        }

        public static void IsValidOriginator(string originator)
        {
            const int ORIGINATOR_ALPHANUMERIC_MAXLENGTH = 11;

            // a telephone number (including country code) or an alphanumeric string.
            // the maximum length is 11 characters.

            if (!string.IsNullOrEmpty(originator))
            {
                var numeric = new Regex("^\\+?[0-9]+$");
                var alphanumericWithWhitespace = new Regex("^[A-Za-z0-9]+(?:\\s[A-Za-z0-9]+)*$");
                var isNumeric = numeric.IsMatch(originator);
                var isAlphanumericWithWhitespace = alphanumericWithWhitespace.IsMatch(originator);

                if (!isNumeric && !isAlphanumericWithWhitespace)
                {
                    throw new ArgumentException("Originator can only contain numeric or whitespace separated alphanumeric characters.");
                }
                else if (!isNumeric && isAlphanumericWithWhitespace && originator.Length > ORIGINATOR_ALPHANUMERIC_MAXLENGTH)
                {
                    throw new ArgumentException(string.Format("Alphanumeric originator is limited to {0} characters.", ORIGINATOR_ALPHANUMERIC_MAXLENGTH));
                }
            }
        }
    }
}