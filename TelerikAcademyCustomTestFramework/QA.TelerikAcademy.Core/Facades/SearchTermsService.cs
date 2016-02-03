namespace QA.TelerikAcademy.Core.Facades
{
    #region using directives

    using System.Windows.Forms;

    using ArtOfTest.WebAii.Core;

    using Pages.LoginPage;
    using Pages.SearchTermsPage;

    using TestingFramework.Core.Data;
    using TestingFramework.Core.Extensions;
    using TestingFramework.Core.Providers;

    #endregion

    public class SearchTermsService
    {
        public SearchTermsService()
        {
            this.LoginPage = new LoginPage();
            this.SearchTermsPage = new SearchTermsPage();
        }

        public LoginPage LoginPage { get; set; }

        public SearchTermsPage SearchTermsPage { get; set; }

        public void AddSearchTerm(SearchTerm searchTerm)
        {
            this.SearchTermsPage.Map.AddItemButton.Click();
            this.SearchTermsPage.Map.Word.MouseClick();
            Manager.Current.ActiveBrowser.Desktop.KeyBoard.TypeText(searchTerm.Word);
            this.SearchTermsPage.Map.Count.MouseClick();
            Manager.Current.ActiveBrowser.Desktop.KeyBoard.KeyPress(Keys.Back);
            Manager.Current.ActiveBrowser.Desktop.KeyBoard.TypeText(searchTerm.Count);
            this.SearchTermsPage.Map.UpdateItemButton.MouseClick();
            Manager.Current.ActiveBrowser.RefreshDomTree();
            ExecutionDelayProvider.SleepFor(2000);
        }

        public void EditSearchTerm(SearchTerm searchTermToEdit, SearchTerm editingSearchTerm)
        {
            var rowIndexOfItemToEdit =
                this.SearchTermsPage.Map.KendoGrid.IndexOfGridRowContainingText(searchTermToEdit.Word);
            this.SearchTermsPage.Map.AllEditEntryButtons[rowIndexOfItemToEdit].MouseClick();
            this.SearchTermsPage.Map.EditEntryButton.MouseClick();
            Manager.Current.ActiveBrowser.RefreshDomTree();
            ExecutionDelayProvider.SleepFor(2000);
            this.SearchTermsPage.Map.Word.MouseClick(MouseClickType.LeftDoubleClick);
            Manager.Current.ActiveBrowser.Desktop.KeyBoard.KeyPress(Keys.Back);
            Manager.Current.ActiveBrowser.Desktop.KeyBoard.TypeText(editingSearchTerm.Word);
            this.SearchTermsPage.Map.Count.MouseClick(MouseClickType.LeftDoubleClick);
            Manager.Current.ActiveBrowser.Desktop.KeyBoard.KeyPress(Keys.Back);
            Manager.Current.ActiveBrowser.Desktop.KeyBoard.TypeText(editingSearchTerm.Count);
            this.SearchTermsPage.Map.UpdateItemButton.MouseClick();
            Manager.Current.ActiveBrowser.RefreshDomTree();
            ExecutionDelayProvider.SleepFor(2000);
        }

        public void RemoveSearchTerm(SearchTerm searchTerm)
        {
            var rowToDelete = this.SearchTermsPage.Map.SearchTermsGrid.IndexOfGridRowContainingText(searchTerm.Word);
            this.SearchTermsPage.Map.AllDeleteEntryButtons[rowToDelete].MouseClick();
            ExecutionDelayProvider.SleepFor(2000);
            Manager.Current.Desktop.KeyBoard.KeyPress(Keys.Enter);
        }
    }
}