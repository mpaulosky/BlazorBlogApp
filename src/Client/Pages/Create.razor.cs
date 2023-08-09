// ============================================
// Copyright (c) 2023. All rights reserved.
// File Name :     Create.razor.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : BlazorBlogApp
// Project Name :  BlazorBlog.Client
// =============================================

using Microsoft.AspNetCore.Components.Forms;

namespace BlazorBlog.Client.Pages;

public partial class Create
{
	private readonly BlogPostDto _newBlogPost = new();

	private async Task CreateBlogPost()
	{
		var newPost = new BlogPost
		{
			Title = _newBlogPost.Title,
			Url = _newBlogPost.Url,
			Description = _newBlogPost.Description,
			Content = _newBlogPost.Content,
			Author = _newBlogPost.Author,
			Created = _newBlogPost.Created,
			IsPublished = _newBlogPost.IsPublished,
			Image = _newBlogPost.Image
		};
		var result = await BlogService.CreateNewBlogPost(newPost);
		NavigationManager.NavigateTo($"posts/{result!.Url}");
	}

	public async Task OnFileChange(InputFileChangeEventArgs e)
	{
		const string format = "image/png";
		var resizeImage = await e.File.RequestImageFileAsync(format, 300, 300);
		var buffer = new byte[resizeImage.Size];
		_ = await resizeImage.OpenReadStream().ReadAsync(buffer);
		var imageData = $"data:{format};base64,{Convert.ToBase64String(buffer)}";
		_newBlogPost.Image = imageData;
	}
}