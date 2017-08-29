using System;
using Newtonsoft.Json;

namespace movies.Models.Response
{
    public class Paging
    {
		[JsonProperty("total_item")]
		public int total_item { get; set; }

		[JsonProperty("per_page")]
		public int per_page { get; set; }

		[JsonProperty("current_page")]
		public int current_page { get; set; }

		[JsonProperty("total_pages")]
		public int total_pages { get; set; }

		public Paging()
		{
		}
    }
}
