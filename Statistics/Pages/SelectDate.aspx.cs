using Statistics.Classes;
using System;

namespace Statistics.Pages
{
    public partial class SelectDate : System.Web.UI.Page
    {
        #region Events
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void showTableBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect(String.Format("Table.aspx?from={0}&to={1}", rapportadStartTextBox.Text, rapportadSlutTextBox.Text));
            //AddTable(rapportadStartTextBox.Text, rapportadSlutTextBox.Text);
        }
        #endregion
    }
}