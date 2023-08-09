// ============================================
// Copyright (c) 2023. All rights reserved.
// File Name :     Posts.razor.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : BlazorBlogApp
// Project Name :  BlazorBlog.Client
// =============================================

using Microsoft.AspNetCore.Components;

namespace BlazorBlog.Client.Pages;

public partial class Posts
{
	private BlogPost? _post;
	private const string PlaceholderImage = "https://via.placeholder.com/1060x300";
	[Parameter] public string? Url { get; set; }

	protected override async Task OnInitializedAsync()
	{
		_post = await BlogService.GetBlogPostByUrl(Url ?? throw new InvalidOperationException());
	}
}