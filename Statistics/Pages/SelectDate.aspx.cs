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
            var table = sqlController.GetDataTable(Query.GetPersonalQuery(rapportadStartDatum, rapportadSlutDatum, (int)Common.personalTypes.type2,Common.columnNamesPersonal));
            Calculate.AddCalculateColumns(table,Common.columnsToAdd);
            //var table = sqlController.GetDataTable(Query.GetErastingsQuery(rapportadStartDatum, rapportadSlutDatum, (int)Common.ersattningsTypes.type1, Common.columnNamesErsattnings));
            //this.Page.Controls.Add(HtmlTable.CreateTable(table.Rows));
            this.Page.Controls.Add(HtmlTable.CreateStatisticTable(Common.statistikTabel));
        }

        protected void showTableBtn_Click(object sender, EventArgs e)
        {
            //Calculate.DateTimeToStr("07:00", "2011-01-01");
            AddTable(rapportadStartTextBox.Text, rapportadSlutTextBox.Text);
        }

    }
}