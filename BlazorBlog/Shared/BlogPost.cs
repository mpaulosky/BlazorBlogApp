namespace BlazorBlog.Shared;

public class BlogPost
{
	public int Id { get; set; }
	public string Url { get; set; } = "";
	public string Title { get; set; } = "";
	public string Content { get; set; }= "";
	public DateTime Created { get; set; }=DateTime.Now;
	public DateTime? Updated { get; set; }
	public string Author { get; set; } = "";
	public string Description { get; set; }= "";
	public string? ImageFileName { get; set; }
	public bool IsPublished { get; set; } = true;
	public bool IsDeleted { get; set; } = false;
	
}