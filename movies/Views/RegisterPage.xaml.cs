using System;
using System.Threading.Tasks;
using movies.Models.Response;
using movies.Models;
using Xamarin.Forms;
using System.Diagnostics;

namespace movies.Views
{
    public partial class RegisterPage : ContentPage
    {
        public BaseResponse Response { set; get; }
        public Task<BaseResponse> task;

        public RegisterPage()
        {
            InitializeComponent();
        }

        void Register_Clicked(object sender, EventArgs e)
        {
            var user = new BaseUser(edtName.Text, edtEmail.Text, edtPw.Text);
            Response = new BaseResponse();
            task = App.userManager.RegisterTaskAsync(user);
            Response = task.Result;
            if (Response.error)
            {
                ShowAlert(null, "Register Failed");
            }
            else
            {
                Debug.WriteLine(@"             Success:" + Response.data.ToString());
                ShowAlert(null, "Register successful");
                Application.Current.Properties["token"] = Response.data.access_token;
                Navigation.PushAsync(new movies.moviesPage(new Sqlite.DataAccess())).ConfigureAwait(false);
            }
        }

        public void ShowAlert(string title, string content)
        {
            DisplayAlert(title, content, "OK");
        }
    }
}
