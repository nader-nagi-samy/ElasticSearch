using Nest;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElasticSearch.Api.Elastic
{
    public class ElasticAccount
    {
        [Keyword]
        [JsonProperty("account_number")]
        public int AcountNmber { get; set; }

        [Keyword]
        [JsonProperty("balance")]
        public int Balance { get; set; }

        [Text]
        [JsonProperty("firstname")]
        public string Firstname { get; set; }

        [Text]
        [JsonProperty("lastname")]
        public string Lastname { get; set; }

        [Keyword]
        [JsonProperty("age")]
        public int Age { get; set; }

        [Keyword]
        [JsonProperty("gender")]
        public string Gender { get; set; }

        [Text]
        [JsonProperty("address")]
        public string Address { get; set; }

        [Text]
        [JsonProperty("employer")]
        public string Employer { get; set; }

        [Text]
        [JsonProperty("email")]
        public string Email { get; set; }

        [Keyword]
        [JsonProperty("city")]
        public string City { get; set; }

        [Keyword]
        [JsonProperty("state")]
        public string State { get; set; }
    }
}