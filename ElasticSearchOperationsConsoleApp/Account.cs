using Nest;
using Newtonsoft.Json;

namespace ElasticSearchOperationsConsoleApp
{
    internal class Account
    {
        [JsonProperty("account_number")]
        public int account_number { get; set; }

        [JsonProperty("balance")]
        public int balance { get; set; }


        [JsonProperty("firstname")]
        public string firstname { get; set; }

        [JsonProperty("lastname")]
        public string lastname { get; set; }

        [JsonProperty("age")]
        public int age { get; set; }

        [JsonProperty("gender")]
        public string gender { get; set; }

        [JsonProperty("address")]
        public string address { get; set; }


        [JsonProperty("employer")]
        public string employer { get; set; }

        [JsonProperty("email")]
        public string email { get; set; }

        [JsonProperty("city")]
        public string city { get; set; }

        [JsonProperty("state")]
        public string state { get; set; }
    }
}
