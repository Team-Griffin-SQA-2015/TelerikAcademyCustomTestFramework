namespace QA.TelerikAcademy.Core.Facades
{
    #region using directives

    using System.Collections.Generic;

    using ArtOfTest.WebAii.Controls.HtmlControls;
    using ArtOfTest.WebAii.Core;

    using Newtonsoft.Json;

    #endregion

    public class KendoGrid
    {
        private readonly Browser browser;
        private readonly string gridId;

        public KendoGrid(Browser browser, HtmlDiv gridContainer)
        {
            this.gridId = gridContainer.ID;
            this.browser = browser;
        }

        public void Clear()
        {
#pragma warning disable 219
            var emptyDataSource = "var emptyDataSource = new kendo.data.DataSource({data:[]});";
#pragma warning restore 219
            var clearCommand = "grid.dataSource.data([])";

            var javaScriptExecutable = this.InitializeGrid();
            javaScriptExecutable = string.Concat(javaScriptExecutable, clearCommand);

            this.browser.Actions.InvokeScript(javaScriptExecutable);
        }

        public List<T> GetGridContents<T>() where T : class
        {
            var jsExecutable = this.InitializeGrid();
            jsExecutable = string.Concat(jsExecutable, "return JSON.stringify(grid.dataSource.data();");
            var itemsAsJson = this.browser.Actions.InvokeScript(jsExecutable);
            var items = JsonConvert.DeserializeObject<List<T>>(itemsAsJson);

            return items;
        }

        private string InitializeGrid()
        {
            var initializeKendoGrid = $"var grid = $('#{this.gridId}').data('kendoGrid');";
            return initializeKendoGrid;
        }
    }
}