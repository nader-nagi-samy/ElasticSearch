using Nest;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElasticSearch.Api.Elastic
{
    public class ElasticAccountResponse
    {

        [JsonProperty("account_number")]
        public int AccountNumber { get; set; }

        [JsonProperty("balance")]
        public int Balance { get; set; }

        [JsonProperty("firstname")]
        public string Firstname { get; set; }

        [JsonProperty("lastname")]
        public string Lastname { get; set; }

        [JsonProperty("age")]
        public int Age { get; set; }

        [JsonProperty("gender")]
        public string Gender { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }
    }
}