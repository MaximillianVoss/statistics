using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI;

namespace Statistics.Classes
{
    public static class HtmlTable
    {
        private static String AddUnis(String columnsName,String value)
        {
            if (Common.Units.statistikTabelColumnUnits.ContainsKey(columnsName))
                return String.Format("{0} {1}", value, Common.Units.statistikTabelColumnUnits[columnsName]);
            else
                return value;
        }
        /// <summary>
        /// Create two cells that contians key and value
        /// </summary>
        /// <param name="values">key and value</param>
        /// <returns>list of td tags</returns>
        private static List<Control> CreateCells(KeyValuePair<String, String> item,bool showColumnsNames)
        {
            List<Control> cells = new List<Control>();
            HtmlControlCreator creator = new HtmlControlCreator();
            if (String.IsNullOrEmpty(item.Value))
            {
                if(showColumnsNames)
                cells.Add(creator.CreateHtmlControl(String.Empty, "td", new Dictionary<String, String> { { "colspan", "2" },
                    { "style", "text-align:left;border-left: 1px solid #ddd;" } }, item.Key));
                else
                    cells.Add(creator.CreateHtmlControl(String.Empty, "td", new Dictionary<String, String> { { "colspan", "2" },
                    { "style", "text-align:left;border-left: 1px solid #ddd;" } }, String.Empty));
            }
            else
            {
                if (showColumnsNames)
                {
                    cells.Add(creator.CreateHtmlControl(String.Empty, "td", new Dictionary<String, String> {
                    {"style","text-align:left;border-left: 1px solid #ddd;" } }, item.Key));
                    cells.Add(creator.CreateHtmlControl(String.Empty, "td", new Dictionary<String, String> {
                    {"style","text-align:center;" } }, AddUnis(item.Key, item.Value)));
                }
                else
                {
                    cells.Add(creator.CreateHtmlControl(String.Empty, "td", new Dictionary<String, String> {
                        { "colspan", "2" },{"style","border-left: 1px solid #ddd;text-align:center;" } }, AddUnis(item.Key,item.Value)));
                }

                //cells.Add(creator.CreateHtmlControl("td", item.Key));
                //cells.Add(creator.CreateHtmlControl("td", item.Value));
            }
            return cells;
        }
        /// <summary>
        /// Creates row for specified cells
        /// </summary>
        /// <param name="cells">list of the cells</param>
        /// <returns></returns>
        private static Control CreateRow(List<Control> cells, String style)
        {
            HtmlControlCreator creator = new HtmlControlCreator();
            if (cells.Count > 0)
            {
                var row = creator.CreateHtmlControl(string.Empty, "tr", style);
                foreach (var cell in cells)
                    row.Controls.Add(cell);
                return row;
            }
            else
                return creator.CreateHtmlControl(string.Empty, "tr", "danger");
        }
        public static Control CreateTable(DataRowCollection dataTable)
        {
            HtmlControlCreator creator = new HtmlControlCreator();
            List<string> columnNames = new List<string>();
            var table = creator.CreateHtmlControl(string.Empty, "table", "table");
            var header = creator.CreateHtmlControl(string.Empty, "tr", string.Empty);
            if (dataTable.Count > 0)
            {
                foreach (DataColumn item in dataTable[0].Table.Columns)
                {
                    columnNames.Add(item.ColumnName);
                }

                foreach (var item in columnNames)
                {
                    header.Controls.Add(creator.CreateHtmlControl("th", item));
                }
                table.Controls.Add(header);
                foreach (DataRow item in dataTable)
                {
                    var row = creator.CreateHtmlControl("tr", string.Empty);
                    foreach (var columnName in columnNames)
                    {
                        row.Controls.Add(creator.CreateHtmlControl("td", item[columnName].ToString()));
                    }
                    table.Controls.Add(row);
                }
            }
            else
            {
                table.Controls.Add(creator.CreateHtmlControl("div", "No results"));
            }
            return table;
        }
        public static Control CreateStatisticTable(StatistikTabel tabel)
        {
            HtmlControlCreator creator = new HtmlControlCreator();
            var table = creator.CreateHtmlControl(string.Empty, "table", "table");
            var header = creator.CreateHtmlControl(string.Empty, "tr", string.Empty);
            header.Controls.Add(creator.CreateHtmlControl(String.Empty, "th", new Dictionary<String, String>() { { "colspan", "6" } }, "Statistik"));
            table.Controls.Add(header);
            foreach (var item in tabel.tabel)
            {
                if (String.IsNullOrEmpty(item.Value))
                {
                    var row = creator.CreateHtmlControl(string.Empty, "tr", "warning");
                    var nameCell = creator.CreateHtmlControl("td", item.Key);
                    row.Controls.Add(nameCell);
                    table.Controls.Add(row);
                }
                else
                {
                    var row = creator.CreateHtmlControl(string.Empty, "tr", "info");
                    var nameCell = creator.CreateHtmlControl("td", item.Key);
                    var valueCell = creator.CreateHtmlControl("td", item.Value);
                    row.Controls.Add(nameCell);
                    row.Controls.Add(valueCell);
                    table.Controls.Add(row);
                }
            }
            return table;
        }
        public static Control CreateStatisticTable(params StatistikTabel[] tabels)
        {
            HtmlControlCreator creator = new HtmlControlCreator();
            if (tabels.Length > 0)
            {
                var table = creator.CreateHtmlControl(string.Empty, "table", "table");
                var header = creator.CreateHtmlControl(string.Empty, "tr", string.Empty);
                header.Controls.Add(creator.CreateHtmlControl(String.Empty, "th",
                    new Dictionary<String, String>() {
                        { "colspan", (2 * tabels.Length).ToString() },
                        { "style", "text-align: center;" }},
                    "Statistik"));
                table.Controls.Add(header);

                header = creator.CreateHtmlControl(string.Empty, "tr", string.Empty);
                foreach (var tabel in tabels)
                {
                    header.Controls.Add(creator.CreateHtmlControl(String.Empty, "th",
                        new Dictionary<String, String>() { { "colspan", "2" }, { "style", "text-align: center;" } }, tabel.name));
                }
                table.Controls.Add(header);

                foreach (var columnName in Common.ColumnNames.statistikTabelColumnNames)
                {
                    List<Control> cells = new List<Control>();
                    foreach (var tabel in tabels)
                    {
                            if (tabel.tabel.ContainsKey(columnName))
                                cells.AddRange(CreateCells(new KeyValuePair<String, String>(columnName, tabel.tabel[columnName])
                                    , tabel.showColumns));
                            else
                                cells.AddRange(CreateCells(new KeyValuePair<String, String>(columnName, String.Empty)
                                    , tabel.showColumns));                        
                    }
                    if (Common.ColumnNames.statistikTabelHeaderColumns.Contains(columnName))
                        table.Controls.Add(CreateRow(cells, "warning"));
                    else
                        table.Controls.Add(CreateRow(cells, "info"));
                }
                return table;
            }
            else
            {
                return creator.CreateHtmlControl("td", "no tabel passed");
            }
        }
        public static void FromatTableValues(ref StatistikTabel tabel)
        {
            Dictionary<String, String> result = new Dictionary<string, string>();
            foreach (var item in tabel.tabel)
            {
                if (!String.IsNullOrEmpty(item.Value))
                {
                    result.Add(item.Key, Convert.ToDouble(item.Value).ToString("### ### ###.##"));
                }
                else
                {
                    result.Add(item.Key, String.Empty);
                }
            }
            tabel.tabel = result;
        }
    }
}