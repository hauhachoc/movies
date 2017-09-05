using System;
using Newtonsoft.Json;

namespace movies.Models
{
    public class BaseRes
    {
		[JsonProperty("error")]
		public Boolean error { get; set; }

		[JsonProperty("code")]
		public int code { get; set; }

		[JsonProperty("message")]
		public string message { get; set; }
		
        public BaseRes()
        {
        }
    }
}
