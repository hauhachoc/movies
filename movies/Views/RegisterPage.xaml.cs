using System;
using System.Threading.Tasks;
using movies.Models.Response;
using movies.Models;
using Xamarin.Forms;
using System.Diagnostics;
using movies.Sqlite;

namespace movies.Views
{
    public partial class RegisterPage : ContentPage
    {
        public BaseResponse Response { set; get; }
        public Task<BaseResponse> task;
        public DataAccess database;
        public RegisterPage()
        {
            InitializeComponent();
            database = new DataAccess();
            edtName.Text = "";
            edtEmail.Text = "";
            edtPw.Text = "";
            edtConfirmPw.Text = "";
            lblNameTitle.IsVisible = false;
            lblEmailTitle.IsVisible = false;
            lblPwlTitle.IsVisible = false;
            lblConfirmPwTitle.IsVisible = false;
        }

        void Register_Clicked(object sender, EventArgs e)
        {
            if (edtName.Text.Equals(""))
            {
                lblNameTitle.IsVisible = true;
				lblEmailTitle.IsVisible = false;
				lblPwlTitle.IsVisible = false;
				lblConfirmPwTitle.IsVisible = false;
            }
            else if (edtEmail.Text.Equals(""))
            {
                lblEmailTitle.IsVisible = true;
                lblNameTitle.IsVisible = false;
				lblPwlTitle.IsVisible = false;
				lblConfirmPwTitle.IsVisible = false;
            }
            else if (edtPw.Text.Equals(""))
            {
                lblPwlTitle.Text = "Password not empty";
                lblPwlTitle.IsVisible = true;
				lblEmailTitle.IsVisible = false;
                lblNameTitle.IsVisible = false;
				lblConfirmPwTitle.IsVisible = false;
            }
            else if (edtConfirmPw.Text.Equals(""))
            {
				lblPwlTitle.IsVisible = false;
				lblEmailTitle.IsVisible = false;
                lblNameTitle.IsVisible = false;
                lblConfirmPwTitle.IsVisible = true;
            }
            else if (!edtPw.Text.Equals(edtConfirmPw.Text))
            {
                lblPwlTitle.Text = "Password doesn't  match";
				lblPwlTitle.IsVisible = true;
				lblEmailTitle.IsVisible = false;
				lblNameTitle.IsVisible = false;
				lblConfirmPwTitle.IsVisible = false;
            }
            else
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
                    database.AddLocalUser(Response.data.email, Response.data.access_token);
                    Navigation.PushAsync(new movies.moviesPage(new Sqlite.DataAccess())).ConfigureAwait(false);
                }
            }
        }

        public void ShowAlert(string title, string content)
        {
            DisplayAlert(title, content, "OK");
        }
    }
}
