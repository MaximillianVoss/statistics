using Statistics.Classes;
using System;

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
            //var table = sqlController.GetTable(Query.GetQuery(rapportadStartDatum, rapportadStartDatum, (int)Query.personalTypes.worker));
            var table = sqlController.GetDataTable(Query.GetQuery(rapportadStartDatum, rapportadSlutDatum, (int)Query.personalTypes.type2));
            Calculate.AddCalculateColumns(table);
            this.Page.Controls.Add(HtmlTable.CreateTable(table.Rows));
        }

        protected void showTableBtn_Click(object sender, EventArgs e)
        {
            //Calculate.DateTimeToStr("07:00", "2011-01-01");
            AddTable(rapportadStartTextBox.Text, rapportadSlutTextBox.Text);
        }

    }
}