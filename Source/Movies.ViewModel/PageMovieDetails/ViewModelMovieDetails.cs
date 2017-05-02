using System;
using System.Collections.Generic;
using Movies.Model;

namespace Movies.ViewModel.PageMovieDetails
{
    public class ViewModelMovieDetails : ViewModelBase
    {
        public string Title
        {
            get => _title;
            set => SetField( ref _title, value);
        }
        private string _title;

        public List<ListItemMovieAttributeBase> Attributes
        {
            get => _attributes;
            set => SetField(ref _attributes, value);
        }
        private List<ListItemMovieAttributeBase> _attributes;

        public string Plot
        {
            get => _plot;
            set => SetField(ref _plot, value);
        }
        private string _plot;

        public string PosterURL
        {
            get => _posterURL;
            set => SetField(ref _posterURL, value);
        }
        private string _posterURL;

        public string Imdburl
        {
            get => _imdburl;
            set => SetField(ref _imdburl, value);
        }
        private string _imdburl;

        public CommandBrowseToMovie CommandBrowseToMovie { get; }

        public ViewModelMovieDetails()
        {
            CommandBrowseToMovie = new CommandBrowseToMovie(this);
        }

        public async void Initialise()
        {
            OMDBSearch search = new OMDBSearch();

            MovieLookupResult result = await search.Lookup(ViewModelState.SelectedMovieIMDB);

            Title = result.Title;

            if (!string.IsNullOrEmpty(result.IMDBID))
                Imdburl = $"http://www.imdb.com/title/{result.IMDBID}/";
            if (IsValidValue(result.Plot))
                Plot = result.Plot;
            if (IsValidValue(result.Poster))
                PosterURL = result.Poster;

            List<ListItemMovieAttributeBase> attributes = new List<ListItemMovieAttributeBase>();

            if (IsValidValue(result.Runtime))
            {
                attributes.Add(new ListItemMovieAttributeLabel("Length"));
                attributes.Add(new ListItemMovieAttributeValue(result.Runtime));
            }

            if (IsValidValue(result.Rated))
            {
                attributes.Add(new ListItemMovieAttributeLabel("Rating"));
                attributes.Add(new ListItemMovieAttributeValue(result.Rated));
            }

            if (IsValidValue(result.Actors))
            {
                string[] actors = result.Actors.Split(',');

                if (actors.Length > 0)
                {
                    int numberOfActorsToDisplay = Math.Min(actors.Length, 4);

                    attributes.Add(new ListItemMovieAttributeLabel("Actors"));
                    for(int index = 0; index < numberOfActorsToDisplay; ++index)
                        attributes.Add(new ListItemMovieAttributeValue(actors[index]));
                }
            }

            if (IsValidValue(result.Language))
            {
                attributes.Add(new ListItemMovieAttributeLabel("Language"));
                attributes.Add(new ListItemMovieAttributeValue(result.Language));
            }

            Attributes = attributes;
        }

        private bool IsValidValue(string value)
        {
            return !string.IsNullOrEmpty(value) && value != "N/A";
        }
    }
}
