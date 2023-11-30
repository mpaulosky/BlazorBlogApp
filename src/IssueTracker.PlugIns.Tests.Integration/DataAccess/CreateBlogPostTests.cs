// ============================================
// Copyright (c) 2023. All rights reserved.
// File Name :     CreateBlogPostTests.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : IssueTracker
// Project Name :  IssueTracker.PlugIns.Tests.Integration
// =============================================

using BlazorBlog.Shared.FakerCreators;

namespace BlazorBlog.Server.DataAccess;

[ExcludeFromCodeCoverage]
[Collection("Test Collection")]
public class CreateBlogPostTests : IAsyncLifetime
{
	private const string CleanupValue = "posts";

	private readonly IntegrationTestFactory _factory;
	private readonly BlogPostRepository _sut;

	public CreateBlogPostTests(IntegrationTestFactory factory)
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

	[Fact(DisplayName = "CreateAsync BlogPost With Valid Data Should Succeed")]
	public async Task CreateAsync_With_ValidData_Should_CreateABlogPost_TestAsync()
	{
		// Arrange
		BlogPost expected = BlogPostCreator.GetNewBlogPost();

		// Act
		await _sut.CreateAsync(expected);

		// Assert
		expected.Id.Should().NotBeNull();
	}

	[Fact(DisplayName = "CreateAsync BlogPost With In Valid Data Should Fail")]
	public async Task CreateAsync_With_InValidData_Should_FailToCreateABlogPost_TestAsync()
	{
		// Arrange

		// Act

		// Assert
		await Assert.ThrowsAsync<ArgumentNullException>(() => _sut.CreateAsync(null!));
	}
}