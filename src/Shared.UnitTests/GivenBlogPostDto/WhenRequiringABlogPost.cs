// ============================================
// Copyright (c) 2023. All rights reserved.
// File Name :     WhenRequiringABlogPost.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : BlazorBlogApp
// Project Name :  Shared.UnitTests
// =============================================

using BlazorBlog.Shared.FakerCreators;
using BlazorBlog.Shared.Mapping;

namespace Shared.UnitTests.GivenBlogPostDto;

[ExcludeFromCodeCoverage]
public class WhenRequiringABlogPost
{
	[Fact]
	public void ShouldConvertBlogPostDtoToBlogPost_Test()
	{
		// Arrange
		BlogPostDto expectedDto = BlogPostDtoCreator.GetNewBlogPostDto()!;

		// Act
		BlogPost result = expectedDto.ToBlogPost();

		// Assert
		result.Should().BeEquivalentTo(expectedDto,
			options => options
				.Excluding(t => t.Created)
				.Excluding(t => t.IsPublished));
	}

	[Fact]
	public void ShouldConvertBlogPostDtoToBlogPostWithNewSeed_Test()
	{
		// Arrange
		BlogPostDto expectedDto = BlogPostDtoCreator.GetNewBlogPostDto(true)!;

		// Act
		BlogPost result = expectedDto.ToBlogPost();

		// Assert
		result.Should().BeEquivalentTo(expectedDto,
			options => options
				.Excluding(t => t.Created)
				.Excluding(t => t.IsPublished));
	}
}