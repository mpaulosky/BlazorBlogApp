namespace BlazorBlog.Client.Shared;

public partial class BlogPosts
{
	private List<BlogPost>? Posts { get; set; } = new();

	const string PlaceHolderImage = "https://via.placeholder.com/1060x180";

	protected override async Task OnInitializedAsync()
	{
		Posts = await BlogService.GetBlogPosts();
	}
}