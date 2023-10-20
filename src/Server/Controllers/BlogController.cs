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
	public async Task<ActionResult<List<BlogPost>>> GetAllAsync()
	{
		return (await _blogPostRepository.GetAllAsync()).ToList();
	}

	[HttpGet("{url}")]
	public async Task<ActionResult<BlogPost?>> GetByUrlAsync(string url)
	{
		return string.IsNullOrWhiteSpace(url)
			? NotFound("This post does not exist.")
			: await _blogPostRepository.GetByUrlAsync(url);
	}

	[HttpPost]
	public async Task<ActionResult<BlogPost>> CreateAsync(BlogPost? blogPost)
	{
		return blogPost == null
			? BadRequest($"This is a bad request the {nameof(blogPost)} is null!")
			: await _blogPostRepository.CreateAsync(blogPost);
	}
}