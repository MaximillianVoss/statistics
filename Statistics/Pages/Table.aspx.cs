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
        private void AddTable(string rapportadStartDatum, string rapportadSlutDatum)
        {
            var table = SQLController.GetDataTable(Query.GetPersonalQuery(rapportadStartDatum, rapportadSlutDatum, (int)Common.personalTypes.type2, Common.columnNamesPersonal));
            Calculate.AddCalculateColumns(table, Common.columnsToAdd);
            this.Page.Controls.Add(HtmlTable.CreateStatisticTable(Common.statistikTabel));
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            AddTable(Request.QueryString["from"].ToString(), Request.QueryString["to"].ToString());
        }
    }
}