﻿namespace QA.TelerikAcademy.Core.Pages.EventsPage
{
    #region using directives

    using ArtOfTest.Common.UnitTesting;
    using ArtOfTest.WebAii.Core;

    using Constants.Pages;

    using TestingFramework.Core.Extensions;

    #endregion

    public class EventsPageValidator
    {
        public EventsPageMap Map => new EventsPageMap();

        public void ValidatePageTitle()
        {
            Assert.AreEqual(EventsConstants.PageTitle, Manager.Current.ActiveBrowser.PageTitle);
        }

        public void ValidateAddPopUpAppeared()
        {
            this.Map.Description.AssertIsPresent();
        }
    }
}