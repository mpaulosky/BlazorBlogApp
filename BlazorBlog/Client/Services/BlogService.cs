using BlazorBlog.Shared;

namespace BlazorBlog.Client.Services;

public class BlogService : IBlogService
{

	private List<BlogPost> Posts { get; set; } = new();

	public List<BlogPost> GetBlogPosts()
	{
		Posts = BlogPostCreator.GetBlogPosts(3);

		return Posts;
	}

	public BlogPost? GetBlogPostByUrl(string? url)
	{
		return string.IsNullOrWhiteSpace(url)
			? null
			: Posts.FirstOrDefault(x => string.Equals(x.Url.ToLower(),
				url.ToLower(),
				StringComparison.Ordinal));
	}
}