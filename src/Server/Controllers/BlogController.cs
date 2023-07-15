﻿using BlazorBlog.Shared;

using Microsoft.AspNetCore.Mvc;

namespace BlazorBlog.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BlogController : Controller
{
	private readonly DataContext _context;

	public BlogController(DataContext context)
	{
		_context = context;
	}

	[HttpGet]
	public ActionResult<List<BlogPost>> GetBlogPosts()
	{
		return Ok(_context.BlogPosts.OrderByDescending(x => x.Created));
	}

	[HttpGet("{url}")]
	public ActionResult<BlogPost?> GetBlogPostByUrl(string url)
	{
		if (string.IsNullOrWhiteSpace(url))
		{
			return NotFound("This post does not exist.");
		}

		BlogPost? post = _context.BlogPosts.FirstOrDefault(x => x.Url.ToLower() == url.ToLower());

		if (post == null)
		{
			return NotFound("This post does not exist.");
		}

		return post;
	}

	[HttpPost]
	public async Task<ActionResult<BlogPost>> CreateNewBlogPost(BlogPost blogPost)
	{
		await _context.BlogPosts.AddAsync(blogPost);
		await _context.SaveChangesAsync();

		return Ok(blogPost);
	}
}