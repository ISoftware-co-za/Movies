using System.Collections.Generic;

namespace Movies.Model
{
    public class MovieSearchResult
    {
        public List<MovieSearchResultMovie> Search { get; set; }

        public int TotalResults { get; set; }

        public bool Response { get; set; }

        public string Error { get; set; }

        public MovieSearchResult()
        {
            Search = new List<MovieSearchResultMovie>();
        }
    }
}
