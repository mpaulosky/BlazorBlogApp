﻿// ============================================
// Copyright (c) 2023. All rights reserved.
// File Name :     DtoToDomain.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : BlazorBlogApp
// Project Name :  BlazorBlog.Shared
// =============================================

namespace BlazorBlog.Shared.Mapping;

public static class DtoToBlogPostMapper
{
	public static BlogPost ToBlogPost(this BlogPostDto post)
	{
		return new BlogPost
		{
			Url = post.Url,
			Title = post.Title,
			Content = post.Content,
			Author = post.Author,
			Description = post.Description,
			Image = post.Image!,
			IsDeleted = post.IsDeleted,
			Created = post.Created,
		};
	}
}