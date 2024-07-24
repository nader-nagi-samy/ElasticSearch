using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElasticSearch.Api.Elastic
{
    public static class Mapper
    {
        public static SearchAccountParameter ToSearchParameters(this SearchAccountRequest request)
        {
            return new SearchAccountParameter()
            {
                SearchText = request.SearchText,
                Skip = request.PageSize * (request.PageNumber - 1),
                Take = request.PageSize
            };
        }

        public static ElasticAccountResponse ToAccountResponse(this ElasticAccount account)
        {
            return new ElasticAccountResponse()
            {
                AccountNumber = account.AcountNmber,
                Address = account.Address,
                Age = account.Age,
                Balance = account.Balance,
                Firstname = account.Firstname,
                Lastname = account.Lastname,
                Gender = account.Gender
            };
        }
    }
}



/*
  public static ElasticSong ToElasticSong(this Song song)
        => new()
        {
            Id = song.Id,
            Title = song.Title,
            AlbumTitle = song.Album!.Title,
            AlbumReleaseDate = song.Album.ReleaseDate.ToString("yyyy-MM-dd"),
            ArtistName = song.Album.Artist!.Name,
            Genre = song.Album.Genre!.Name
        };
    
    public static SearchParameters ToSearchParameters(this SearchSongsRequest request)
        => new(request.SearchText, request.Genre, request.PageSize * (request.PageNumber - 1) , request.PageSize);
    
    public static SongResponse ToSongResponse(this ElasticSong song)
        => new(song.Id, song.Title, song.AlbumTitle, song.AlbumReleaseDate, song.ArtistName, song.Genre, DateOnly.Parse(song.AlbumReleaseDate));
    
    public static SongResponseWithScore ToSongResponseWithScore(this IHit<ElasticSong> song)
        => new(song.Source.Id, song.Source.Title, song.Source.AlbumTitle, song.Source.AlbumReleaseDate, 
            song.Source.ArtistName, song.Source.Genre, DateOnly.Parse(song.Source.AlbumReleaseDate), song.Score ?? 0);
 
 
 */