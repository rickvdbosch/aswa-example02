using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;

using ASWA.Example.Common.Entities;

namespace ASWA.Example.Functions
{
	public class AddPost
    {
        [FunctionName("AddPost")]
        public IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)] BlogPost blogPost,
            [Table("Content", Connection = "scs")] out BlogPost entity,
            ILogger log)
        {
            entity = blogPost;

            return new OkObjectResult(blogPost);
        }
    }
}
