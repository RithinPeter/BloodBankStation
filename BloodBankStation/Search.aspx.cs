using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using BloodBankStation.Models;
using System.Configuration;
using BloodBankStation.GlobalValues;
using System.Collections.Generic;

namespace BloodBankStation
{
    public partial class Search : Page
    {
        private static readonly HttpClient client = new HttpClient();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDataToGridView();
            }
        }

        private async void BindDataToGridView()
        {
            var data = await GetDataAsync(); 
            gvBloodBanks.DataSource = data;
            gvBloodBanks.DataBind();
        }

        private async Task<List<ClinicLocations>> GetDataAsync()
        {
            client.DefaultRequestHeaders.Add("User-Key", GlobalData.APIKey);

            string apiUrl = ConfigurationManager.AppSettings["ApiBaseUrl"] + "api/ClinicLocations"; 
            var response = await client.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                var clinicLocations = JsonConvert.DeserializeObject<List<ClinicLocations>>(responseContent);
                return clinicLocations;
            }
            else
            {
                return null;
            }
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
