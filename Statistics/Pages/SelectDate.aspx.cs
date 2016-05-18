using Statistics.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Статистика.Classes;

namespace Statistics.Pages
{
    public partial class SelectDate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private void AddTable(string rapportadStartDatum,string rapportadSlutDatum)
        {            
            SQLController sqlController = new SQLController();
            var table = sqlController.GetTable(Query.GetQuery(rapportadStartDatum, rapportadStartDatum, (int)Query.personalTypes.worker));
            this.Page.Controls.Add(HtmlTable.CreateTable(table));
        }

        protected void showTableBtn_Click(object sender, EventArgs e)
        {
            AddTable(rapportadStartTextBox.Text, rapportadSlutTextBox.Text);
        }

    }
}