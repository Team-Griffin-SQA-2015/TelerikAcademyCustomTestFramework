namespace QA.TestingFramework.Core.Extensions
{
    #region using directives

    using System.Collections.Generic;
    using System.Linq;

    using ArtOfTest.WebAii.Controls.HtmlControls;

    using Telerik.TestingFramework.Controls.KendoUI;

    #endregion

    public static class KendoGridExtensions
    {
        public static IList<string> GetGridElementsFromColumnAsString(this KendoGrid grid, int columnIndex)
        {
            var columnElements = grid.DataItems.Select(r => r.Cells[columnIndex].InnerText).ToList();
            return columnElements;
        }

        public static IList<string> GetGridElementsFromRowAsString(this KendoGrid grid, int rowIndex)
        {
            var columnElements = grid.DataItems[rowIndex].Cells.Select(c => c.InnerText).ToList();
            return columnElements;
        }

        public static IList<HtmlTableCell> GetGridElementsFromRow(this KendoGrid grid, int rowIndex)
        {
            var columnElements = grid.DataItems[rowIndex].Cells.ToList();
            return columnElements;
        }

        public static bool GridContainsText(this KendoGrid grid, string text)
        {
            var isTextContained =
                grid.DataItems.Any(
                    cell => cell.Cells.Any(node => node.ChildNodes.Any(current => current.InnerText.Contains(text))));
            return isTextContained;
        }

        public static int IndexOfGridRowContainingText(this KendoGrid grid, string text)
        {
            var row = grid.DataItems.FirstOrDefault(r => r.Cells.Any(c => c.InnerText == text)).ItemIndex;

            return row;
        }

        public static string GetCellContentAsString(this KendoGrid grid, int cellRow, int cellCol)
        {
            var stringContent = grid.DataItems[cellRow].Cells[cellCol].InnerText;

            return stringContent;
        }
    }
}