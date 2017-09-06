using System;
using System.ComponentModel;
using System.Diagnostics;
using movies.Models.Response;
using Xamarin.Forms;

namespace movies.Views
{
    public partial class MovieDetailPage : ContentPage
    {
        string fullTitle = "";
        bool isMoreDescription = false;

        public MovieDetailPage()
        {
            InitializeComponent();
        }

        public MovieDetailPage(Film film)
        {
            InitializeComponent();
            if (film != null)
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
                lblDes.Lines = 2;
                lblGenres.Text = film.category;
                lblDirector.Text = film.director;
                lblTime.Text = film.duration + " minute";
                lblActor.Text = film.actor;

                string url = film.link.Substring(film.link.LastIndexOf("=")).Replace("=", "");
                var html = new HtmlWebViewSource
                {
                    Html = "<iframe src=\"https://www.youtube.com/embed/"+ url +"\" width=\"100%\" height=\"200\" frameborder=\"0\" allowfullscreen></iframe>"
				};
                wvMovie.Source = html;
                Debug.WriteLine(@" html:" + html.Html);

				lblManu.Text = film.manufacturer;

                var tgr = new TapGestureRecognizer();
                tgr.Tapped += (s, e) =>
                {
                    if (isMoreDescription)
                    {
                        lblDes.Lines = 4;
                        isMoreDescription = false;
                        Debug.WriteLine("isMoreDescription false" + lblDes.Lines);
                    }
                    else
                    {
                        lblDes.Lines = 20;
                        isMoreDescription = true;
                        Debug.WriteLine("isMoreDescription true" + lblDes.Lines);
                    }
                };
                lblDes.GestureRecognizers.Add(tgr);
                //lblDes.GestureRecognizers.Add(new TapGestureRecognizer((view) => OnLabelClicked()));
            }
        }
    }
}
