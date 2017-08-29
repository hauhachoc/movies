using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace movies.Models.Response
{
    public class Message
    {
		[JsonProperty("email")]
		public IList<string> email { get; set; }

		[JsonProperty("password")]
		public IList<string> password { get; set; }

		[JsonProperty("full_name")]
		public IList<string> full_name { get; set; }

		public Message()
		{
		}
    }
}
