using System;
using System.Web.UI;
using System.Web.UI.WebControls;
// Include any other namespaces needed for your data access

namespace BloodBankStation
{
    public partial class Search : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Initial page load logic here
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string location = txtLocation.Text;
            // Implement your search logic here
            // For example, query a database or API to find nearby blood banks

            // Bind the results to gvBloodBanks
            // gvBloodBanks.DataSource = yourDataSource;
            // gvBloodBanks.DataBind();
        }
        protected void btnLogout_Click(object sender, EventArgs e)
        {
            // Implement your logout logic here
            // This could involve clearing session data, etc.

            Response.Redirect("Default.aspx");  
        }
        protected void btnAddLocation_Click( object sender, EventArgs e)
        {
            Response.Redirect("AddLocation.aspx");
        }

    }

}
