using System;
using Newtonsoft.Json;

namespace movies.Models.Response
{
    public class Film
    {
		[JsonProperty("id")]
		public int id { get; set; }

		[JsonProperty("title")]
		public string title { get; set; }

		[JsonProperty("image")]
		public string image { get; set; }

		[JsonProperty("link")]
		public string link { get; set; }

		[JsonProperty("description")]
		public string description { get; set; }

		[JsonProperty("category")]
		public string category { get; set; }

		[JsonProperty("actor")]
		public string actor { get; set; }

		[JsonProperty("director")]
		public string director { get; set; }

		[JsonProperty("manufacturer")]
		public string manufacturer { get; set; }

		[JsonProperty("duration")]
		public string duration { get; set; }

		[JsonProperty("year")]
		public string year { get; set; }

		[JsonProperty("created_at")]
		public string created_at { get; set; }

		[JsonProperty("updated_at")]
		public string updated_at { get; set; }

		[JsonProperty("views")]
		public int views { get; set; }

		[JsonProperty("type")]
		public string type { get; set; }

		public Film()
		{
		}
    }
}
