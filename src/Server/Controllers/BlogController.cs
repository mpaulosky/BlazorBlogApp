// ============================================
// Copyright (c) 2023. All rights reserved.
// File Name :     BlogController.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : BlazorBlogApp
// Project Name :  BlazorBlog.Server
// =============================================

namespace BlazorBlog.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BlogController : Controller
{
	private readonly IBlogPostRepository _blogPostRepository;

	public BlogController(IBlogPostRepository blogPostRepository)
	{
		_blogPostRepository = blogPostRepository;
	}

	[HttpGet]
	public ActionResult<List<BlogPost>> GetBlogPosts()
	{
		return _blogPostRepository.GetAllBlogPosts().ToList();
	}

	[HttpGet("{url}")]
	public ActionResult<BlogPost?> GetBlogPostByUrl(string url)
	{
		return string.IsNullOrWhiteSpace(url)
			? NotFound("This post does not exist.")
			: _blogPostRepository.GetBlogPostByUrl(url);
	}

	[HttpPost]
	public async Task<ActionResult<BlogPost>> CreateNewBlogPost(BlogPost? blogPost)
	{
		return blogPost == null
			? BadRequest($"This is a bad request the {nameof(blogPost)} is null!")
			: await _blogPostRepository.CreateNewBlogPostAsync(blogPost);
	}
}