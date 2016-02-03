namespace QA.TelerikAcademy.Core.Constants.Attributes
{
    #region using directives

    using System;

    #endregion

    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class TestCaseId : Attribute
    {
        private int id;

        public TestCaseId(int id)
        {
            this.id = id;
        }
    }
}