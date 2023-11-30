// ============================================
// Copyright (c) 2023. All rights reserved.
// File Name :     GetCommentsByUserTests.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : IssueTracker
// Project Name :  IssueTracker.PlugIns.Tests.Integration
// =============================================

using BlazorBlog.Shared.FakerCreators;

namespace BlazorBlog.Server.DataAccess;

[ExcludeFromCodeCoverage]
[Collection("Test Collection")]
public class GetBlogPostByUrlTests : IAsyncLifetime
{
	private const string CleanupValue = "posts";
	private readonly IntegrationTestFactory _factory;
	private readonly BlogPostRepository _sut;

	public GetBlogPostByUrlTests(IntegrationTestFactory factory)
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

	[Fact(DisplayName = "GetByUserAsync With Valid Data Should Succeed")]
	public async Task GetByUserAsync_With_ValidData_Should_ReturnValidComment_Test()
	{
		// Arrange
		BlogPost expected = BlogPostCreator.GetNewBlogPost();
		await _sut.CreateAsync(expected);

		// Act
		var result = (await _sut.GetByUrlAsync(expected.Url));

		// Assert
		result.Should().NotBeNull();
		result.Should().BeEquivalentTo(expected,
			options => options
				.Excluding(t => t.Id)
				.Excluding(t => t.Created)
				.Excluding(x => x.Updated));
	}
}