using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.WindowsAzure.Storage.Table;

using ASWA.Example.Common;
using ASWA.Example.Common.Entities;

namespace ASWA.Example.Functions
{
    public static class BlogPostFunctions
    {
        [FunctionName("blogposts")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req,
            [Table(Constants.TABLENAME_CONTENT, Connection = "scs")]CloudTable cloudTable,
            ILogger log)
        {
            var posts = await GetBlogPostsFromTable(cloudTable);
            
            return new OkObjectResult(posts);
        }

        #region Private methods

        private static async Task<List<BlogPost>> GetBlogPostsFromTable(CloudTable table)
        {
            TableQuerySegment<BlogPost> querySegment = null;
            var entities = new List<BlogPost>();
            var query = new TableQuery<BlogPost>().Where(TableQuery.GenerateFilterCondition(nameof(ITableEntity.PartitionKey), QueryComparisons.Equal, BlogPost.PARTITIONKEY));

            do
            {
                querySegment = await table.ExecuteQuerySegmentedAsync(query, querySegment?.ContinuationToken);
                entities.AddRange(querySegment.Results);
            } while (querySegment.ContinuationToken != null);

            return entities;
        }

        #endregion
    }
}
