using System;
using System.Collections.Generic;

namespace movies.Models.Response
{
    public class FilmsResponse
    {
		public bool error { get; set; }
		public int code { get; set; }
		public string message { get; set; }
		public Paging paging { get; set; }
		public IList<Film> data { get; set; }

		public FilmsResponse()
		{
		}
    }
}
