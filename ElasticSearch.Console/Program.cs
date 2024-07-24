using Nest;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElasticSearch.Console
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var connectionSettings = new ConnectionSettings(new Uri("https://localhost:9200"))
                .BasicAuthentication("elastic", "R_CwZTfSY2FFDNjh-pVn")
                .CertificateFingerprint("9bf58eae9755c43868d859d6ef37282f054d599334aa2229e9088c94443ab38c")
                .DefaultMappingFor<Account>(i => i.IndexName("accounts"))
                .EnableDebugMode()
                .PrettyJson()
                .RequestTimeout(TimeSpan.FromMinutes(2));

            var client = new ElasticClient(connectionSettings);

            #region Search

            #endregion
        }
    }


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
