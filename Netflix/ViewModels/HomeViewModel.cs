using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Netflix.Models;
using Netflix.Services;

namespace Netflix.ViewModels
{
    public partial class HomeViewModel : ObservableObject
    {
        private readonly TmdbService _tmdbService;
        public HomeViewModel(TmdbService tmdbService)
        {
            _tmdbService = tmdbService;
        }

        public ObservableCollection<Media> Trending { get; set; } = new();
        public ObservableCollection<Media> TopRated { get; set; } = new();
        public ObservableCollection<Media> NetflixOriginals { get; set; } = new();
        public ObservableCollection<Media> ActionMovies { get; set; } = new();

        public async Task InitializeAsync()
        {
            var trendingListTask = _tmdbService.GetTrendingAsync();
            var netflixOriginalsListTask = _tmdbService.GetNetflixOriginalAsync();
            var topRatedListTask = _tmdbService.GetTopRatedAsync();
            var actionListTask = _tmdbService.GetActionAsync();

            var medias = await Task.WhenAll(trendingListTask,
                                    netflixOriginalsListTask,
                                    topRatedListTask,
                                    actionListTask);

            var trendingList = medias[0];
            var netflixOriginalsList = medias[1];
            var topRatedList = medias[2];
            var actionList = medias[3];


        }

        private static void SetMediaCollection(IEnumerable<Media> medias, ObservableCollection<Media> collection)
        {
            collection.Clear();
            foreach (var media in medias)
            {
                collection.Add(media);
            }
        }

        //puudu
    }
}