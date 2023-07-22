using CoreClient00001.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;
using System.Net.Http.Headers;

namespace CoreClient00001.Controllers
{
    public class DataController : Controller
    {
        public ActionResult GetMembers()
        {
            IEnumerable<DataAccess> members = null;

            using (var client = new HttpClient())
            {
                DataTable dt = new DataTable();
                client.BaseAddress = new Uri("http://124.109.48.176:2221/");

                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                /*var response = client.GetAsync("api/MyAPI").ConfigureAwait(false);*/
                

                var responseTask = client.GetAsync("api/ScadaSensorLog");
                responseTask.Wait();

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<DataAccess>>();
                    readTask.Wait();

                    /*dynamic results = response.Content.ReadAsStringAsync();
                    dt = (DataTable)JsonConvert.DeserializeObject(results, typeof(DataTable));*/

                    members = readTask.Result;
                }
                else
                {
                    //Error response received   
                    members = Enumerable.Empty<DataAccess>();
                    ModelState.AddModelError(string.Empty, "Server error try after some time.");
                }
                responseTask = client.GetAsync("member");
            }
            return View(members);
        }
    }
}
