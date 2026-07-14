using Statistics.Classes;
using Statistics.Classes.Tabels;
using Statistics.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Statistics.Pages
{
    public partial class Table : System.Web.UI.Page
    {
        #region Methods
        private void AddTable(string startDatum, string slutDatum)
        {
            Tjansteman tjanstemanTabel = new Tjansteman("Tjansteman", (int)Common.Enums.personalTypes.type2,
               Common.ColumnNames.columnNamesPersonal, Common.ColumnNames.statistikTabelColumnNames,
               startDatum, slutDatum, Common.ColumnNames.columnsToAdd,true);
            Arbetare arbetareTabel = new Arbetare("Arbetare", (int)Common.Enums.personalTypes.type1, 
                Common.ColumnNames.columnNamesPersonal, Common.ColumnNames.statistikTabelColumnNames, 
                startDatum, slutDatum, Common.ColumnNames.columnsToAdd,false);         
            Internt interntTabel = new Internt("Internt", (int)Common.Enums.personalTypes.type3,
                Common.ColumnNames.columnNamesPersonal, Common.ColumnNames.statistikTabelColumnNames,
                startDatum, slutDatum, Common.ColumnNames.columnsToAdd,false);
            Underkonsult underconsultTabel = new Underkonsult("Underkonsult", (int)Common.Enums.personalTypes.type4,
                Common.ColumnNames.columnNamesPersonal, Common.ColumnNames.statistikTabelColumnNames,
                startDatum, slutDatum, Common.ColumnNames.columnsToAdd,false);

            this.Page.Controls.Add(HtmlTable.CreateStatisticTable
                (tjanstemanTabel.statistikTabel, arbetareTabel.statistikTabel,
                interntTabel.statistikTabel,underconsultTabel.statistikTabel));
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            AddTable(Request.QueryString["from"].ToString(), Request.QueryString["to"].ToString());
        }

        protected void back_Click(object sender, EventArgs e)
        {
            Response.Redirect("SelectDate.aspx");
        }
    }
}