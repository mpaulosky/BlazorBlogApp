// ============================================
// Copyright (c) 2023. All rights reserved.
// File Name :     BlogControllerTests.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : BlazorBlogApp.Tests
// Project Name :  BlazorBlog.Server.Tests
// =============================================

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
	public void GetBlogPosts_ReturnsCorrectResult()
	{
		// Arrange
		var sut = UnitUnderTest();
		SetupMocks();

		// Act
		var result = sut.GetBlogPosts();

		// Assert
		result.Value.Should().NotBeNull();
		result.Value.Should().BeEquivalentTo(_expectedBlogPosts,
			options => options
				.Excluding(t => t.Id)
				.Excluding(t => t.Created)
				.Excluding(x => x.Updated));

		_repositoryMock.Verify(x => x
			.GetAllBlogPosts(), Times.Once);
	}

	[Fact]
	public void GetBlogPostByUrl_InvalidUrl_ReturnsNotFound()
	{
		// Arrange
		var sut = UnitUnderTest();
		SetupMocks();

		const string expectedMessage = "This post does not exist.";
		const string url = "";

		// Act
		var result = sut.GetBlogPostByUrl(url);

		// Assert
		result.Result.Should().BeOfType<NotFoundObjectResult>();
		var actionResult = (NotFoundObjectResult)result.Result!;
		actionResult.Value.Should().Be(expectedMessage);
	}

	[Fact]
	public void GetBlogPostByUrl_ValidUrl_ReturnsCorrectResult()
	{
		// Arrange
		var sut = UnitUnderTest();
		SetupMocks();

		var url = _expectedBlogPost.Url;

		// Act
		var result = sut.GetBlogPostByUrl(url);

		// Assert
		result.Value.Should().NotBeNull();
		result.Value.Should().BeEquivalentTo(_expectedBlogPost,
			options => options
				.Excluding(t => t.Id)
				.Excluding(t => t.Created)
				.Excluding(x => x.Updated));

		_repositoryMock.Verify(x => x
			.GetBlogPostByUrl(It.IsAny<string>()), Times.Once);
	}

	[Fact]
	public async Task CreateNewBlogPost_AddsBlogPost()
	{
		// Arrange
		var sut = UnitUnderTest();
		SetupMocks();

		var blogPost = BlogPostCreator.GetNewBlogPost();

		// Act
		var result = await sut.CreateNewBlogPost(blogPost);

		// Assert
		result.Value.Should().NotBeNull();
		result.Value.Should().BeEquivalentTo(blogPost,
			options => options
				.Excluding(t => t.Id)
				.Excluding(t => t.Created)
				.Excluding(x => x.Updated));

		_repositoryMock.Verify(x => x
			.CreateNewBlogPostAsync(It.IsAny<BlogPost>()), Times.Once);
	}

	[Fact]
	public async Task CreateNewBlogPost_WithInValidData_ShouldReturnBadRequest()
	{
		// Arrange
		var sut = UnitUnderTest();
		SetupMocks();

		const string expectedMessage = "This is a bad request the blogPost is null!";
		BlogPost? blogPost = null;

		// Act
		var result = await sut.CreateNewBlogPost(blogPost);

		// Assert
		result.Result.Should().BeOfType<BadRequestObjectResult>();
		var actionResult = (BadRequestObjectResult)result.Result!;
		actionResult.Value.Should().Be(expectedMessage);
	}

	private void SetupMocks()
	{
		_repositoryMock.Setup(x => x
			.GetAllBlogPosts()).Returns(_expectedBlogPosts);

		_repositoryMock.Setup(x => x
			.GetBlogPostByUrl(It.IsAny<string>())).Returns(_expectedBlogPost);

		_repositoryMock.Setup(x => x
			.CreateNewBlogPostAsync(It.IsAny<BlogPost>())).ReturnsAsync(_expectedBlogPost);
	}
}