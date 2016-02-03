namespace QA.UI.TestingFramework.Core.Extensions
{
    public static class HtmlElementExpressionExtensions
    {
        public static string IdEqualTo(this string expression)
        {
            return string.Concat("id=", expression);
        }

        public static string IdEndingWith(this string expression)
        {
            return string.Concat("id=?", expression);
        }

        public static string IdContaining(this string expression)
        {
            return string.Concat("id=~", expression);
        }

        public static string XpathEqualTo(this string expression)
        {
            return string.Concat("xpath=", expression);
        }

        public static string ForEndingWith(this string expression)
        {
            return string.Concat("for=?", expression);
        }

        public static string NameContaining(this string expression)
        {
            return string.Concat("name=~", expression);
        }

        public static string NameEndingWith(this string expression)
        {
            return string.Concat("name=?", expression);
        }

        public static string ClassEqualTo(this string expression)
        {
            return string.Concat("class=", expression);
        }

        public static string ClassEndingWith(this string expression)
        {
            return string.Concat("class=?", expression);
        }

        public static string InnerTextContaining(this string expression)
        {
            return string.Concat("InnerText=~", expression);
        }

        public static string HrefEqualTo(this string expression)
        {
            return string.Concat("href=", expression);
        }

        public static string HrefContaining(this string expression)
        {
            return string.Concat("href=~", expression);
        }

        public static string ValueEqualTo(this string expression)
        {
            return string.Concat("value=", expression);
        }

        public static string NameEqualTo(this string expression)
        {
            return string.Concat("name=", expression);
        }

        public static string PlaceholderEqualTo(this string expression)
        {
            return string.Concat("placeholder=", expression);
        }
    }
}