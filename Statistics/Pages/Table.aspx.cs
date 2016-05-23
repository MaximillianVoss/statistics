using Statistics.Classes;
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
            var tabel = SQLController.GetDataTable(Query.GetPersonalQuery(startDatum, slutDatum, (int)Common.personalTypes.type2, Common.columnNamesPersonal));
            Calculate.AddCalculateColumns(tabel, Common.columnsToAdd);
            Calculate.GetErastingValues(startDatum, slutDatum);
            this.Page.Controls.Add(HtmlTable.CreateStatisticTable(Common.statistikTabel));
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