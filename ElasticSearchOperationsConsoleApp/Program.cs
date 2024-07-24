using Elastic.Clients.Elasticsearch;
using Elastic.Clients.Elasticsearch.QueryDsl;
using Elastic.Transport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ElasticSearchOperationsConsoleApp
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var settings = new ElasticsearchClientSettings(new Uri("https://localhost:9200"))
                .CertificateFingerprint("9bf58eae9755c43868d859d6ef37282f054d599334aa2229e9088c94443ab38c")
                .Authentication(new BasicAuthentication("elastic", "R_CwZTfSY2FFDNjh-pVn"))
                .DefaultMappingFor<Account>(i => i.IndexName("accounts")
                    .IdProperty(a => a.account_number))
                .EnableDebugMode()
                .PrettyJson()
                .RequestTimeout(TimeSpan.FromMinutes(2));

            var client = new ElasticsearchClient(settings);

            #region Create an index.
            //var response = await client.Indices.CreateAsync("blog");
            //if (response.IsValidResponse)
            //{
            //    await Console.Out.WriteLineAsync("blog index created!");
            //} 
            #endregion

            #region Indexing a document
            //var blogPost = new Post
            //{
            //    UserId = 1,
            //    PostDate = DateTime.Now,
            //    PostText = "This is a blog post."
            //};

            //var newBlogPost2 = new Post
            //{
            //    UserId = 3,
            //    PostDate = DateTime.Now.AddDays(3),
            //    PostText = "This is a third blog post."
            //};

            //var newBlogPost3 = new Post
            //{
            //    UserId = 4,
            //    PostDate = DateTime.Now.AddDays(5),
            //    PostText = "This is a blog post from the future."
            //};

            //var response = await client.IndexAsync(blogPost);
            //if (response.IsValidResponse)
            //{
            //    await Console.Out.WriteLineAsync("a post document successfully indexed");
            //}
            #endregion

            #region Get a document.
            //var response = await client.GetAsync<Post>(1, idx => idx.Index("blog"));

            //if (response.IsValidResponse)
            //{
            //    var doc = response.Source;
            //    Console.WriteLine($"Index document with ID {response.Id} succeeded.");
            //}
            #endregion

            #region Update a document.
            //var updateResponse = await client.UpdateAsync<Post, Post>("blog", 1, u => u.Doc(new Post
            //{
            //    UserId = 2,
            //    PostDate = DateTime.Now.AddDays(-1),
            //    PostText = "Text Updated."
            //}));
            //if (updateResponse.IsValidResponse)
            //{
            //    await Console.Out.WriteLineAsync($"Index document with ID {updateResponse.Id} succeeded.");
            //}
            #endregion

            #region Delete a document.
            //var response = await client.DeleteAsync("my-tweet-index", 1);

            //if (response.IsValidResponse)
            //{
            //    Console.WriteLine("Delete document succeeded.");
            //}
            #endregion

            #region Delete a index.

            #endregion

            #region Search for documents.

            //await client.SearchAsync<Account>(x => x
            //.Query(q => q
            //    .Bool(b => b
            //        .Should(s => s
            //            .MultiMatch(m => m
            //                .Fields(fs => fs
            //                    .Field(ff => ff.Title, boost: 2)
            //                    .Field(ff => ff.AlbumTitle)
            //                    .Field(ff => ff.ArtistName, boost: 3)
            //                )
            //                .Query("")
            //                .Fuzziness(Fuzziness.Auto)
            //            )
            //        )
            //        .MinimumShouldMatch(1)
            //        .Filter(fl => fl
            //            .Term(t => t.Genre, parameters.Genre)
            //        )
            //    )
            //)
            //.Sort(s => s.Descending(SortSpecialField.Score))
            //.Skip(parameters.Skip)
            //.Take(parameters.Take
            //), cancellationToken);



            //var searchResponse = await client.SearchAsync<Account>(s => s
            //    .Index("acounts")
            //    .Query(q => q
            //        .Bool(b => b
            //            .Should(sh => sh
            //                .Match(m => m
            //                    .Field(a => a.firstname)
            //                    .Query("Burton")
            //                    )

            //                )
            //             )
            //        )
            //    );

            //if (searchResponse.IsValidResponse)
            //{
            //    var tweet = searchResponse.Documents.FirstOrDefault();
            //}
            #endregion




            Console.ReadKey();
        }
    }
}
