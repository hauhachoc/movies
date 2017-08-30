using System;
using movies.Models.Response;
using Xamarin.Forms;

namespace movies.Views
{
    public partial class MovieDetailPage : ContentPage
    {
        public MovieDetailPage()
        {
            InitializeComponent();
        }

        public MovieDetailPage(Film film)
        {
            InitializeComponent();
            if (film!=null)
            lblTitle.Text = film.title;
        }
    }
}
