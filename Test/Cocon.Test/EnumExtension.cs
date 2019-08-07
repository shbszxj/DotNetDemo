using System;

namespace Cocon.Test
{
    public static class EnumExtension
    {
        public static T CastEnumerationValue<T>(this string value, T defaultValue) where T : struct
        {
            T parsed;
            if (!Enum.TryParse(value, true, out parsed))
            {
                return defaultValue;
            }
            return parsed;
        }
    }
}
