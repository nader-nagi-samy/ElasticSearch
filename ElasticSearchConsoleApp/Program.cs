
using Elasticsearch.Net;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;


namespace ElasticSearchConsoleApp
{
    internal class Program
    {
        public static Uri _node;
        public static ConnectionSettings _setting;
        public static ElasticClient _client;


        static void Main(string[] args)
        {
            _node = new Uri("http://localhost:9200");
            _setting = new ConnectionSettings(uri: _node)
                .DefaultIndex("blog").EnableDebugMode(onRequestCompleted: s)
                .MaximumRetries(20)
                .BasicAuthentication("elastic", "20070366");
            _client = new ElasticClient(_setting);

            //  index-settings.
            //var indexSettings = new IndexSettings();
            //indexSettings.NumberOfShards = 1;
            //indexSettings.NumberOfReplicas = 1;

            var x = _client.Ping();



            //var createIndexResponse = _client.Indices.Create("blog", c => c.Map<Post>(m => m.AutoMap())
            //.Settings(s => s.NumberOfShards(1).NumberOfReplicas(1)));

            var posts = new[] {
                new Post
            {
                UserId = 2,
                PostDate = DateTime.Now.AddDays(1),
                PostText = "This is another blog post."
            },
                new Post
            {
                UserId = 2,
                PostDate = DateTime.Now.AddDays(1),
                PostText = "This is another blog post."
            },
                new Post
            {
                UserId = 3,
                PostDate = DateTime.Now.AddDays(3),
                PostText = "This is a third blog post."
            }
            };

            var newBlogPost = new Post
            {
                UserId = 2,
                PostDate = DateTime.Now.AddDays(1),
                PostText = "This is another blog post."
            };

            var newBlogPost2 = new Post
            {
                UserId = 3,
                PostDate = DateTime.Now.AddDays(3),
                PostText = "This is a third blog post."
            };

            var newBlogPost3 = new Post
            {
                UserId = 4,
                PostDate = DateTime.Now.AddDays(5),
                PostText = "This is a blog post from the future."
            };

            var indexResponse = _client.Index<Post>(newBlogPost, d => d.Index("blog").Id(1));
            //var indexResponse2 = _client.IndexDocument(newBlogPost2);
            //var indexResponse3 = _client.IndexDocument(newBlogPost3);

            //var bulkIndexResponse = _client.Bulk(b => b.Index("blog")
            //.IndexMany(posts));

            //if (!bulkIndexResponse.IsValid)
            //{
            //    // If the request isn't valid, we can take action here
            //    Console.WriteLine(bulkIndexResponse.ServerError);
            //}

            Console.ReadKey();
        }

        private static void s(IApiCallDetails details)
        {
        }
    }
}
