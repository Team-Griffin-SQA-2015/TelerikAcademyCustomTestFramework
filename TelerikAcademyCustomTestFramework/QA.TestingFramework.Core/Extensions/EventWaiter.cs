namespace QA.TestingFramework.Core.Extensions
{
    #region using directives

    using System;
    using System.Threading;

    #endregion

    public static class EventWaiter
    {
        public static void WaitForEvent(Func<bool> predicate, int timeOut)
        {
            var start = DateTime.Now;
            while (true)
            {
                if (predicate())
                {
                    break;
                }

                if ((DateTime.Now - start).TotalSeconds > timeOut)
                {
                    throw new Exception("Timed out waiting for condition!");
                }

                Thread.Sleep(100);
            }
        }
    }
}