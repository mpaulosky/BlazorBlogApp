namespace BlazorBlog.Shared.Mapping;

public static class BlogPostToDtoMapper
{
	public static BlogPostDto ToBlogPostDto(this BlogPost post)
	{
		return new BlogPostDto
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