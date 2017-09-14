using System;
using Newtonsoft.Json;

namespace movies.Models.Response
{
    public class BaseResponse
    {
		[JsonProperty("error")]
		public Boolean error { get; set; }

		[JsonProperty("code")]
		public int code { get; set; }

		[JsonProperty("message")]
        public String message { get; set; }

		[JsonProperty("data")]
		public UserResponse data { get; set; }

		public BaseResponse()
		{
		}
    }
}
