using System.Text;
using System.Diagnostics;
using System.Globalization;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Web;
using Writely.Common.Guards;
using Writely.Common.Urls;


namespace Writely.Common.Extensions
{
    public static class StringExtensions
    {
        private static readonly Regex EmailExpression =
          new Regex("^([0-9a-zA-Z]+[-._+&])*[0-9a-zA-Z]+@([-0-9a-zA-Z]+[.])+[a-zA-Z]{2,6}$",
              RegexOptions.Singleline | RegexOptions.Compiled);

        private static readonly Regex GuidExpression = new Regex(@"[0-9a-f]{8}\-([0-9a-f]{4}\-){3}[0-9a-f]{12}");

        private static readonly char[] IllegalUrlCharacters =
        {
            ';', '/', '\\', '?', ':', '@', '&', '=', '+', '$', ',', '<', '>', '#', '%', '.',
            '!', '*', '\'', '"', '(', ')', '[', ']', '{', '}', '|', '^', '`', '~', '–', '‘',
            '’', '“', '”', '\x00bb', '\x00ab'
        };

        private static readonly Regex StripHTMLExpression = new Regex(@"<\S[^><]*>",
            RegexOptions.CultureInvariant | RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.Multiline |
            RegexOptions.IgnoreCase);

        private static readonly Regex WebUrlExpression = new Regex(@"(http|https)://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?",
            RegexOptions.Singleline | RegexOptions.Compiled);

        public static string AddOrdinal(this int num)
        {
            if (num <= 0) return num.ToString();

            switch (num % 100)
            {
                case 11:
                case 12:
                case 13:
                    return num + "th";
            }

            switch (num % 10)
            {
                case 1:
                    return num + "st";
                case 2:
                    return num + "nd";
                case 3:
                    return num + "rd";
                default:
                    return num + "th";
            }
        }

        public static bool ContainsSpecialCharacters(this string value)
        {
            var regex = new Regex(@"[^a-zA-Z0-9]",
                RegexOptions.IgnoreCase | RegexOptions.CultureInvariant | RegexOptions.Compiled);
            var match = regex.Match(value);
            return match.Success;
        }

        public static string GetExactMatchRegex(this string code)
        {
            return "^" + code + "$";
        }

        public static string GetLastFourDigits(this string value)
        {
            return !string.IsNullOrWhiteSpace(value) && value.Length > 4 ? value.Substring(value.Length - 4, 4) : value;
        }

        public static string GetSubstring(string a, string b, string c)
        {
            return c.Substring(c.IndexOf(a, StringComparison.Ordinal) + a.Length,
                c.IndexOf(b, StringComparison.Ordinal) - c.IndexOf(a, StringComparison.Ordinal) - a.Length);
        }

        public static string HtmlEnableIt(this string value)
        {
            return value.Replace(Environment.NewLine, "<br/>").Replace("\n", "<br/>");
        }

        public static bool IsEmpty(this string item)
        {
            return string.IsNullOrWhiteSpace(item);
        }

        public static bool IsNotEmpty(this string item)
        {
            return !string.IsNullOrWhiteSpace(item);
        }

        public static string JoinEm(this List<string> options, string separator)
        {
            return JoinEm(options, separator, "");
        }

        public static string JoinEm(this IEnumerable<string> options)
        {
            return JoinEm(options, ",", "");
        }

        public static string JoinEm(this IEnumerable<string> options, string separator, string lastItemSeparator)
        {
            var joinedString = string.Empty;

            if (options != null)
            {
                var list = options.ToList();

                if (list.Count > 1 && lastItemSeparator.IsNotEmpty())
                {
                    var lastItem = list.Last();
                    list.Remove(list.Last());
                    joinedString = string.Join(separator, list) + $" {lastItemSeparator} " + lastItem;
                }
                else
                {
                    joinedString = string.Join(separator, list.ToArray());
                }
            }

            return joinedString;
        }

        public static string RemoveAccent(this string txt)
        {
            var bytes = Encoding.GetEncoding("Cyrillic").GetBytes(txt);
            return Encoding.ASCII.GetString(bytes);
        }

        public static string RemoveSpecialCharacters(this string value)
        {
            var regex = new Regex(@"[^a-zA-Z0-9]",
                RegexOptions.IgnoreCase | RegexOptions.CultureInvariant | RegexOptions.Compiled);
            return regex.Replace(value, string.Empty);
        }

        public static long ToInt64(this string item)
        {
            long id = 0;
            long.TryParse(item, out id);
            return id;
        }

        public static bool IsALetter(this string value)
        {
            char charValue;
            return char.TryParse(value, out charValue) && char.IsLetter(charValue);
        }

        public static string ToUrlSlug(this string phrase)
        {
            return UrlSlugger.ToUrlSlug(phrase);
        }

        [DebuggerStepThrough]
        public static bool CaseInsensitiveContains(this string text, string value,
            StringComparison stringComparison = StringComparison.CurrentCultureIgnoreCase)
        {
            return text.IndexOf(value, stringComparison) >= 0;
        }
        [DebuggerStepThrough]
        public static string AttributeEncode(this string target)
        {
            return HttpUtility.HtmlAttributeEncode(target);
        }

        [DebuggerStepThrough]
        public static string FormatWith(this string target, params object[] args)
        {
            Check.Argument.IsNotEmpty(target, "target");
            return string.Format(CultureInfo.CurrentCulture, target, args);
        }

        public static string FormatWith(this string format, IFormatProvider provider, params object[] args)
        {
            if (format == null)
                throw new ArgumentNullException("format");
            return string.Format(provider, format, args);
        }

        [DebuggerStepThrough]
        public static string Hash(this string target)
        {
            Check.Argument.IsNotEmpty(target, "target");
            using (var md = MD5.Create())
            {
                var bytes = Encoding.Unicode.GetBytes(target);
                return Convert.ToBase64String(md.ComputeHash(bytes));
            }
        }

        [DebuggerStepThrough]
        public static string HtmlDecode(this string target)
        {
            return HttpUtility.HtmlDecode(target);
        }

        [DebuggerStepThrough]
        public static string HtmlEncode(this string target)
        {
            return HttpUtility.HtmlEncode(target);
        }

        [DebuggerStepThrough]
        public static bool IsEmail(this string target)
        {
            return !string.IsNullOrEmpty(target) && EmailExpression.IsMatch(target);
        }

        [DebuggerStepThrough]
        public static bool IsGuid(this string target)
        {
            return !string.IsNullOrEmpty(target) && GuidExpression.IsMatch(target);
        }

        [DebuggerStepThrough]
        public static bool IsWebUrl(this string target)
        {
            return !string.IsNullOrEmpty(target) && WebUrlExpression.IsMatch(target);
        }

        [DebuggerStepThrough]
        public static bool LowerInvariantEquals(this string value, string toCompareWith)
        {
            return value.ToLowerInvariant().Equals(toCompareWith.ToLowerInvariant());
        }

        [DebuggerStepThrough]
        public static string NullSafe(this string target)
        {
            return (target ?? string.Empty).Trim();
        }

        public static string Replace(this string target, ICollection<string> oldValues, string newValue)
        {
            oldValues.ForEach<string>(delegate (string oldValue) { target = target.Replace(oldValue, newValue); });
            return target;
        }

        [DebuggerStepThrough]
        public static string StripHtml(this string target)
        {
            return StripHTMLExpression.Replace(target, string.Empty);
        }

        [DebuggerStepThrough]
        public static T ToEnum<T>(this string target, T defaultValue) where T : IComparable, IFormattable
        {
            var local = defaultValue;
            if (target.IsNotEmpty())
                try
                {
                    local = (T)Enum.Parse(typeof(T), target.Trim(), true);
                }
                catch (ArgumentException)
                {
                }
            return local;
        }

        [DebuggerStepThrough]
        public static Guid ToGuid(this string target)
        {
            var empty = Guid.Empty;
            if (target.IsNotEmpty() && target.Trim().Length == 0x16)
            {
                var s = target.Trim().Replace("-", "+").Replace("_", "/") + "==";
                try
                {
                    empty = new Guid(Convert.FromBase64String(s));
                }
                catch (FormatException)
                {
                }
            }
            return empty;
        }

        [DebuggerStepThrough]
        public static string ToLegalUrl(this string target)
        {
            if (target.IsNotEmpty())
            {
                target = target.Trim();
                if (target.IndexOfAny(IllegalUrlCharacters) > -1)
                    foreach (var ch in IllegalUrlCharacters)
                        target = target.Replace(ch.ToString(CultureInfo.CurrentCulture), string.Empty);
                target = target.Replace(" ", "-");
                while (target.Contains("--"))
                    target = target.Replace("--", "-");
            }
            return target;
        }

        [DebuggerStepThrough]
        public static string UrlDecode(this string target)
        {
            return HttpUtility.UrlDecode(target);
        }

        [DebuggerStepThrough]
        public static string UrlEncode(this string target)
        {
            return HttpUtility.UrlEncode(target);
        }

        [DebuggerStepThrough]
        public static string WrapAt(this string target, int index)
        {
            Check.Argument.IsNotEmpty(target, "target");
            Check.Argument.IsNotNegativeOrZero(index, "index");
            return target.Length <= index ? target : target.Substring(0, index - 3) + new string('.', 3);
        }

        [DebuggerStepThrough]
        public static string ToTitleCase(this string value)
        {
            return new CultureInfo("en-US", false).TextInfo.ToTitleCase(value);
        }
    }
}
