// ============================================
// Copyright (c) 2023. All rights reserved.
// File Name :     GetBlogPostTests.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : IssueTracker
// Project Name :  IssueTracker.PlugIns.Tests.Integration
// =============================================

using BlazorBlog.Shared.FakerCreators;

namespace BlazorBlog.Server.DataAccess;

[ExcludeFromCodeCoverage]
[Collection("Test Collection")]
public class GetBlogPostTests : IAsyncLifetime
{
	private const string CleanupValue = "posts";

	private readonly IntegrationTestFactory _factory;
	private readonly BlogPostRepository _sut;

	public GetBlogPostTests(IntegrationTestFactory factory)
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

	[Fact(DisplayName = "GetAsync With Valid Data Should Succeed")]
	public async Task GetAsync_With_WithData_Should_Return_A_Valid_BlogPost_TestAsync()
	{
		// Arrange
		BlogPost expected = BlogPostCreator.GetNewBlogPost();
		await _sut.CreateAsync(expected);

		// Act
		BlogPost result = await _sut.GetAsync(expected.Id);

		// Assert
		result.Should().BeEquivalentTo(expected,
			options => options
				.Excluding(t => t.Id)
				.Excluding(t => t.Created)
				.Excluding(x => x.Updated));
	}

	[Theory(DisplayName = "GetAsync With In Valid Data Should Fail")]
	[InlineData("62cf2ad6326e99d665759e5a")]
	public async Task GetAsync_With_WithoutData_Should_Return_Nothing_TestAsync(string? value)
	{
		// Arrange

		// Act
		BlogPost result = await _sut.GetAsync(value!);

		// Assert
		result.Should().BeNull();
	}
}