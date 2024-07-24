using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElasticSearch.Api.Elastic
{
    public class SearchAccountResponse
    {
        public IEnumerable<ElasticAccountResponse> Accounts { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public long TotalCount { get; set; }
        public long TotalPages { get; set; }
    }
}


/*
 * 
 public record SearchSongsResponse(IEnumerable<SongResponse> Songs, int PageNumber, int PageSize,
    long TotalCount, int TotalPages);
 */