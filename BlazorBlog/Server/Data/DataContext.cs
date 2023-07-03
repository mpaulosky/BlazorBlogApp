using BlazorBlog.Shared;

using Microsoft.EntityFrameworkCore;

namespace BlazorBlog.Server.Data;

public class DataContext : DbContext
{
	public DataContext(DbContextOptions<DataContext> options) : base(options) { }
	
	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		var posts = BlogPostCreator.GetNewBlogPosts();
		
		modelBuilder.Entity<BlogPost>().HasData(posts);
	}

	public DbSet<BlogPost> BlogPosts { get; set; }
	
}