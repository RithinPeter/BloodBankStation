using Newtonsoft.Json;
using System;
using System.Configuration;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;

namespace BloodBankStation
{
    public partial class Register : Page
    {
        private static readonly HttpClient client = new HttpClient();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected async void btnRegister_Click(object sender, EventArgs e)
        {
            // Retrieve user input from form controls
            string firstName = txtFirstName.Text;
            string lastName = txtLastName.Text;
            string email = txtEmail.Text;
            string password = txtPassword.Text;

            bool isSuccess = await RegisterUserAsync(firstName, lastName, email, password);

            if (isSuccess)
            {
                Response.Redirect("Login.aspx");
            }
        }

        private async Task<bool> RegisterUserAsync(string firstName, string lastName, string email, string password)
        {
            var user = new
            {
                FirstName = firstName,
                LastName = lastName,
                Username = email,
                Password = password
            };

            var json = JsonConvert.SerializeObject(user);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var apiUrl = ConfigurationManager.AppSettings["ApiBaseUrl"] + "api/Users/register"; 
            var response = await client.PostAsync(apiUrl, data);

            if(response.StatusCode== HttpStatusCode.OK)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}