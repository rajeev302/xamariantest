using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace NotesApp
{
    public class Api
    {
        //List<RecyclerViewItem> Items;

        public string testSharedProject()
        {
            return "abc";
        }

        public async Task<List<RecyclerViewItem>> GetData()
        {
            var request = new HttpRequestMessage();
            request.RequestUri = new Uri("https://jsonplaceholder.typicode.com/posts");
            request.Method = HttpMethod.Get;
            request.Headers.Add("Accept", "application/json");
            var client = new HttpClient();
            HttpResponseMessage response = await client.SendAsync(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                HttpContent content = response.Content;
                var json = await content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<RecyclerViewItem>>(json);
                //return Items;
            }
            else
                return null;
        }
    }
}
