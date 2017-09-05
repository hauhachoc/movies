using System;
using System.Collections.Generic;
using movies.Models.Response;
using Xamarin.Forms;
using System.Threading.Tasks;
using System.Diagnostics;
using movies.Models;

namespace movies.Views
{
    public partial class ForgotPassword : ContentPage
    {

        public Task<BaseRes> task;
		public BaseRes Response { set; get; }

        public ForgotPassword()
        {
            InitializeComponent();
            btnSubmit.Clicked += (sender, e) => {
                if(string.IsNullOrEmpty(edtEmail.Text)){
					ShowAlert(null, "Input your email");
                }else{
					Response = new BaseRes();
					task = App.userManager.ForgotPwTaskAsync(edtEmail.Text);
					Response = task.Result;
					if (Response.error)
					{
						ShowAlert(null, Response.message.ToString());
					}
					else
					{
						ShowAlert(null, Response.message.ToString());
					}
                }
            };
        }

		public void ShowAlert(string title, string content)
		{
			DisplayAlert(title, content, "OK");
		}
    }
}
