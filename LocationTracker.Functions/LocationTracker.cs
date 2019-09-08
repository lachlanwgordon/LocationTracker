using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Microsoft.Azure.WebJobs.Extensions.SignalRService;
using System.Diagnostics;

namespace LocationTracker.Functions
{
    public static class LocationTracker
    {

        //Default function left here for reference only
        [FunctionName("LocationTracker")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string name = req.Query["name"];

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            name = name ?? data?.name;

            return name != null
                ? (ActionResult)new OkObjectResult($"Hello, {name}")
                : new BadRequestObjectResult("Please pass a name on the query string or in the request body");
        }



        ///This function is called from an page that wants to subscribe to this hub



        /// <summary>
            {

                var message = new SignalRMessage
                {
                    Target = "newLocation",
                    Arguments = new[] { location }
                };
                

                Debug.WriteLine($"Error {ex}\n{ex.StackTrace}");
                Debug.WriteLine($"Error {ex}\n{ex.StackTrace}");
            }
    }
}