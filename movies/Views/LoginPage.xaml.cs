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
        public IList<Film> films;

        public LoginPage(DataAccess db)
        {
            InitializeComponent();
            database = db;
            edtEmail.Text = "Aa@aa.aa";
            edtPw.Text = "123456";
     //       if(db.GetFilms()!=null){
     //          var  filmss = database.GetFilms();
     //           if (filmss.GetEnumerator().MoveNext()){
					//Navigation.PushAsync(new movies.moviesPage(db)).ConfigureAwait(false);
            //    }
            //}
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
                database.AddLocalUser(Response.data.email, Response.data.access_token);

                Navigation.PushAsync(new movies.moviesPage(new DataAccess())).ConfigureAwait(false);
            }
        }

        void RegisterClickEvent(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Views.RegisterPage());
        }

		void LoginFbClick(object sender, EventArgs e)
		{
			Navigation.PushAsync(new Views.FacebookProfilePage());
		}

		void ForgotPwHandle_Clicked(object sender, EventArgs e)
		{
            Navigation.PushAsync(new Views.ForgotPassword());
		}

        public void ShowAlert(string title, string content)
        {
            DisplayAlert(title, content, "OK");
        }
    }
}
