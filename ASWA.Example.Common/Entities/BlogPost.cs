using Microsoft.Azure.Cosmos.Table;

namespace ASWA.Example.Common.Entities
{
    public class BlogPost : TableEntity
    {
        #region Constants

        public const string PARTITIONKEY = "blogposts";

        #endregion

        #region Constructors

        public BlogPost()
        {
            PartitionKey = PARTITIONKEY;
        }

        #endregion

        [IgnoreProperty]
        public string Title => RowKey;

        public string Url { get; set; }

        public string Description { get; set; }
    }
}
