using System;
using System.Runtime.Serialization;

using Azure;
using Azure.Data.Tables;

namespace ASWA.Example.Common.Entities
{
    public class BlogPost : ITableEntity
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

        [IgnoreDataMember]
        public string Title => RowKey;

        public string Description { get; set; }

        public string Url { get; set; }
        public string PartitionKey { get; set; }
        public string RowKey { get; set; }
        public DateTimeOffset? Timestamp { get; set; }
        public ETag ETag { get; set; }
    }
}
