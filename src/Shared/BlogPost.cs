﻿// ============================================
// Copyright (c) 2023. All rights reserved.
// File Name :     BlogPost.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : BlazorBlogApp
// Project Name :  BlazorBlog.Shared
// =============================================

using MongoDB.Bson.Serialization.Attributes;

namespace BlazorBlog.Shared;

/// <summary>
/// Class for storing data for a blog post.
/// </summary>
[Serializable]
public class BlogPost
{
	/// <summary>
	/// Gets or sets the ID of the blog post.
	/// </summary>
	[BsonId]
	[BsonRepresentation(BsonType.ObjectId)]
	public string Id { get; set; } = string.Empty;

	/// <summary>
	/// Gets or sets the URL of the blog post.
	/// </summary>
	[BsonElement("url")]
	[BsonRepresentation(BsonType.String)]
	public string Url { get; set; } = string.Empty;

	/// <summary>
	/// Gets or sets the title of the blog post.
	/// </summary>
	[BsonElement("title")]
	[BsonRepresentation(BsonType.String)]
	public string Title { get; set; } = string.Empty;

	/// <summary>
	/// Gets or sets the content of the blog post.
	/// </summary>
	[BsonElement("content")]
	[BsonRepresentation(BsonType.String)]
	public string Content { get; set; } = string.Empty;

	/// <summary>
	/// Gets or sets the date the blog post was created.
	/// </summary>
	[BsonElement("date_created")]
	[BsonRepresentation(BsonType.DateTime)]
	public DateTime Created { get; set; } = DateTime.Now;

	/// <summary>
	/// Gets or sets the date the blog post was updated.
	/// </summary>
	[BsonElement("date_updated")]
	[BsonRepresentation(BsonType.DateTime)]
	public DateTime? Updated { get; set; }

	/// <summary>
	/// Gets or sets the name of the author of the blog post.
	/// </summary>
	[BsonElement("author")]
	[BsonRepresentation(BsonType.String)]
	public string Author { get; set; } = string.Empty;

	/// <summary>
	/// Gets or sets the description for the blog post.
	/// </summary>
	[BsonElement("description")]
	[BsonRepresentation(BsonType.String)]
	public string Description { get; set; } = string.Empty;

	/// <summary>
	/// Gets or sets the image associated with the blog post.
	/// </summary>
	[BsonElement("image")]
	[BsonRepresentation(BsonType.String)]
	public string? Image { get; set; } = string.Empty;

	/// <summary>
	/// Gets or sets a value indicating whether the blog post is published.
	/// </summary>
	[BsonElement("ispublished")]
	[BsonRepresentation(BsonType.Boolean)]
	public bool IsPublished { get; set; } = true;

	/// <summary>
	/// Gets or sets a value indicating whether the blog post has been deleted.
	/// </summary>
	[BsonElement("isdeleted")]
	[BsonRepresentation(BsonType.Boolean)]
	public bool IsDeleted { get; set; }
}