using System;
using System.IO;
using SQLite;
using movies.iOS;
using Xamarin.Forms;
using movies.Sqlite;

[assembly: Dependency(typeof(SqliteService))]
namespace movies.iOS
{
	public class SqliteService : ISQLite
	{
		public SqliteService()
		{
		}
		#region ISQLite implementation

		public SQLite.Net.SQLiteConnection GetConnection()
		{
			var fileName = "Movies.db3";
			var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
			var libraryPath = Path.Combine(documentsPath, "..", "Library");
			var path = Path.Combine(libraryPath, fileName);

			var platform = new SQLite.Net.Platform.XamarinIOS.SQLitePlatformIOS();
			var connection = new SQLite.Net.SQLiteConnection(platform, path);

			return connection;
		}

		#endregion
	}
}