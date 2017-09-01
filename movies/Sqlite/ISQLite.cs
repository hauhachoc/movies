using System;
using SQLite.Net;

namespace movies.Sqlite
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection();
    }
}
