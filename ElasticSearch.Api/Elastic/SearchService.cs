using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using System.Web;

namespace ElasticSearch.Api.Elastic
{
    public interface ISearchService
    {
        Task<ISearchResponse<ElasticAccount>> SearchAsync(SearchAccountParameter parameters,
            CancellationToken cancellationToken = default);
    }

    public class SearchService : ISearchService
    {
        private readonly IElasticClient _elasticClient;

        public SearchService(IElasticClient elasticClient)
        {
            _elasticClient = elasticClient;
        }

        public async Task<ISearchResponse<ElasticAccount>> SearchAsync(SearchAccountParameter parameters, CancellationToken cancellationToken)
        {

            return await _elasticClient.SearchAsync<ElasticAccount>(x => x
                .Query(q => q
                    .Bool(b => b
                        .Should(s => s
                            .MultiMatch(m => m
                                .Fields(f => f
                                 .Field(ff => ff.Firstname)
                                 .Field(ff => ff.Lastname)
                                 .Field(ff => ff.State)
                                 )
                                .Query(parameters.SearchText)
                                .Fuzziness(Fuzziness.Auto)
                                )
                            )
                        .MinimumShouldMatch(1)
                        )
                    )
                .Sort(s => s.Descending(SortSpecialField.Score))
                .Skip(parameters.Skip)
                .Take(parameters.Take)
            , cancellationToken);
        }
    }
}


/*
 public interface ISearchService
{
    Task<ISearchResponse<ElasticSong>> SearchAsync(SearchParameters parameters,
        CancellationToken cancellationToken);
}

public class SearchService : ISearchService
{
    private readonly IElasticClient _elasticClient;

    public SearchService(IElasticClient elasticClient)
    {
        _elasticClient = elasticClient;
    }

    public async Task<ISearchResponse<ElasticSong>> SearchAsync(SearchParameters parameters,
        CancellationToken cancellationToken)
    {
        var result = await _elasticClient.SearchAsync<ElasticSong>(x => x
            .Query(q => q
                .Bool(b => b
                    .Should(s => s
                        .MultiMatch(m => m
                            .Fields(f => f
                                .Field(ff => ff.Title, boost: 2)
                                .Field(ff => ff.AlbumTitle)
                                .Field(ff => ff.ArtistName, boost: 3)
                            )
                            .Query(parameters.SearchText)
                            .Fuzziness(Fuzziness.Auto)
                        )
                    )
                    .MinimumShouldMatch(1)
                    .Filter(f => f
                        .Term(t => t.Genre, parameters.Genre)
                    )
                )
            )
            .Sort(s => s.Descending(SortSpecialField.Score))
            .Skip(parameters.Skip)
            .Take(parameters.Take
            ), cancellationToken);

        return result;
    }
}
 
 
 */