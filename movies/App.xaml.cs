using movies.Data;
using Xamarin.Forms;

namespace movies
{
    public partial class App : Application
    {
        public static BaseUserManager userManager { get; private set; } 
        public App()
        {
            userManager = new BaseUserManager(new RestService());
			MainPage = new NavigationPage(new Views.LoginPage()) ;
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
