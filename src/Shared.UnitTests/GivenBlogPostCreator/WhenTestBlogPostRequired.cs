﻿// ============================================
// Copyright (c) 2023. All rights reserved.
// File Name :     WhenTestBlogPostRequired.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : BlazorBlogApp
// Project Name :  Shared.UnitTests
// =============================================

using BlazorBlog.Shared.FakerCreators;

namespace Shared.UnitTests.GivenBlogPostCreator;

[ExcludeFromCodeCoverage]
public class WhenTestBlogPostRequired
{
	[Fact]
	public void ShouldReturnNewBlogPostWithoutId_Test()
	{
		// Arrange
		BlogPost expected = BlogPostCreator.GetNewBlogPost()!;

		// Act
		BlogPost result = BlogPostCreator.GetNewBlogPost();

		// Assert
		result.Should().BeEquivalentTo(expected,
			options => options
				.Excluding(t => t.Created)
				.Excluding(t => t.Updated));
	}

	[Fact]
	public void ShouldReturnNewBlogPostWithId_Test()
	{
		// Arrange
		BlogPost expected = BlogPostCreator.GetNewBlogPost(true)!;

		// Act
		BlogPost result = BlogPostCreator.GetNewBlogPost(true);

		// Assert

		result.Should().BeEquivalentTo(expected,
			options => options
				.Excluding(t => t.Id)
				.Excluding(t => t.Created)
				.Excluding(t => t.Updated));
	}

	[Fact]
	public void ShouldReturnDifferentNewBlogPostWhenNewSeedIsTrue_Test()
	{
		// Arrange
		BlogPost expected = BlogPostCreator.GetNewBlogPost(true)!;

		// Act
		BlogPost result = BlogPostCreator.GetNewBlogPost(true, true);

		// Assert
		result.Should().NotBeEquivalentTo(expected);
	}

	[Fact]
	public void ShouldReturnAListOfNewBlogPosts_Test()
	{
		// Arrange
		List<BlogPost> expected = BlogPostCreator.GetNewBlogPosts(3)!;

		// Act
		IEnumerable<BlogPost> result = BlogPostCreator.GetNewBlogPosts(3);

		// Assert
		result.Should().BeEquivalentTo(expected,
			options => options
				.Excluding(t => t.Created)
				.Excluding(t => t.Updated));
	}

	[Fact]
	public void ShouldReturnAListOfBlogPosts_Test()
	{
		// Arrange
		IEnumerable<BlogPost> expected = BlogPostCreator.GetBlogPosts(3)!;

		// Act
		IEnumerable<BlogPost> result = BlogPostCreator.GetBlogPosts(3).ToList();

		// Assert
		result.First().Created.Should().BeBefore(DateTime.Today);
		result.First().Updated.Should().BeBefore(DateTime.Today);
		result.Should().BeEquivalentTo(expected,
			options => options
				.Excluding(t => t.Id)
				.Excluding(t => t.Created)
				.Excluding(t => t.Updated));
	}
}