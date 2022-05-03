using System.Linq;

using ASWA.Example.Common;
using ASWA.Example.Common.Entities;

using Azure.Data.Tables;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;

namespace ASWA.Example.Functions
{
    public class BlogPostFunctions
    {
        [FunctionName("blogposts")]
        public IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req,
            [Table(Constants.TABLENAME_CONTENT, Connection = "scs")] TableClient tableClient,
            ILogger log)
        {
            var posts = tableClient.Query<BlogPost>().ToList();

            return new OkObjectResult(posts);
        }
    }
}
