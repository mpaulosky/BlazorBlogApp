// ============================================
// Copyright (c) 2023. All rights reserved.
// File Name :     BlogRepository.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : BlazorBlogApp
// Project Name :  BlazorBlog.Server
// =============================================

namespace BlazorBlog.Shared.Data;

public interface IBlogPostRepository
{
	Task ArchiveAsync(BlogPost post);
	Task<BlogPost> CreateAsync(BlogPost post);
	Task<IEnumerable<BlogPost>> GetAllAsync();
	Task<BlogPost> GetAsync(string? itemId);
	Task<BlogPost> GetByUrlAsync(string url);
	Task UpdateAsync(string? itemId, BlogPost post);
}