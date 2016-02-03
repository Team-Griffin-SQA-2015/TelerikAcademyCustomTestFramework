namespace QA.TestingFramework.Core.Providers
{
    #region using directives

    using System.Threading;

    #endregion

    public static class ExecutionDelayProvider
    {
        public static void SleepFor(int milliseconds)
        {
            Thread.Sleep(milliseconds);
        }
    }
}