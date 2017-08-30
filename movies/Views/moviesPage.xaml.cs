using System.Collections.Generic;
using System.Threading.Tasks;
using movies.Models.Response;
using Xamarin.Forms;

namespace movies
{
    public partial class moviesPage : ContentPage
    {
        private IList<Film> films;
        private Task<FilmsResponse> data;

        public moviesPage()
        {
            InitializeComponent();
            NavigationPage.SetHasBackButton(this, false);
            films = new List<Film>();
            data = App.userManager.GetFilmsTasksAsync("1", "20");
            FilmsResponse filmRes = data.Result;
            if (filmRes.error)
            {
                ShowAlert(null, "get films failed");
            }
            else
            {
                if (data.Result.data != null)
                    films = data.Result.data;
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
        }

        public void ShowAlert(string title, string content)
        {
            DisplayAlert(title, content, "OK");
        }
    }
}
