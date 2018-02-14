using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;

namespace lingyApp
{
    public static class lingyAddition_fc
    {
        [FunctionName("lingyAddition_fc")]
        public static async Task<HttpResponseMessage> Run([HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)]HttpRequestMessage req, TraceWriter log)
        {
            log.Info("C# HTTP trigger function processed a request.");

            // parse query parameter
            string paramA = req.GetQueryNameValuePairs()
                .FirstOrDefault(q => string.Compare(q.Key, "paramA", true) == 0)
                .Value;

            string paramB = req.GetQueryNameValuePairs()
                .FirstOrDefault(q => string.Compare(q.Key, "paramB", true) == 0)
                .Value;

            int a = int.Parse(paramA);
            int b = int.Parse(paramB);
            int sum = a + b;
            string result = sum.ToString();
            string hallo = "hiiiiiinaaaaajaaaa";

            // Get request body
            dynamic reqDataA = await req.Content.ReadAsAsync<object>();
            dynamic reqDataB = await req.Content.ReadAsAsync<object>();

            // Set name to query string or body data
            paramA = paramA ?? reqDataA?.paramA;
            paramB = paramB ?? reqDataB?.paramB;


            return paramA == null
                ? req.CreateResponse(HttpStatusCode.BadRequest, "Please pass numbers in the request body")
                : req.CreateResponse(HttpStatusCode.OK, "The result is....  " + result);
        }
    }
}
