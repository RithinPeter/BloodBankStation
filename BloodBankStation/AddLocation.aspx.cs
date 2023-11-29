using System;
using System.Web.UI;

namespace BloodBankStation
{
    public partial class AddLocation : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Initialization code, if any
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            // Get values from the form
            string cityValue = city.Text;
            string addressValue = address.Text;
            string phoneValue = phone.Text;

            // Manually entered times for each day
            string mondayTimes = monday.Text;
            string tuesdayTimes = tuesday.Text;
            string wednesdayTimes = wednesday.Text;
            string thursdayTimes = thursday.Text;
            string fridayTimes = friday.Text;
            string saturdayTimes = saturday.Text;
            string sundayTimes = sunday.Text;

            // TODO: Validate the input (e.g., check for empty fields, validate time formats)

            // TODO: Process the data (e.g., store in a database)
            // This would typically involve creating a new record in your data store with the provided information

            // Redirect to another page or display a success message upon successful data processing
            // For example:
            // Response.Redirect("SuccessPage.aspx");
            // Or display a message on the current page
        }
    }
}
