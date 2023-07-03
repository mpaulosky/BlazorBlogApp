using Bogus;

namespace BlazorBlog.Shared;

public static class BlogPostCreator
{
	/// <summary>
	///   Gets a new post.
	/// </summary>
	/// <param name="keepId">bool whether to keep the generated Id</param>
	/// <param name="useNewSeed">bool whether to use a seed other than 0</param>
	/// <returns>BlogPost</returns>
	public static BlogPost GetNewBlogPost(bool keepId = false, bool useNewSeed = false)
	{
		var post = GenerateFake(useNewSeed).Generate();

		if (!keepId)
		{
			post.Id = 0;
		}

		return post;
	}

	public static IEnumerable<BlogPost> GetNewBlogPosts()
	{
		var posts = GenerateFake().Generate(3);
		
		// foreach (var post in posts)
		// {
		// 	post.Id = 0;
		// }

		return posts;
	}

	/// <summary>
	///   Gets a list of posts.
	/// </summary>
	/// <param name="numberOfPosts">The number of posts.</param>
	/// <param name="useNewSeed">bool whether to use a seed other than 0</param>
	/// <returns>A List of BlogPost</returns>
	public static List<BlogPost> GetBlogPosts(int numberOfPosts, bool useNewSeed = false)
	{
		var posts = GenerateFake(useNewSeed).Generate(numberOfPosts);
		
		return posts;
	}

	/// <summary>
	///   GenerateFake method
	/// </summary>
	/// <param name="useNewSeed">bool whether to use a seed other than 0</param>
	/// <returns>Fake BlogPost</returns>
	private static Faker<BlogPost> GenerateFake(bool useNewSeed = false)
	{
		var seed = 0;
		if (useNewSeed)
		{
			seed = Random.Shared.Next(10, int.MaxValue);
		}

		return new Faker<BlogPost>()
			.RuleFor(x => x.Id, f => f.Random.Int(0, 100))
			.RuleFor(x => x.Url, f => $"{f.Name.FirstName()}-{f.Name.LastName()}" )
			.RuleFor(c => c.Title, f => f.Lorem.Sentence(10))
			.RuleFor(x => x.Description, f => f.Lorem.Paragraph(1))
			.RuleFor(x => x.Content, f => f.Lorem.Paragraphs(10))
			.RuleFor(x => x.Author, f => f.Name.FullName())
			.RuleFor(x => x.Created, f => f.Date.Past())
			.UseSeed(seed);
	}
}