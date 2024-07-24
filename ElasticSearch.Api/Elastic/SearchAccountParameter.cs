using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElasticSearch.Api.Elastic
{
    public class SearchAccountParameter
    {
        public string SearchText { get; set; }
        public int Skip { get; set; }
        public int Take { get; set; }
    }
}