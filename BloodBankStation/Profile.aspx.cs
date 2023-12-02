using BloodBankStation.Extension;
using BloodBankStation.GlobalValues;
using BloodBankStation.Models;
using Microsoft.AspNetCore.JsonPatch;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.UI;

namespace BloodBankStation
{
    public partial class Profile : Page
    {
        private static readonly HttpClient client = new HttpClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetUserdata();
            }
        }

        /// <summary>
        /// Populate data when loading the page
        /// </summary>
        private async void GetUserdata()
        {
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Add("User-Key", GlobalData.APIKey);

            string apiUrl = ConfigurationManager.AppSettings["ApiBaseUrl"] + $"api/Users/{GlobalData.userId}";
            var response = await client.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                try
                {
                    var user = JsonConvert.DeserializeObject<User>(responseContent);

                    firstName.Text = user.FirstName;
                    lastName.Text = user.LastName;
                    username.Text = user.Username;
                    password.Text = user.Password;
                    userId.Value = user.Id.ToString();

                }
                catch (JsonSerializationException)
                {
                    var userArray = JsonConvert.DeserializeObject<List<User>>(responseContent);
                    if (userArray != null && userArray.Count > 0)
                    {
                        firstName.Text = userArray[0].FirstName;
                        lastName.Text = userArray[0].LastName;
                        username.Text = userArray[0].Username;
                        password.Text = userArray[0].Password;
                        userId.Value = userArray[0].Id.ToString();
                    }
                }
            }
        }

        /// <summary>
        /// Update profile button event handler 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected async void UpdateProfile_Click(object sender, EventArgs e)
        {
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Add("User-Key", GlobalData.APIKey);

            string apiUrl = ConfigurationManager.AppSettings["ApiBaseUrl"] + $"api/Users/{GlobalData.userId}";
            var response = await client.GetAsync(apiUrl);
            var responseContent = await response.Content.ReadAsStringAsync();
            var existingUser = JsonConvert.DeserializeObject<User>(responseContent);

            // Create User object from form fields
            User user = CreateUserFromForm();

            if (DetermineUpdateType(user, existingUser))
            {
                // PATCH request
                await SendPatchRequest(user);
            }
            else
            {
                // PUT request
                await SendPutRequest(user);
            }
        }
        
        /// <summary>
        /// Generate object from FORM fields
        /// </summary>
        /// <returns></returns>
        private User CreateUserFromForm()
        {
            // Populate a User object from the form fields
            return new User
            {
                Id = Convert.ToInt32(userId.Value),
                FirstName = firstName.Text,
                LastName = lastName.Text,
                Username = username.Text,
                Password = password.Text,
                ApiKey = GlobalData.APIKey
            };
        }

        /// <summary>
        /// See if this is a patch or put request based on the changes in the fields.
        /// </summary>
        /// <param name="user"></param>
        /// <param name="existingUser"></param>
        /// <returns></returns>
        private bool DetermineUpdateType(User user, User existingUser)
        {
            if (user.FirstName != existingUser.FirstName && 
                user.LastName != existingUser.LastName &&
                user.Username != existingUser.Username &&
                user.Password != existingUser.Password
                )
            {
                return false; // Full update (PUT)
            }
            else
            {
                return true; // Partial update (PATCH)
            }
        }

        /// <summary>
        /// Put request 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        private async Task SendPutRequest(User user)
        {
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Add("User-Key", GlobalData.APIKey);

            string json = JsonConvert.SerializeObject(user);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            string apiUrl = ConfigurationManager.AppSettings["ApiBaseUrl"] + $"api/Users/{user.Id}";

            var response = await client.PutAsync(apiUrl, content);

            // Alert message
        }

        /// <summary>
        /// patch request
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        private async Task SendPatchRequest(User user)
        {
            // Create a JsonPatchDocument 
            var patchDoc = new JsonPatchDocument<User>();

            // Compare the user object with the existing user data
            if (user.FirstName != null)
            {
                patchDoc.Replace(x => x.FirstName, user.FirstName);
            }

            if (user.LastName != null)
            {
                patchDoc.Replace(x => x.LastName, user.LastName);
            }

            if (user.Username != null)
            {
                patchDoc.Replace(x => x.Username, user.Username);
            }

            if (user.Password != null)
            {
                patchDoc.Replace(x => x.Password, user.Password);
            }

            // Serialize the JsonPatchDocument to JSON
            var json = JsonConvert.SerializeObject(patchDoc);
            var content = new StringContent(json, Encoding.UTF8, "application/json-patch+json");

            string apiUrl = ConfigurationManager.AppSettings["ApiBaseUrl"] + $"api/Users/{user.Id}";
            var response = await Extensions.PatchAsync(client, apiUrl, content);

            if (response.IsSuccessStatusCode)
            {
                // success
            }
            else
            {
                // error
            }
        }

        public void DeleteProfile_Click(object sender, EventArgs e)
        {

        }
    }
}


