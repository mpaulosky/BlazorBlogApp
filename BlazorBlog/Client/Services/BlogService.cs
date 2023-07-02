using System.Net.Http.Json;

using BlazorBlog.Client.Pages;
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
		ArgumentException.ThrowIfNullOrEmpty(url, nameof(url));

		var post = await _httpClient.GetFromJsonAsync<BlogPost?>($"api/blog/{url}");

		return post;
	}
}