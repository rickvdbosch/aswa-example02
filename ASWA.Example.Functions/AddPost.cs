using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Cosmos.Table;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;

using ASWA.Example.Common.Entities;

namespace ASWA.Example.Functions
{
	public static class AddPost
    {
        [FunctionName("AddPost")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)] BlogPost blogPost,
            [Table("Content", Connection = "scs")] CloudTable table,
            ILogger log)
        {
            await table.ExecuteAsync(TableOperation.Insert(blogPost));
            return new OkObjectResult(blogPost);
        }
    }
}
