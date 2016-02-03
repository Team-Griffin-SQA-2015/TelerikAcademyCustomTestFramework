namespace QA.Utilities.RandomGenerators
{
    #region using directives

    using System;
    using System.Linq;

    #endregion

    public static class RandomStringGenerator
    {
        public static string Generate(int length)
        {
            const string Chars = "AaBbCcDdEeFfGgHhIiJjKkLlMmNnOoPpQqRrSsTtUuVvWwXxYyZz";
            var random = new Random();
            return new string(Enumerable.Repeat(Chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}