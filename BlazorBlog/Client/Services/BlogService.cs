using System.Net;
using System.Net.Http.Json;

using BlazorBlog.Shared;

namespace BlazorBlog.Client.Services;

public class BlogService : IBlogService
{
	private readonly HttpClient _httpClient;

	public BlogService(HttpClient httpClient)
	{
		_httpClient = httpClient;
	}

	public async Task<List<BlogPost>?> GetBlogPosts()
	{
		return await _httpClient.GetFromJsonAsync<List<BlogPost>>("api/blog");
	}

	public async Task<BlogPost?> GetBlogPostByUrl(string url)
	{
		var result = await _httpClient.GetAsync($"api/blog/{url}");
		if (result.StatusCode == HttpStatusCode.OK)
		{
			return await result.Content.ReadFromJsonAsync<BlogPost>();
		}

		const string message = "This post does not exist.";
		Console.WriteLine(message);
		return new BlogPost{Title = message};
	}
}