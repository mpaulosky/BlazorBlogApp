// ============================================
// Copyright (c) 2023. All rights reserved.
// File Name :     BlogRepository.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : BlazorBlogApp
// Project Name :  BlazorBlog.Server
// =============================================

namespace BlazorBlog.Server.Data;

public interface IBlogPostRepository
{
	Task<BlogPost> CreateNewBlogPostAsync(BlogPost blogPost);
	IEnumerable<BlogPost> GetAllBlogPosts();
	BlogPost? GetBlogPostByUrl(string url);
}