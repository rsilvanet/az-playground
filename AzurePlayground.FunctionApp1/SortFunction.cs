using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Linq;

namespace AzurePlayground.FunctionApp1
{
    public static class SortFunction
    {
        [FunctionName("sort")]
        public static async Task<IActionResult> Run([HttpTrigger("post")] HttpRequest request)
        {
            var requestBody = await new StreamReader(request.Body).ReadToEndAsync();
            var numbersArray = JsonConvert.DeserializeObject<int[]>(requestBody);

            return new OkObjectResult(numbersArray.OrderBy(x => x));
        }
    }
}
