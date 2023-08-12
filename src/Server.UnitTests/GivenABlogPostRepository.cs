using Microsoft.EntityFrameworkCore;

namespace Server.UnitTests;

[ExcludeFromCodeCoverage]
public class GivenABlogPostRepository
{
	private readonly Mock<DataContext> _contextMock;
	private readonly List<BlogPost> _expectedBlogPosts;
	private readonly BlogPost _expectedBlogPost;
	private readonly DbContextOptionsBuilder<DataContext> _optionsBuilder;

	public GivenABlogPostRepository()
	{
		_expectedBlogPosts = BlogPostCreator.GetBlogPosts(3).ToList();
		_expectedBlogPost = BlogPostCreator.GetNewBlogPost(true);
		_optionsBuilder = new DbContextOptionsBuilder<DataContext>();
		_contextMock = new Mock<DataContext>(_optionsBuilder.Options);
	}

	private BlogPostRepository UnitUnderTest()
	{
		return new BlogPostRepository(_contextMock.Object);
	}

	[Fact]
	public void GetAllBlogPostsTest()
	{
		//Arrange
		SetupMocks();
		var sut = UnitUnderTest();

		//Act
		var results = sut.GetAllBlogPosts().ToList();

		//Assert
		results.Count.Should().Be(_expectedBlogPosts.Count);

		results.Should().BeEquivalentTo(_expectedBlogPosts,
			options => options
				.Excluding(t => t.Id)
				.Excluding(t => t.Created)
				.Excluding(x => x.Updated));
	}

	[Fact]
	public void GetBlogPostByUrlTest()
	{
		//Arrange
		SetupMocks();
		var sut = UnitUnderTest();

		var postUrl = _expectedBlogPosts.First().Url;

		//Act
		var result = sut.GetBlogPostByUrl(postUrl);

		//Assert
		result.Should().NotBeNull();

		result.Should().BeEquivalentTo(_expectedBlogPosts.First(),
			options => options
				.Excluding(t => t.Id)
				.Excluding(t => t.Created)
				.Excluding(x => x.Updated));
	}

	[Fact]
	public async Task CreateNewBlogPostAsyncTest()
	{
		//Arrange
		SetupMocks();
		var sut = UnitUnderTest();

		//Act
		var result = await sut.CreateNewBlogPostAsync(_expectedBlogPost);

		//Assert
		result.Should().BeEquivalentTo(_expectedBlogPost,
			options => options
				.Excluding(t => t.Id)
				.Excluding(t => t.Created)
				.Excluding(x => x.Updated));

		_contextMock.Verify(x => x.BlogPosts.Add(It.IsAny<BlogPost>()), Times.Once);
		_contextMock.Verify(x => x.SaveChangesAsync(default), Times.Once);
	}

	private void SetupMocks()
	{
		var data = _expectedBlogPosts.AsQueryable();
		var mockSet = new Mock<DbSet<BlogPost>>();
		mockSet.As<IQueryable<BlogPost>>().Setup(m => m.Provider).Returns(data.Provider);
		mockSet.As<IQueryable<BlogPost>>().Setup(m => m.Expression).Returns(data.Expression);
		mockSet.As<IQueryable<BlogPost>>().Setup(m => m.ElementType).Returns(data.ElementType);
		mockSet.As<IQueryable<BlogPost>>().Setup(m => m.GetEnumerator()).Returns(() => data.GetEnumerator());

		_contextMock.Setup(c => c.BlogPosts).Returns(mockSet.Object);
	}
}