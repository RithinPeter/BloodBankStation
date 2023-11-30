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
using System.Linq;

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
            gvBloodBanks.DataKeyNames = new string[] { "Id" };
            gvBloodBanks.DataBind();
        }

        private async Task<List<ClinicLocations>> GetDataAsync()
        {
            client.DefaultRequestHeaders.Clear();
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

        protected async void btnSearch_Click(object sender, EventArgs e)
        {
            Page.RegisterAsyncTask(new PageAsyncTask(async () =>
            {
                string location = txtLocation.Text;
                var data = await GetDataAsync();

                if (data != null)
                {
                    gvBloodBanks.DataSource = new List<ClinicLocations>();
                    if (!string.IsNullOrEmpty(location))
                    {
                        data = data.Where(d => d.City.ToLower().Contains(location.ToLower())).ToList();
                    }

                    data = data.OrderBy(d => d.Address).ToList();
                    gvBloodBanks.DataSource = data;
                    gvBloodBanks.DataKeyNames = new string[] { "Id" };
                    gvBloodBanks.DataBind();
                }
            }));
        }

        private async void SearchValues( string location)
        {
            var data = await GetDataAsync();

            if (data != null)
            {
                gvBloodBanks.DataSource = new List<ClinicLocations>();
                if (!string.IsNullOrEmpty(location))
                {
                    data = data.Where(d => d.City.ToLower().Contains(location.ToLower())).ToList();
                }

                data = data.OrderBy(d => d.Address).ToList();
                gvBloodBanks.DataSource = data;
                gvBloodBanks.DataBind();
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");  
        }
        protected void btnProfile_Click( object sender, EventArgs e)
        {
            Response.Redirect("Profile.aspx");
        }
        protected void btnDetails_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            GridViewRow row = (GridViewRow)btn.NamingContainer;

            // Fetching the index passed as CommandArgument
            int rowIndex = Convert.ToInt32(btn.CommandArgument);

            // Accessing the ID value from DataKeys collection using the row index
            int id = Convert.ToInt32(gvBloodBanks.DataKeys[rowIndex].Value);

            // Redirect to details page with the ID as a query string
            Response.Redirect("Details.aspx?id=" + id);
        }

    }

}
