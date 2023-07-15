﻿using BlazorBlog.Shared;

using Microsoft.EntityFrameworkCore;

namespace BlazorBlog.Server.Data;

public class DataContext : DbContext
{
	public DataContext(DbContextOptions<DataContext> options) : base(options) { }

	public DbSet<BlogPost> BlogPosts { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		IEnumerable<BlogPost> posts = BlogPostCreator.GetNewBlogPosts();

		modelBuilder.Entity<BlogPost>().HasData(posts);
	}
}