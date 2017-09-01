using System.Collections.Generic;
using movies.Models;
using SQLite.Net;
using Xamarin.Forms;
using System.Linq;

namespace movies.Sqlite
{
    public class DataAccess
    {
		public SQLiteConnection _connection;

		public DataAccess()
		{
			_connection = DependencyService.Get<ISQLite>().GetConnection();
            _connection.CreateTable<LocalUser>();
		}

		public IEnumerable<LocalUser> GetLocalUser()
		{
			return (from t in _connection.Table<LocalUser>()
					select t);
		}

		public LocalUser GetLocalUser(int id)
		{
            return _connection.Table<LocalUser>().FirstOrDefault(t => t.id == id);
		}

		public void DeleteLocalUser(int id)
		{
			_connection.Delete<LocalUser>(id);
		}

		public void AddLocalUser(string em, string token)
		{
			var newLocalUser = new LocalUser
			{
                email = em,
                access_token = token
			};

			_connection.Insert(newLocalUser);
		}
	}
}