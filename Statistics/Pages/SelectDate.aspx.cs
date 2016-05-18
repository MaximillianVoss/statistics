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

        private void AddTable(string rapportadStart)
        {            
            SQLController sqlController = new SQLController();
            var table = sqlController.GetTable(Query.GetQuery(new DateTime(2005,1,1).ToString("yyyy-MM-dd"), rapportadStart,((int)Query.personalTypes.worker).ToString()));
            this.Page.Controls.Add(HtmlTable.CreateTable(table));
        }

        protected void showTableBtn_Click(object sender, EventArgs e)
        {
            AddTable(rapportadStartTextBox.Text);
        }

    }
}