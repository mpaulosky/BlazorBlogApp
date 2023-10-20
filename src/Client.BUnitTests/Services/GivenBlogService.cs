using System;

using BlazorBlog.Shared.FakerCreators;

using Flurl.Http;

namespace BlazorBlog.Client.Services;

[ExcludeFromCodeCoverage]
public class GivenBlogService : TestContext
{
	private readonly BlogService _blogService;
	private BlogPost? _expectedBlogPost = new();
	private List<BlogPost>? _expectedBlogPosts = new();
	private readonly Url _baseUrl = new("https://test.com/");

	public GivenBlogService()
	{
		PerBaseUrlFlurlClientFactory flurlClientFactory = new();
		_blogService = new BlogService(flurlClientFactory, _baseUrl);
	}

	[Fact()]
	public async Task GetBlogPosts_Should_Return_A_ListOfBlogs_TestAsync()
	{
		// Arrange
		_expectedBlogPosts = BlogPostCreator.GetBlogPosts(3).ToList();

		// Act
		using var httpTest = new HttpTest();

		httpTest.RespondWithJson(_expectedBlogPosts);

		var result = await _blogService.GetBlogPosts();

		// Assert
		result.Should().NotBeNull();
		result!.Count.Should().Be(_expectedBlogPosts.Count);
		result.Should().BeEquivalentTo(_expectedBlogPosts);
	}

	[Fact()]
	public async Task GetBlogPostByUrl_With_ValidUrl_Should_Return_ABlog_TestAsync()
	{
		// Arrange
		_expectedBlogPost = BlogPostCreator.GetNewBlogPost(true);
		var url = _expectedBlogPost.Url;

		// Act
		using var httpTest = new HttpTest();

		httpTest.RespondWithJson(_expectedBlogPost);

		var result = await _blogService.GetBlogPostByUrl(url);

		// Assert
		result.Should().NotBeNull();
		result.Should().BeEquivalentTo(_expectedBlogPost);
	}

	[Fact()]
	public async Task GetBlogPostByUrl_With_InValidUrl_Should_Return_FlurlHttpException_TestAsync()
	{
		// Arrange
		_expectedBlogPost = BlogPostCreator.GetNewBlogPost(true);
		var url = "test-url";

		// Act
		using var httpTest = new HttpTest();

		httpTest.RespondWith("", (int)System.Net.HttpStatusCode.NotFound);

		//var result = await _blogService.GetBlogPostByUrl(url);
		Func<Task> act = async () => await _blogService.GetBlogPostByUrl(url);

		// Assert
		await act.Should()
			.ThrowAsync<FlurlHttpException>()
			.WithMessage("Call failed with status code 404 (Not Found): GET https://test.com/api/blog/test-url");
	}

	[Fact()]
	public async Task CreateNewBlogPost_StateUnderTest_ExpectedBehavior()
	{
		// Arrange
		_expectedBlogPost = BlogPostCreator.GetNewBlogPost();

		// Act
		using var httpTest = new HttpTest();

		httpTest.RespondWithJson(_expectedBlogPost, (int)System.Net.HttpStatusCode.Created);

		var result = await _blogService.CreateNewBlogPost(_expectedBlogPost);

		// Assert
		result.Should().NotBeNull();
		result.Should().BeEquivalentTo(_expectedBlogPost);
	}
}