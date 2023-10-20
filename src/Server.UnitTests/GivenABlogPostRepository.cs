using BlazorBlog.Shared.Database;
using BlazorBlog.Shared.FakerCreators;

namespace Server.UnitTests;

[ExcludeFromCodeCoverage]
public class GivenABlogPostRepository
{
	private readonly Mock<IMongoCollection<BlogPost>> _mockCollection;
	private readonly Mock<IMongoDbContextFactory> _mockContext;
	private readonly List<BlogPost> _expectedBlogPosts;
	private readonly BlogPost _expectedBlogPost;

	public GivenABlogPostRepository()
	{
		_expectedBlogPosts = BlogPostCreator.GetBlogPosts(3).ToList();
		_expectedBlogPost = BlogPostCreator.GetNewBlogPost();

		var _cursor = TestFixtures.GetMockCursor(_expectedBlogPosts);

		_mockCollection = TestFixtures.GetMockCollection(_cursor);

		_mockContext = TestFixtures.GetMockContext();
	}

	private BlogPostRepository UnitUnderTest()
	{
		return new BlogPostRepository(_mockContext.Object);
	}

	[Fact]
	public async Task GetAllBlogPostsTest()
	{
		//Arrange
		var sut = UnitUnderTest();

		//Act
		var results = (await sut.GetAllAsync()).ToList();

		//Assert
		results.Should().NotBeNull();
		results.Count().Should().Be(_expectedBlogPosts.Count);

		results.Should().BeEquivalentTo(_expectedBlogPosts,
			options => options
				.Excluding(t => t.Id)
				.Excluding(t => t.Created)
				.Excluding(x => x.Updated));

		_mockCollection.Verify(c => c
			.FindAsync(
				FilterDefinition<BlogPost>.Empty,
				It.IsAny<FindOptions<BlogPost>>(),
				It.IsAny<CancellationToken>()), Times.Once);
	}

	[Fact]
	public async Task GetByUrlAsyncTest()
	{
		//Arrange
		var sut = UnitUnderTest();

		var postUrl = _expectedBlogPosts.First().Url;

		//Act
		var result = await sut.GetByUrlAsync(postUrl);

		//Assert
		result.Should().NotBeNull();
		result.Should().BeEquivalentTo(_expectedBlogPosts.First(),
			options => options
				.Excluding(t => t.Id)
				.Excluding(t => t.Created)
				.Excluding(x => x.Updated));

		_mockCollection.Verify(c => c
			.FindAsync(
				It.IsAny<FilterDefinition<BlogPost>>(),
				It.IsAny<FindOptions<BlogPost>>(),
				It.IsAny<CancellationToken>()), Times.Once);
	}

	[Fact]
	public async Task CreateAsyncTest()
	{
		//Arrange
		var sut = UnitUnderTest();

		//Act
		var result = await sut.CreateAsync(_expectedBlogPost);

		//Assert
		result.Id.Should().NotBeNullOrWhiteSpace();
		result.Should().BeEquivalentTo(_expectedBlogPost,
			options => options
				.Excluding(t => t.Id)
				.Excluding(t => t.Created)
				.Excluding(x => x.Updated));

		_mockCollection.Verify(c => c
			.InsertOneAsync(
				_expectedBlogPost,
				null,
				default), Times.Once);
	}
}