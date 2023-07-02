using BlazorBlog.Shared;

using Microsoft.AspNetCore.Mvc;

namespace BlazorBlog.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BlogController : Controller
{
	private readonly List<BlogPost> _posts = BlogPostCreator.GetBlogPosts(3);

	[HttpGet]
	public ActionResult<List<BlogPost>> GetBlogPosts()
	{
		return Ok(_posts);
	}
	
	[HttpGet("{url}")]
	public ActionResult<BlogPost?> GetBlogPostByUrl(string? url)
	{
		return string.IsNullOrWhiteSpace(url)
			? NotFound("This post does not exist.")
			: Ok(_posts.FirstOrDefault(x => string.Equals(x.Url.ToLower(),
				url.ToLower(),
				StringComparison.Ordinal)));
	}
}