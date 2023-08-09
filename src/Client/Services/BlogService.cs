// ============================================
// Copyright (c) 2023. All rights reserved.
// File Name :     BlogService.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : BlazorBlogApp
// Project Name :  BlazorBlog.Client
// =============================================

using Flurl;

namespace BlazorBlog.Client.Services;

public class BlogService : IBlogService
{
	private readonly IFlurlClient _client;

	public BlogService(PerBaseUrlFlurlClientFactory perBaseUrlFlurlClientFactory, Url baseUrl)
	{
		_client = perBaseUrlFlurlClientFactory.Get(new Url(baseUrl.ToString()));
	}

	public async Task<List<BlogPost>?> GetBlogPosts()
	{
		return await _client.Request()
			.AppendPathSegment("api")
			.AppendPathSegment("blog")
			.GetJsonAsync<List<BlogPost>>();
	}

	public async Task<BlogPost?> GetBlogPostByUrl(string url)
	{
		var result = await _client.Request()
			.AppendPathSegment("api")
			.AppendPathSegment("blog")
			.AppendPathSegment($"{url}")
			.GetAsync();

		return result.StatusCode == 200 ? await result.GetJsonAsync<BlogPost>() : null;
	}

	public async Task<BlogPost?> CreateNewBlogPost(BlogPost blogPost)
	{
		var result = await _client.Request()
			.AppendPathSegment("api")
			.AppendPathSegment("blog")
			.PostJsonAsync(blogPost);

		return result.StatusCode == 201 ? await result.GetJsonAsync<BlogPost>() : null;
	}
}