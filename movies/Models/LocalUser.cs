using System;
using Newtonsoft.Json;
using SQLite.Net.Attributes;

namespace movies.Models
{
    public class LocalUser
    {

		[PrimaryKey, AutoIncrement]
		public int id { get; set; }

        [JsonProperty("email")]
        public string email { get; set; }

        [JsonProperty("password")]
        public string password { get; set; }

        [JsonProperty("full_name")]
        public string full_name { get; set; }

		[JsonProperty("access_token")]
		public string access_token { get; set; }

        public LocalUser(int Id, string fn, string em, string pw, string token)
        {
            this.id = Id;
            this.full_name = fn;
            this.email = em;
            this.password = pw;
			this.access_token = token;
        }

        public LocalUser()
        {
            this.email = "";
            this.password = "";
            this.full_name = "";
            this.access_token = "";
        }
    }
}
