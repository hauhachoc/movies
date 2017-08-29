using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using movies.Models;
using movies.Models.Response;
using movies.Utils;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace movies.Data
{
	public class RestService : IRestService
	{
		public HttpClient client;

		public BaseUser Item { get; private set; }

		public BaseResponse Response { get; private set; }
		public IList<Film> films;
		public FilmsResponse filmsRes;

		public RestService()
		{
			client = new HttpClient();
			//client.MaxResponseContentBufferSize = 256000;
			//client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authHeaderValue);
		}

		public async Task<FilmsResponse> GetFilmsItemAsync(string pagee, string per_pagee)
		{
			var uri = new Uri(string.Format(Constants.RestUrl + Constants.films_url, string.Empty));
			try
			{
				var json = JsonConvert.SerializeObject(new
				{
					page = pagee,
					per_page = per_pagee
				});
				Debug.WriteLine(@"             json:" + json.ToString());
				HttpResponseMessage response;
				var values = new Dictionary<string, string>();
				values.Add("page", pagee);
				values.Add("per_page", per_pagee);
				var content = new FormUrlEncodedContent(values);

				if (Application.Current.Properties.ContainsKey("token"))
				{
					string token = Application.Current.Properties["token"] as string;
					content.Headers.Add("access_token", token);
				}
				content.Headers.Add("app_token", Constants.token);
				response = await client.PostAsync(uri, content).ConfigureAwait(false);


				if (response.IsSuccessStatusCode)
				{
					var data = await response.Content.ReadAsStringAsync();
					Debug.WriteLine(@"             data:" + data.ToString());
					filmsRes = JsonConvert.DeserializeObject<FilmsResponse>(data);

					return filmsRes;
				}
				else
				{
					Debug.WriteLine(@"" + response.RequestMessage.RequestUri.ToString());
				}

			}
			catch (Exception ex)
			{
				Debug.WriteLine(@"             ERROR {0}", ex.Message);
			}

			return filmsRes;
		}

		public async Task<BaseResponse> RegisterItemAsync(BaseUser item)
		{
			var uri = new Uri(string.Format(Constants.RestUrl + Constants.register_url, string.Empty));
			try
			{
				var json = JsonConvert.SerializeObject(item);
				Debug.WriteLine(@"             json:" + json.ToString());
				var content = new FormUrlEncodedContent(new[] {
					new KeyValuePair<string, string>("full_name",item.full_name),
					new KeyValuePair<string, string>("email", item.email),
					new KeyValuePair<string, string>("password", item.password)
				});
				content.Headers.Add("app_token", Constants.token);
				HttpResponseMessage response = await client.PostAsync(uri, content).ConfigureAwait(false);

				if (response.IsSuccessStatusCode)
				{
					var data = await response.Content.ReadAsStringAsync();
					Debug.WriteLine(@"             data:" + data.ToString());
					Response = JsonConvert.DeserializeObject<BaseResponse>(data);

					return Response;
				}
				else
				{
					Debug.WriteLine(@"" + response.RequestMessage.RequestUri.ToString());
				}

			}
			catch (Exception ex)
			{
				Debug.WriteLine(@"             ERROR {0}", ex.Message);
			}

			return Response;
		}

		public async Task<BaseResponse> LoginItemAsync(string mail, string pw)
		{
			var uri = new Uri(string.Format(Constants.RestUrl + Constants.login_url, string.Empty));
			try
			{
				var json = JsonConvert.SerializeObject(new { email = mail, password = pw });
				Debug.WriteLine(@"             json:" + json.ToString());
				var content = new FormUrlEncodedContent(new[] {
					new KeyValuePair<string, string>("email",mail),
					new KeyValuePair<string, string>("password", pw)});
				content.Headers.Add("app_token", Constants.token);

				HttpResponseMessage response = null;

				response = await client.PostAsync(uri, content).ConfigureAwait(false);
				Debug.WriteLine(@"             content:" + response.ToString());

				if (response.IsSuccessStatusCode)
				{
					var data = await response.Content.ReadAsStringAsync();
					Debug.WriteLine(@"             data:" + data.ToString());
					Response = JsonConvert.DeserializeObject<BaseResponse>(data);

					return Response;
				}
				else
				{
					Debug.WriteLine(@"" + response.RequestMessage.RequestUri.ToString());
				}

			}
			catch (Exception ex)
			{
				Debug.WriteLine(@"             ERROR {0}", ex.Message);
			}

			return Response;
		}
	}
}
