using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Threading.Tasks;
using movies.Models.Response;
using movies.Sqlite;
using Xamarin.Forms;
using movies.Models;

namespace movies
{
    public partial class moviesPage : ContentPage
    {
        private IList<Film> films;
        private Task<FilmsResponse> data;
        private int current_page = 1;
        private int perpage = 10;
        private int total_page = 0;
        private bool dataLoading;
        private DataAccess database;

        public moviesPage(DataAccess db)
        {
            InitializeComponent();
            this.database = db;
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
            db.AddAllFilm(films);
            listViewMovie.ItemSelected += (object sender, SelectedItemChangedEventArgs e) =>
            {
                if (e.SelectedItem == null)
                    return;

                var user = db.GetLocalUser();
                if (user != null)
                {
                    if (!user.GetEnumerator().MoveNext())
                    {
                        //var index = (listViewMovie.ItemsSource as List<Film>).IndexOf(e.SelectedItem as Film);
                        var film = (listViewMovie.SelectedItem as Film);
                        //Application.Current.Properties["index"] = index;
                        Application.Current.Properties["film"] = film;
                        ShowAlert("Alert", "You need login");
                        Navigation.PushAsync(new Views.LoginPage(db));
                    }
                    else
                    {
                        var film = (listViewMovie.SelectedItem as Film);
                        Navigation.PushAsync(new Views.MovieDetailPage(film));
                    }
                }
                else
                {
                    ShowAlert("Alert", "You need login");
                    Navigation.PushAsync(new Views.LoginPage(db));
                }
                listViewMovie.SelectedItem = null;
            };
            listViewMovie.ItemAppearing += (object sender, ItemVisibilityEventArgs e) =>
            {
                var item = e.Item as Film;
                int index = films.IndexOf(item);
                if (films.Count - 2 <= index)
                    AddNextPageData();
            };

            toolbar.Clicked += (sender, e) =>
            {
                //ShowAlert("Alert", "Log out");
                db.DeleteAllData();
                Application.Current.Properties["film"] = null;
                Application.Current.Properties["token"] = "";
                Navigation.PushAsync(new Views.LoginPage(db));
            };

            //imgTaped.Tapped += (sender, e) =>
            //{
            //    ShowAlert(null, "Tested");
            //    imgLike.Source = FileImageSource.FromFile("local:ImageResource movies.Resources.un_like.png");
            //};

            checkFilm();
            //imgLike.Source = ImageSource.FromFile("movies.Resources.like.png");
        }

        public async void checkFilm()
        {
            await Task.Delay(1500);
            if (Application.Current.Properties.ContainsKey("film"))
            {
                //var index = Convert.ToString(Application.Current.Properties["index"]);
                if (Application.Current.Properties["film"] != null)
                {
                    var film = Application.Current.Properties["film"];
                    await Navigation.PushAsync(new Views.MovieDetailPage((movies.Models.Response.Film)film));
                }
            }
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

        //public void OnTapped(object sender, EventArgs e)
        //{
        //    ShowAlert("aaaa", "AAAAAA");
        //}

        private void Image_OnTapped(object sender, EventArgs e)
        {
            ShowAlert(null, "Tested");
            Image img = new Image();
            img.Source = FileImageSource.FromFile("local:ImageResource movies.Resources.un_like.png");
        }
    }
}
