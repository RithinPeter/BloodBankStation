using BloodBankStation.GlobalValues;
using BloodBankStation.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BloodBankStation
{
    public partial class Details : System.Web.UI.Page
    {
        private static readonly HttpClient client = new HttpClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Check if the ID is provided in the query string
                if (Request.QueryString["id"] != null)
                {
                    int id;
                    if (int.TryParse(Request.QueryString["id"], out id))
                    {
                        // Fetch data based on the ID and populate the details
                        PopulateDetails(id);
                    }
                }
            }
        }

        private async void PopulateDetails(int id)
        {
            var additionalDetails = await GetDataAsync(id);


            lblCity.InnerText = additionalDetails.City;
            lblAddress.InnerText = additionalDetails.Address;
            lblContact.InnerText = additionalDetails.Phone;
            lblSunday.InnerText = additionalDetails.Sunday;
            lblMonday.InnerText = additionalDetails.Monday;
            lblTuesday.InnerText = additionalDetails.Tuesday;
            lblWednesday.InnerText = additionalDetails.Wednesday;
            lblThursday.InnerText = additionalDetails.Thursday;
            lblFriday.InnerText = additionalDetails.Friday;
            lblSaturday.InnerText = additionalDetails.Saturday; 
        }


        private async Task<ClinicLocations> GetDataAsync(int id)
        {
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Add("User-Key", GlobalData.APIKey);

            string apiUrl = ConfigurationManager.AppSettings["ApiBaseUrl"] + $"api/ClinicLocations?id={id}";
            var response = await client.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                try
                {
                    var clinicLocations = JsonConvert.DeserializeObject<ClinicLocations>(responseContent);
                    return clinicLocations;
                }
                catch (JsonSerializationException)
                {
                    var clinicLocationsArray = JsonConvert.DeserializeObject<List<ClinicLocations>>(responseContent);
                    if (clinicLocationsArray != null && clinicLocationsArray.Count > 0)
                    {
                        return clinicLocationsArray[0];
                    }
                }
            }
            return null;
        }
    }
}