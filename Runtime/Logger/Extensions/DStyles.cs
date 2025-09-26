using UnityEngine;

namespace StripedArts.Unity.Core.Logging.Core.Extensions
{
    public static class DStyles
    {
        private const string WhiteColor = "<color=white>";
        private const string YellowColor = "<color=yellow>";
        private const string CyanColor = "<color=cyan>";
        private const string GreenColor = "<color=green>";
        private const string RedColor = "<color=red>";
        private const string BlueColor = "<color=blue>";
        private const string MagentaColor = "<color=magenta>";

        private const string ColorClose = "</color>";

        private const string BoldOpen = "<b>";
        private const string BoldClose = "</b>";

        /// <summary>
        /// Make text Bold
        /// </summary>
        /// <param name="value">text body</param>
        /// <returns>string</returns>
        public static string Bold(this string value) =>
            Application.isEditor ? BoldOpen + value + BoldClose : value;

        /// <summary>
        /// Make text White
        /// </summary>
        /// <param name="value">text body</param>
        /// <returns>string</returns>
        public static string White(this string value) =>
            Colored(value, WhiteColor);

        /// <summary>
        /// Make text Yellow
        /// </summary>
        /// <param name="value">text body</param>
        /// <returns>string</returns>
        public static string Yellow(this string value) =>
            Colored(value, YellowColor);

        /// <summary>
        /// Make text Cyan
        /// </summary>
        /// <param name="value">text body</param>
        /// <returns>string</returns>
        public static string Cyan(this string value) =>
            Colored(value, CyanColor);

        /// <summary>
        /// Make text Green
        /// </summary>
        /// <param name="value">text body</param>
        /// <returns>string</returns>
        public static string Green(this string value) =>
            Colored(value, GreenColor);

        /// <summary>
        /// Make text Red
        /// </summary>
        /// <param name="value">text body</param>
        /// <returns>string</returns>
        public static string Red(this string value) =>
            Colored(value, RedColor);

        /// <summary>
        /// Make text Blue
        /// </summary>
        /// <param name="value">text body</param>
        /// <returns>string</returns>
        public static string Blue(this string value) =>
            Colored(value, BlueColor);

        /// <summary>
        /// Make text Magenta
        /// </summary>
        /// <param name="value">text body</param>
        /// <returns>string</returns>
        public static string Magenta(this string value) =>
            Colored(value, MagentaColor);

        private static string Colored(this string value, string color) =>
            Application.isEditor ? color + value + ColorClose : value.ToString();
    }
}
