// ============================================
// Copyright (c) 2023. All rights reserved.
// File Name :     BlogRepository.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : BlazorBlogApp
// Project Name :  BlazorBlog.Server
// =============================================

namespace BlazorBlog.Shared.Data;

/// <summary>
/// Class representing the Blog repository
/// </summary>
public class BlogPostRepository : IBlogPostRepository
{
	private readonly IMongoCollection<BlogPost> _collection;

	/// <summary>
	///   BlogPostRepository constructor
	/// </summary>
	/// <param name="context">IMongoDbContext</param>
	/// <exception cref="ArgumentNullException"></exception>
	public BlogPostRepository(IMongoDbContextFactory context)
	{
		ArgumentNullException.ThrowIfNull(context);

		string collectionName = GetCollectionName(nameof(BlogPost));

		_collection = context.GetCollection<BlogPost>(collectionName);
	}

	/// <summary>
	///   Archive BlogPost method
	/// </summary>
	/// <param name="post"></param>
	/// <returns></returns>
	public async Task ArchiveAsync(BlogPost post)
	{
		// Archive the post
		post.IsDeleted = true;

		await UpdateAsync(post.Id, post);
	}

	/// <summary>
	///   Create BlogPost method
	/// </summary>
	/// <param name="post">BlogPost</param>
	public async Task<BlogPost> CreateAsync(BlogPost post)
	{
		await _collection.InsertOneAsync(post);
		return post;
	}

	/// <summary>
	///   Get BlogPost by Id method
	/// </summary>
	/// <param name="itemId">string</param>
	/// <returns>Task of BlogPost</returns>
	public async Task<BlogPost> GetAsync(string? itemId)
	{
		ObjectId objectId = new(itemId);

		FilterDefinition<BlogPost>? filter = Builders<BlogPost>.Filter.Eq("_id", objectId);

		BlogPost? result = (await _collection.FindAsync(filter)).FirstOrDefault();

		return result;
	}

	/// <summary>
	///   Get BlogPost by Url method
	/// </summary>
	/// <param name="url">string</param>
	/// <returns>Task of BlogPost</returns>
	public async Task<BlogPost> GetByUrlAsync(string url)
	{
		FilterDefinition<BlogPost>? filter = Builders<BlogPost>.Filter.Eq("url", url);

		BlogPost? result = (await _collection.FindAsync(filter)).FirstOrDefault();

		return result;
	}

	/// <summary>
	///   Get BlogPosts method
	/// </summary>
	/// <returns>Task of IEnumerable BlogPost</returns>
	public async Task<IEnumerable<BlogPost>> GetAllAsync()
	{
		FilterDefinition<BlogPost>? filter = Builders<BlogPost>.Filter.Empty;

		List<BlogPost>? result = (await _collection.FindAsync(filter)).ToList();

		return result;
	}

	/// <summary>
	///   Update BlogPost method
	/// </summary>
	/// <param name="itemId">string</param>
	/// <param name="post">BlogPost</param>
	public async Task UpdateAsync(string? itemId, BlogPost post)
	{
		ObjectId objectId = new(itemId);

		FilterDefinition<BlogPost>? filter = Builders<BlogPost>.Filter.Eq("_id", objectId);

		await _collection.ReplaceOneAsync(filter, post);
	}
}