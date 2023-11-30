using BlazerBlog.IntegrationTests.Fixtures;

using BlazorBlog.Shared.Data;
using BlazorBlog.Shared.Database;
using BlazorBlog.Shared.FakerCreators;

namespace BlazerBlog.IntegrationTests.Data;

[Collection("Test Collection")]
[ExcludeFromCodeCoverage]
public class GivenBlogPostRepository : IAsyncLifetime
{
	private const string CleanupValue = "posts";

	private readonly IntegrationTestFactory _factory;
	private readonly BlogPostRepository _sut;

	public GivenBlogPostRepository(IntegrationTestFactory factory)
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

	[Fact]
	public async Task GetAllBlogPosts_StateUnderTest_ExpectedBehavior()
	{
		// Arrange
		var expected = BlogPostCreator.GetNewBlogPost();
		await _sut.CreateAsync(expected);

		// Act
		List<BlogPost> results = (await _sut.GetAllAsync()).ToList();

		// Assert
		results.Count.Should().Be(1);
		results.First().Should().BeEquivalentTo(expected,
			options => options
				.Excluding(t => t.Id)
				.Excluding(t => t.Created)
				.Excluding(x => x.Updated));
	}

	[Fact]
	public async Task GetByUrlAsync_StateUnderTest_ExpectedBehavior()
	{
		// Arrange
		var expected = BlogPostCreator.GetNewBlogPost();
		string url = expected.Url;
		await _sut.CreateAsync(expected);

		// Act
		var result = await _sut.GetByUrlAsync(url);

		// Assert
		result.Should().BeEquivalentTo(expected,
			options => options
				.Excluding(t => t.Id)
				.Excluding(t => t.Created)
				.Excluding(x => x.Updated));
	}

	[Fact]
	public async Task CreateNewBlogPostAsync_StateUnderTest_ExpectedBehavior()
	{
		// Arrange
		var expected = BlogPostCreator.GetNewBlogPost();

		// Act
		var result = await _sut.CreateAsync(expected);

		// Assert
		result.Should().BeEquivalentTo(expected,
			options => options
				.Excluding(t => t.Id)
				.Excluding(t => t.Created)
				.Excluding(x => x.Updated));
	}
}