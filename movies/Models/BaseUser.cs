using System;
using Newtonsoft.Json;

namespace movies.Models
{
    public class BaseUser
    {
		[JsonProperty("email")]
		public string email { get; set; }

		[JsonProperty("password")]
		public string password { get; set; }

		[JsonProperty("full_name")]
		public string full_name { get; set; }

		[JsonProperty("gender")]
		public string gender { get; set; }

		[JsonProperty("birthday")]
		public string birthday { get; set; }

		public BaseUser(string fn, string em, string pw)
		{
			this.full_name = fn;
			this.email = em;
			this.password = pw;
			this.gender = "male";
			this.birthday = "1990-12-12";
		}

		public BaseUser()
		{
			this.email = "";
			this.password = "";
			this.full_name = "";
			this.gender = "";
			this.birthday = "";
		}
	}
}
