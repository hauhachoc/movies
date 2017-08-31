using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Threading.Tasks;
using movies.Models.Response;
using Xamarin.Forms;

namespace movies
{
    public partial class moviesPage : ContentPage
    {
        private IList<Film> films;
        private Task<FilmsResponse> data;
        private int current_page = 1;
        private int perpage = 20;
        private int total_page = 0;
        private bool dataLoading;

        public moviesPage()
        {
            InitializeComponent();
            NavigationPage.SetHasBackButton(this, false);
            films = new List<Film>();
            data = App.userManager.GetFilmsTasksAsync(Convert.ToString(current_page), Convert.ToString(perpage));
            FilmsResponse filmRes = data.Result;
            if (filmRes.error)
            {
                ShowAlert(null, "get films failed");
            }
            else
            {
                if (data.Result.data != null)
                    films = data.Result.data;
                total_page = data.Result.paging.total_pages;
            }
            listViewMovie.ItemsSource = films;
            listViewMovie.ItemSelected += (object sender, SelectedItemChangedEventArgs e) =>
            {
                if (e.SelectedItem == null)
                    return;
                var film = (listViewMovie.SelectedItem as Film);
                Navigation.PushAsync(new Views.MovieDetailPage(film));
                listViewMovie.SelectedItem = null;
            };
            listViewMovie.ItemAppearing += (object sender, ItemVisibilityEventArgs e) =>
            {
                var item = e.Item as Film;
                int index = films.IndexOf(item);
                if (films.Count - 2 <= index)
                    AddNextPageData();
            };
        }

        public void AddNextPageData()
        {
            if (dataLoading)
                return;
            listViewMovie.BeginRefresh();
            dataLoading = true;
			current_page++;

            if (current_page <= total_page)
            {
				IList<Film> moreFilms = App.userManager.GetFilmsTasksAsync(Convert.ToString(current_page), Convert.ToString(perpage)).Result.data;
				foreach (var item in moreFilms)
                    films.Add(item);
                Debug.WriteLine(@"             size:" + films.Count);
                dataLoading = false;
            }
            listViewMovie.EndRefresh();
        }

        public void ShowAlert(string title, string content)
        {
            DisplayAlert(title, content, "OK");
        }

        protected override bool OnBackButtonPressed()
        {

            return true;
        }
    }
}
