using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CSCI2910Lab5
{
    internal class JokesAPI
    {
        private HttpClient client;

        public JokesAPI()
        {
            client = new HttpClient();
        }

        /// <summary>
        /// Returns a random joke as a string
        /// </summary>
        /// <returns>string</returns>
        public async Task<string> GetRandomJoke()
        {
            var apiResponse = await client.GetFromJsonAsync<JsonElement>($"https://api.chucknorris.io/jokes/random");

            return apiResponse.GetProperty("value").ToString();          
        }

        /// <summary>
        /// Returns the list of joke categories the user can choose from
        /// </summary>
        /// <returns>List<string></returns>
        public async Task<List<string>> GetJokeCategories()
        {
            var apiResponse = await client.GetFromJsonAsync<JsonElement>($"https://api.chucknorris.io/jokes/categories");

            List<string> categories = apiResponse.Deserialize<List<string>>();
                

            return categories;
        }

        /// <summary>
        /// Returns a joke as a string from the received category
        /// </summary>
        /// <param name="category"></param>
        /// <returns>string</returns>
        public async Task<string> GetJokeFromCategory(string category)
        {
            var apiResponse = await client.GetFromJsonAsync<JsonElement>($"https://api.chucknorris.io/jokes/random?category={category}");

            Console.WriteLine(apiResponse);
            return apiResponse.GetProperty("value").ToString();


        }
    }
}
