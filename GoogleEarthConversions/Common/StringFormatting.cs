namespace GoogleEarthConversions.Core.Common
{
    public static class StringFormatting
    {
        public static string ConvertFirstCharacterToLowerCase(this string stringToConvert)
        {
            var convertedString = "";

            if (stringToConvert.Length == 1)
                return stringToConvert.ToLower();

            if (stringToConvert.Length > 1)
            {
                var firstCharacter = stringToConvert.Substring(0, 1);
                var stringRemainder = stringToConvert.Substring(1, stringToConvert.Length - 1);
                return firstCharacter.ToLower() + stringRemainder;
            }

            return convertedString;
        }
    }
}
