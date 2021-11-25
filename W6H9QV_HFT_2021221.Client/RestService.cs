using System;
using System.Collections.Generic;
using System.Net.Http;

namespace W6H9QV_HFT_2021221.Client
{
	class RestService
	{
		HttpClient client;

		public RestService(string baseurl)
		{
			Init(baseurl);
		}

		private void Init(string baseurl)
		{
			client = new HttpClient();
			client.BaseAddress = new Uri(baseurl);
			client.DefaultRequestHeaders.Accept.Clear();
			client.DefaultRequestHeaders.Accept.Add(
				new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue
				("application/json"));
			try
			{
				client.GetAsync("").GetAwaiter().GetResult();
			}
			catch (HttpRequestException)
			{
				throw new ArgumentException("Endpoint is not available!");
			}
		}

		public List<T> Get<T>()
		{
			var type = typeof(T).Name.ToLower();
			List<T> items = new List<T>();
			HttpResponseMessage response = client.GetAsync(type).GetAwaiter().GetResult();
			if (response.IsSuccessStatusCode)
			{
				items = response.Content.ReadAsAsync<List<T>>().GetAwaiter().GetResult();
			}
			return items;
		}

		public T Get<T>(object idOrName)
		{
			T item = default(T);
			var type = typeof(T).Name.ToLower();
			HttpResponseMessage response;
			if (idOrName.GetType() == typeof(int))
				response = client.GetAsync(type + "/id/" + ((int)idOrName).ToString()).GetAwaiter().GetResult();
			else
				response = client.GetAsync(type + "/nm/" + (string)idOrName).GetAwaiter().GetResult();
			if (response.IsSuccessStatusCode)
			{
				item = response.Content.ReadAsAsync<T>().GetAwaiter().GetResult();
			}
			return item;
		}

		public void Post<T>(T item, string endpoint)
		{
			HttpResponseMessage response =
				client.PostAsJsonAsync(endpoint, item).GetAwaiter().GetResult();

			response.EnsureSuccessStatusCode();
		}

		public void Delete(int id, string endpoint)
		{
			HttpResponseMessage response =
				client.DeleteAsync(endpoint + "/" + id.ToString()).GetAwaiter().GetResult();

			response.EnsureSuccessStatusCode();
		}

		public void Put<T>(T item)
		{
			HttpResponseMessage response =
				client.PutAsJsonAsync(typeof(T).Name, item).GetAwaiter().GetResult();

			response.EnsureSuccessStatusCode();
		}

		public void PutName<T>(object idOrName, string newName)
		{
			var type = typeof(T).Name.ToLower();
			HttpResponseMessage response;
			if (idOrName.GetType() == typeof(int))
				response = client.PutAsJsonAsync(type + "/nameid/" + ((int)idOrName).ToString() + "/" + newName,
					newName).GetAwaiter().GetResult();
			else response = client.PutAsJsonAsync(type + "/namenm/" + (string)idOrName + "/" + newName,
					newName).GetAwaiter().GetResult();

			response.EnsureSuccessStatusCode();
		}
	}
}
