using System;
namespace movies.Utils
{
    public static class Constants
    {
		// URL of REST service
		public static string RestUrl = "http://dev.bsp.vn:8081/training-movie/";

		public static string register_url = "user/registry";
		public static string login_url = "user/login";
		public static string films_url = "movie/list";
		// Credentials that are hard coded into the REST service
		public static string token = "dCuW7UQMbdvpcBDfzolAOSGFIcAec11a";
		public static string access_token = "";
    }
}
