namespace QA.UI.TestingFramework.Core.Extensions
{
    using System;
    using System.Threading;

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