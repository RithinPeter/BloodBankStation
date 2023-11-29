using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BloodBankStation
{
    public partial class Register : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnRegister_Click(object sender, EventArgs e)
        {
            // Retrieve user input from form controls
            string firstName = txtFirstName.Text;
            string lastName = txtLastName.Text;
            string email = txtEmail.Text;
            string password = txtPassword.Text;
            string phoneNumber = txtPhone.Text;

            // Implement logic to register the user
            // This could involve validating the input, 
            // checking if the user already exists, 
            // saving the user data to a database, etc.

            // Redirect to a different page or show a message upon successful registration
        }

    }
}