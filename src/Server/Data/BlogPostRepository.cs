// ============================================
// Copyright (c) 2023. All rights reserved.
// File Name :     BlogRepository.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : BlazorBlogApp
// Project Name :  BlazorBlog.Server
// =============================================

namespace BlazorBlog.Server.Data;

/// <summary>
/// Class representing the Blog repository
/// </summary>
public class BlogPostRepository : IBlogPostRepository
{
	private readonly DataContext _context;

	/// <summary>
	/// Constructor for Blog repository
	/// </summary>
	/// <param name="context">The data context used for the repository</param>
	public BlogPostRepository(DataContext context)
	{
		_context = context;
	}

	/// <summary>
	/// Gets all the blog posts
	/// </summary>
	/// <returns>An enumerable of all the blogs posts</returns>
	public IEnumerable<BlogPost> GetAllBlogPosts()
	{
		return _context.BlogPosts.AsNoTracking();
	}

	/// <summary>
	/// Gets the specific blog post with the supplied URL
	/// </summary>
	/// <param name="url">The URL of the blog post</param>
	/// <returns>The blog post with the supplied URL</returns>
	public BlogPost? GetBlogPostByUrl(string url)
	{
		var posts = _context.BlogPosts.AsNoTracking();

		var result = posts.FirstOrDefault(x =>
			string.Equals(x.Url.ToLower(), url.ToLower(), StringComparison.Ordinal));

		return result;
	}

	/// <summary>
	/// Creates a new blog post
	/// </summary>
	/// <param name="blogPost">The new blog post to create</param>
	/// <returns>The newly created blog post</returns>
	public async Task<BlogPost> CreateNewBlogPostAsync(BlogPost blogPost)
	{
		_context.BlogPosts.Add(blogPost);
		await _context.SaveChangesAsync();
		return blogPost;
	}
}