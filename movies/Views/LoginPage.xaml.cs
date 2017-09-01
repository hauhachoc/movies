using System;
using System.Collections.Generic;
using movies.Models.Response;
using Xamarin.Forms;
using System.Threading.Tasks;
using movies.Models;
using System.Diagnostics;
using movies.Sqlite;

namespace movies.Views
{
    public partial class LoginPage : ContentPage
    {
        public Task<BaseResponse> task;
        public BaseResponse Response { set; get; }
        public DataAccess database;

        public LoginPage()
        {
            InitializeComponent();
            database = new DataAccess();
            edtEmail.Text = "Aa@aa.aa";
            edtPw.Text = "123456";
        }
        void LoginClick(object sender, EventArgs e)
        {
            //App.userManager.LoginTaskAsync(edtEmail.Text, edtPw.Text);
            Response = new BaseResponse();
            task = App.userManager.LoginTaskAsync(edtEmail.Text, edtPw.Text);
            Response = task.Result;
            if (Response.error)
            {
                ShowAlert(null, "Login Failed");
            }
            else
            {
                Debug.WriteLine(@"             Success:" + Response.data.ToString());
                Application.Current.Properties["token"] = Response.data.access_token;

                //LocalUser localUser = new LocalUser();
                //localUser.email = Response.data.email;
                //localUser.full_name = Response.data.full_name;
                //localUser.access_token = Response.data.access_token;

                database.AddLocalUser(Response.data.email, Response.data.access_token);
                //LocalUser user = database.GetLocalUser(0);
                //if (user != null)
                //{
                //    Debug.WriteLine(@"save token sql" + user.access_token);
                //}

                Navigation.PushAsync(new movies.moviesPage()).ConfigureAwait(false);
            }
        }

        void RegisterClickEvent(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Views.RegisterPage());
        }

        public void ShowAlert(string title, string content)
        {
            DisplayAlert(title, content, "OK");
        }
    }
}
