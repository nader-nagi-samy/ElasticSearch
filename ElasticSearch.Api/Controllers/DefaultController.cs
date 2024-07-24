using ElasticSearch.Api.Elastic;
using Nest;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace ElasticSearch.Api.Controllers
{
    /// <summary>
    /// Description of the class/method/variable
    /// </summary>
    public class DefaultController : ApiController
    {
        private readonly ISearchService _searchService;

        /// <summary>
        /// Description of the class/method/variable
        /// </summary>
        public DefaultController()
        {
            var connectionSettings = new ConnectionSettings(new Uri("https://localhost:9200"))
                .BasicAuthentication("elastic", "R_CwZTfSY2FFDNjh-pVn")
                .CertificateFingerprint("9bf58eae9755c43868d859d6ef37282f054d599334aa2229e9088c94443ab38c")
                .DefaultMappingFor<ElasticAccount>(i => i.IndexName("accounts"))
                .EnableDebugMode()
                .PrettyJson()
                .RequestTimeout(TimeSpan.FromMinutes(2));
            // 
            _searchService = new SearchService(new ElasticClient(connectionSettings));
        }

        [HttpGet]
        public async Task<IHttpActionResult> Search([FromUri] SearchAccountRequest request, CancellationToken cancellationToken = default)
        {
            var parameters = request.ToSearchParameters();
            var accountsResponce = await _searchService.SearchAsync(parameters, cancellationToken);
            var accounts = accountsResponce.Documents;
            var count = accountsResponce.Total;
            var response = new SearchAccountResponse()
            {
                Accounts = accounts.Select(a => a.ToAccountResponse()),
                PageNumber = request.PageNumber,
                PageSize = request.PageSize,
                TotalCount = count,
                TotalPages = (int)Math.Ceiling(count / (double)request.PageSize)
            };
            return Ok(response);
        }



        //[HttpGet]
        //public async Task<IActionResult> Search([FromQuery] SearchSongsRequest request, CancellationToken cancellationToken)
        //{
        //    var parameters = request.ToSearchParameters();
        //    var songsResponse = await _searchService.SearchAsync(parameters, cancellationToken);
        //    var songs = songsResponse.Documents;
        //    var count = songsResponse.Total;
        //    var response = new SearchSongsResponse(songs.Select(x => x.ToSongResponse()), request.PageNumber,
        //        request.PageSize, count, (int)Math.Ceiling(count / (double)request.PageSize));
        //    return Ok(response);
        //}
    }
}
