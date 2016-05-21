using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI;

namespace Statistics.Classes
{
    public static class HtmlTable
    {
        public static Control CreateTable(DataRowCollection dataTable)
        {
            HtmlControlCreator creator = new HtmlControlCreator();
            List<string> columnNames = new List<string>();
            var table = creator.CreateHtmlControl(string.Empty,"table","table");
            var header = creator.CreateHtmlControl(string.Empty, "tr", string.Empty);
            if (dataTable.Count > 0)
            {
                foreach (DataColumn item in dataTable[0].Table.Columns)
                {
                    columnNames.Add(item.ColumnName);
                }

                foreach(var item in columnNames)
                {
                    header.Controls.Add(creator.CreateHtmlControl("th", item));
                }
                table.Controls.Add(header);
                foreach (DataRow item in dataTable)
                {
                    var row = creator.CreateHtmlControl("tr", string.Empty);
                    foreach (var columnName in columnNames)
                    {
                        row.Controls.Add(creator.CreateHtmlControl( "td", item[columnName].ToString()));
                    }
                    table.Controls.Add(row);
                }
             }
            else
            {
                table.Controls.Add(creator.CreateHtmlControl("div","No results"));
            }           
            return table;
        }
        public static Control CreateStatisticTable(Dictionary<string,string> values)
        {
            HtmlControlCreator creator = new HtmlControlCreator();
            var table = creator.CreateHtmlControl(string.Empty, "table", "table");
            var header = creator.CreateHtmlControl(string.Empty, "tr", string.Empty);
            header.Controls.Add(creator.CreateHtmlControl("th", "Statistik"));
            table.Controls.Add(header);
            foreach(var item in values)
            {
                if(String.IsNullOrEmpty(item.Value))
                {
                    var row = creator.CreateHtmlControl(string.Empty, "tr", "warning");
                    var nameCell = creator.CreateHtmlControl("td", item.Key);
                    row.Controls.Add(nameCell);
                    table.Controls.Add(row);
                }
                else
                {
                    var row = creator.CreateHtmlControl(string.Empty, "tr", "info");
                    var nameCell = creator.CreateHtmlControl( "td", item.Key);
                    var valueCell = creator.CreateHtmlControl( "td", item.Value);
                    row.Controls.Add(nameCell);
                    row.Controls.Add(valueCell);
                    table.Controls.Add(row);
                }               
            }
            return table;
        }
    }
}