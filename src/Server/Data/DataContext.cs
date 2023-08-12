// ============================================
// Copyright (c) 2023. All rights reserved.
// File Name :     DataContext.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : BlazorBlogApp
// Project Name :  BlazorBlog.Server
// =============================================

namespace BlazorBlog.Server.Data;

public class DataContext : DbContext
{
	public DataContext(DbContextOptions<DataContext> options) : base(options) { }

	public virtual DbSet<BlogPost> BlogPosts { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		//IEnumerable<BlogPost> posts = BlogPostCreator.GetNewBlogPosts(3);

		//modelBuilder.Entity<BlogPost>().HasData(posts);
	}
}