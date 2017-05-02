using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System;
using System.Diagnostics;

namespace Movies.Model
{
    public class OMDBSearch
    {
        #region METHODS

        public async Task<List<MovieSearchResultMovie>> Search(string name)
        {
            List<MovieSearchResultMovie> matchingMovies = new List<MovieSearchResultMovie>();
            int pageNumber = 0;
            int currentYear = DateTime.Now.Year;
            int searchYear = currentYear;
            int movieCount = 0;

            do
            {
                pageNumber += 1;
                MovieSearchResult searchResult = await SearchHelper(name, searchYear, pageNumber);

                if (searchResult != null && searchResult.Response)
                {
                    matchingMovies.AddRange(searchResult.Search);
                    movieCount += searchResult.Search.Count;

                    if (searchResult?.Search.Count < 10)
                    {
                        if (searchYear == currentYear)
                        {
                            searchYear -= 1;
                            pageNumber = 0;
                        }
                        else
                            break;
                    }
                }
                else
                {
                    if (searchYear == currentYear)
                    {
                        searchYear -= 1;
                        pageNumber = 0;
                    }
                    else
                        break;
                }

            } while (movieCount < 50);

            return matchingMovies;
        }

        public async Task<MovieLookupResult> Lookup(string IMDBID)
        {
            HttpClient httpClient = new HttpClient();
            string url = $"{OMDBAPIHost}/?i={IMDBID}";

            HttpResponseMessage response = httpClient.GetAsync(url, HttpCompletionOption.ResponseHeadersRead).GetAwaiter().GetResult();

            if (response.StatusCode == HttpStatusCode.OK)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<MovieLookupResult>(responseBody);
            }

            return null;
        }

        #endregion

        #region PRIVATE METHODS

        private async Task<MovieSearchResult> SearchHelper(string name, int year, int pageNumber)
        {
            HttpClient httpClient = new HttpClient();
            string url = $"{OMDBAPIHost}/?s={name}&y={year}&page={pageNumber}";

            Debug.WriteLine($"SearchHelper url:{url}");

            HttpResponseMessage response = httpClient.GetAsync(url, HttpCompletionOption.ResponseHeadersRead).GetAwaiter().GetResult();

            Debug.WriteLine($"SearchHelper statusCode:{response.StatusCode}");

            if (response.StatusCode == HttpStatusCode.OK)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<MovieSearchResult>(responseBody);
            }

            return null;
        }

        #endregion

        #region FIELDS

        private const string OMDBAPIHost = "http://www.omdbapi.com";

        #endregion
    }
}
