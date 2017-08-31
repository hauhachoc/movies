using System;
using System.Collections.Generic;

namespace movies.Models.Response
{
    public class FilmsResponse : BaseViewModel
    {
		public bool error { get; set; }
		public int code { get; set; }
		public string message { get; set; }
		public Paging paging { get; set; }

        public IList<Film> data;
		public IList<Film> Data
		{
			get { return data; }
			set { this.ChangeAndNotify(ref data, value); }
		}

		public FilmsResponse()
		{
		}
    }
}
