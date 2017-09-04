using System;
using movies.Models.Response;
using Xamarin.Forms;

namespace movies.Views
{
    public partial class MovieDetailPage : ContentPage
    {
        string fullTitle = "";

        public MovieDetailPage()
        {
            InitializeComponent();
        }

        public MovieDetailPage(Film film)
        {
            InitializeComponent();
            if (film!=null)
            {
                if (film != null)
                    fullTitle = film.title;
                if (fullTitle.Contains("/"))
                {
                    var result = fullTitle.Substring(fullTitle.LastIndexOf('/') + 1);
                    toolbar.Text = result;
                    lblTitle.Text = film.title;
                }
                else
                {
                    toolbar.Text = film.title;
                    lblTitle.Text = film.title;
                }
                imgMovie.Source = ImageSource.FromUri(new Uri(film.image));
                lblView.Text = "Views : " + film.views;
                lblDes.Text = film.description;
                lblGenres.Text = film.category;
                lblDirector.Text = film.director;
                lblTime.Text = film.duration + " minute";
                lblActor.Text = film.actor;
                wvMovie.Source = film.link;
                lblManu.Text = film.manufacturer;
            }
        }
    }
}
