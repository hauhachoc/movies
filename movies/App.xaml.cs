using movies.Data;
using movies.Sqlite;
using Xamarin.Forms;

namespace movies
{
    public partial class App : Application
    {
        public static BaseUserManager userManager { get; private set; }

        DataAccess db;

        public App()
        {
            db = new DataAccess();
            userManager = new BaseUserManager(new RestService());
            MainPage = new NavigationPage(new moviesPage(db));
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
