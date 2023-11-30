// ============================================
// Copyright (c) 2023. All rights reserved.
// File Name :     BlogControllerTests.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : BlazorBlogApp.Tests
// Project Name :  BlazorBlog.Server.Tests
// =============================================

using BlazorBlog.Shared.FakerCreators;

namespace Server.UnitTests;

[ExcludeFromCodeCoverage]
public class GivenABlogController
{
	private readonly Mock<IBlogPostRepository> _repositoryMock;
	private readonly IEnumerable<BlogPost> _expectedBlogPosts;
	private readonly BlogPost _expectedBlogPost;

	public GivenABlogController()
	{
		_expectedBlogPosts = BlogPostCreator.GetBlogPosts(3);
		_expectedBlogPost = BlogPostCreator.GetNewBlogPost(true);
		_repositoryMock = new Mock<IBlogPostRepository>();
	}

	private BlogController UnitUnderTest()
	{
		return new BlogController(_repositoryMock.Object);
	}

	[Fact]
	public async Task GetAllAsync_ReturnsCorrectResult()
	{
		// Arrange
		var sut = UnitUnderTest();
		SetupMocks();

		// Act
		var result = await sut.GetAllAsync();

		// Assert
		result.Value.Should().NotBeNull();
		result.Value.Should().BeEquivalentTo(_expectedBlogPosts,
			options => options
				.Excluding(t => t.Id)
				.Excluding(t => t.Created)
				.Excluding(x => x.Updated));

		_repositoryMock.Verify(x => x
			.GetAllAsync(), Times.Once);
	}

	[Fact]
	public async Task GetByUrlAsync_InvalidUrl_ReturnsNotFound()
	{
		// Arrange
		var sut = UnitUnderTest();
		SetupMocks();

		const string expectedMessage = "This post does not exist.";
		const string url = "";

		// Act
		var result = await sut.GetByUrlAsync(url);

		// Assert
		result.Result.Should().BeOfType<NotFoundObjectResult>();
		var actionResult = (NotFoundObjectResult)result.Result!;
		actionResult.Value.Should().Be(expectedMessage);
	}

	[Fact]
	public async Task GetByUrlAsync_ValidUrl_ReturnsCorrectResult()
	{
		// Arrange
		var sut = UnitUnderTest();
		SetupMocks();

		var url = _expectedBlogPost.Url;

		// Act
		var result = await sut.GetByUrlAsync(url);

		// Assert
		result.Value.Should().NotBeNull();
		result.Value.Should().BeEquivalentTo(_expectedBlogPost,
			options => options
				.Excluding(t => t.Id)
				.Excluding(t => t.Created)
				.Excluding(x => x.Updated));

		_repositoryMock.Verify(x => x
			.GetByUrlAsync(It.IsAny<string>()), Times.Once);
	}

	[Fact]
	public async Task CreateAsync_AddsBlogPost()
	{
		// Arrange
		var sut = UnitUnderTest();
		SetupMocks();

		var blogPost = BlogPostCreator.GetNewBlogPost();

		// Act
		var result = await sut.CreateAsync(blogPost);

		// Assert
		result.Value.Should().NotBeNull();
		result.Value.Should().BeEquivalentTo(blogPost,
			options => options
				.Excluding(t => t.Id)
				.Excluding(t => t.Created)
				.Excluding(x => x.Updated));

		_repositoryMock.Verify(x => x
			.CreateAsync(It.IsAny<BlogPost>()), Times.Once);
	}

	[Fact]
	public async Task CreateAsync_WithInValidData_ShouldReturnBadRequest()
	{
		// Arrange
		var sut = UnitUnderTest();
		SetupMocks();

		const string expectedMessage = "This is a bad request the blogPost is null!";
		BlogPost? blogPost = null;

		// Act
		var result = await sut.CreateAsync(blogPost);

		// Assert
		result.Result.Should().BeOfType<BadRequestObjectResult>();
		var actionResult = (BadRequestObjectResult)result.Result!;
		actionResult.Value.Should().Be(expectedMessage);
	}

	private void SetupMocks()
	{
		_repositoryMock.Setup(x => x
			.GetAllAsync()).ReturnsAsync(_expectedBlogPosts);

		_repositoryMock.Setup(x => x
			.GetByUrlAsync(It.IsAny<string>())).ReturnsAsync(_expectedBlogPost);

		_repositoryMock.Setup(x => x
			.CreateAsync(It.IsAny<BlogPost>())).ReturnsAsync(_expectedBlogPost);
	}
}