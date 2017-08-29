using System;
namespace movies.Models.Response
{
    public class UserResponse
    {
		public string updated_at { set; get; }
		public string email { set; get; }
		public string full_name { set; get; }
		public string gender { set; get; }
		public string birthday { set; get; }
		public string id { set; get; }
		public string access_token { set; get; }
		public string password { set; get; }
		public string created_at { set; get; }
		public UserResponse()
		{
		}
    }
}
