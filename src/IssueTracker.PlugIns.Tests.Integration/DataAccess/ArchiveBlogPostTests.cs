// ============================================
// Copyright (c) 2023. All rights reserved.
// File Name :     ArchiveBlogPostTests.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : IssueTracker
// Project Name :  IssueTracker.PlugIns.Tests.Integration
// =============================================

using BlazorBlog.Shared.FakerCreators;

namespace BlazorBlog.Server.DataAccess;

[ExcludeFromCodeCoverage]
[Collection("Test Collection")]
public class ArchiveBlogPostTests : IAsyncLifetime
{
	private const string CleanupValue = "posts";

	private readonly IntegrationTestFactory _factory;
	private readonly BlogPostRepository _sut;

	public ArchiveBlogPostTests(IntegrationTestFactory factory)
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

	[Fact(DisplayName = "Archive BlogPost With Valid Data (Archive)")]
	public async Task ArchiveAsync_With_ValidData_Should_ArchiveABlogPost_TestAsync()
	{
		// Arrange
		BlogPost expected = BlogPostCreator.GetNewBlogPost();

		await _sut.CreateAsync(expected);

		// Act
		await _sut.ArchiveAsync(expected);

		BlogPost result = await _sut.GetAsync(expected.Id);

		// Assert
		result.Should().NotBeNull();
		result.Id.Should().Be(expected.Id);
		result.IsDeleted.Should().BeTrue();
	}
}