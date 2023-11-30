// ============================================
// Copyright (c) 2023. All rights reserved.
// File Name :     GetBlogPostsTests.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : IssueTracker
// Project Name :  IssueTracker.PlugIns.Tests.Integration
// =============================================

using BlazorBlog.Shared.FakerCreators;

namespace BlazorBlog.Server.DataAccess;

[ExcludeFromCodeCoverage]
[Collection("Test Collection")]
public class GetBlogPostsTests : IAsyncLifetime
{
	private const string CleanupValue = "posts";

	private readonly IntegrationTestFactory _factory;
	private readonly BlogPostRepository _sut;

	public GetBlogPostsTests(IntegrationTestFactory factory)
	{
		_factory = factory;
		IMongoDbContextFactory context = _factory.Services.GetRequiredService<IMongoDbContextFactory>();
		_sut = new BlogPostRepository(context);
	}

	public Task InitializeAsync()
	{
		return Task.CompletedTask;
	}

	public async Task DisposeAsync()
	{
		await _factory.ResetCollectionAsync(CleanupValue);
	}

	[Fact(DisplayName = "GetAllAsync BlogPosts With Valid Data Should Succeed")]
	public async Task GetAllAsync_With_ValidData_Should_ReturnBlogPosts_Test()
	{
		// Arrange
		BlogPost expected = BlogPostCreator.GetNewBlogPost();
		await _sut.CreateAsync(expected);

		// Act
		List<BlogPost> results = (await _sut.GetAllAsync()).ToList();

		// Assert
		results.Count.Should().Be(1);
		results.Last().Should().BeEquivalentTo(expected,
			options => options
				.Excluding(t => t.Id)
				.Excluding(t => t.Created)
				.Excluding(x => x.Updated));
	}
}