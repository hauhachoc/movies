using System;
using System.Collections.Generic;
using movies.Models.Response;
using Xamarin.Forms;
using System.Threading.Tasks;
using movies.Models;
using System.Diagnostics;

namespace movies.Views
{
    public partial class LoginPage : ContentPage
    {
		public Task<BaseResponse> task;

		public BaseResponse Response { set; get; }

        public LoginPage()
        {
            InitializeComponent();
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
				//Navigation.PushAsync(new Views.MoviesPage()).ConfigureAwait(false);
			}
		}

		void RegisterClickEvent(object sender, EventArgs e)
		{
			//Navigation.PushAsync(new Views.Register());
		}

		public void ShowAlert(string title, string content)
		{
			DisplayAlert(title, content, "OK");
		}
    }
}
