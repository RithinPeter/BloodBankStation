using BloodBankStation.GlobalValues;
using BloodBankStation.Models;
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
    public partial class Login : Page
    {
        private static readonly HttpClient client = new HttpClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            // Page load logic here
        }

        protected async void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            bool isSuccess = await LoginUserAsync(username, password);

            if (isSuccess)
            {
                Response.Redirect("Search.aspx"); 
            }
            else
            {
                ShowAlert("No user found.");
            }
        }

        private async Task<bool> LoginUserAsync(string username, string password)
        {
            var credentials = new
            {
                Username = username,
                Password = password
            };

            var json = JsonConvert.SerializeObject(credentials);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var apiUrl = ConfigurationManager.AppSettings["ApiBaseUrl"] + "api/Users/login";
            var response = await client.PostAsync(apiUrl, data);


            if (response.StatusCode == HttpStatusCode.OK)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                var loginResponse = JsonConvert.DeserializeObject<User>(responseContent);
                // Storing the API key 
                GlobalData.APIKey = loginResponse.ApiKey;
                GlobalData.userId = loginResponse.Id;

                return true;
            }
            else
            {
                return false; 
            }
        }

        private void ShowAlert(string message)
        {
            string script = $"alert('{message}');";
            ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", script, true);
        }
    }
}
