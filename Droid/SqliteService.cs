using System;
using Xamarin.Forms;
using movies.Droid;
using System.IO;
using movies.Sqlite;
using SQLite.Net;

[assembly: Dependency(typeof(SqliteService))]
namespace movies.Droid
{
    public class SqliteService : ISQLite
    {
        public SqliteService() { }


		#region ISQLite implementation

		public SQLite.Net.SQLiteConnection GetConnection()
		{
			var fileName = "Movies.db3";
			var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
			var path = Path.Combine(documentsPath, fileName);

			var platform = new SQLite.Net.Platform.XamarinAndroid.SQLitePlatformAndroid();
			var connection = new SQLite.Net.SQLiteConnection(platform, path);

			return connection;
		}

		#endregion
	}
}
