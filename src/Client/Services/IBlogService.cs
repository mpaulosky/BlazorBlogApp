// ============================================
// Copyright (c) 2023. All rights reserved.
// File Name :     IBlogService.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : BlazorBlogApp
// Project Name :  BlazorBlog.Client
// =============================================

namespace BlazorBlog.Client.Services;

public interface IBlogService
{
	Task<List<BlogPost>?> GetBlogPosts();

	Task<BlogPost?> GetBlogPostByUrl(string url);

	Task<BlogPost?> CreateNewBlogPost(BlogPost blogPost);
}