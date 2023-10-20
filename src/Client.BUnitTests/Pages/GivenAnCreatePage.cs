using System;

using BlazorBlog.Shared.FakerCreators;

namespace BlazorBlog.Client.Pages;

[ExcludeFromCodeCoverage]
public class GivenAnCreatePage : TestContext
{
	private readonly Mock<IBlogService> _blogServiceMock;
	private BlogPost? _expectedPost = new();

	public GivenAnCreatePage()
	{
		_blogServiceMock = new Mock<BlazorBlog.Client.Services.IBlogService>();
	}

	private IRenderedComponent<Create> ComponentUnderTest()
	{
		IRenderedComponent<Create> component = RenderComponent<Create>();

		return component;
	}

	[Fact]
	public void Create_OnLoad_Should_DisplayPage_Test()
	{
		// Arrange
		const string expectedHtml =
			"""
			<h3>Create a New Blog Post</h3>
			<form >
			  <div class="form-group mb-2">
			    <label for="title">Title</label>
			    <input id="title" class="form-control valid" value=""  >
			  </div>
			  <div class="form-group mb-2">
			    <label for="url">Url</label>
			    <input id="url" class="form-control valid" value=""  >
			  </div>
			  <div class="form-control-file mb-2">
			    <label for="image">Image</label>
			    <input id="image" type="file" >
			  </div>
			  <div class="form-group mb-2">
			    <label for="description">Description</label>
			    <textarea id="description" class="form-control valid" value=""  ></textarea>
			  </div>
			  <div class="form-group mb-2">
			    <label for="content">Content</label>
			    <textarea id="content" class="form-control valid" value=""  ></textarea>
			  </div>
			  <div class="form-group mb-2">
			    <label for="preview">Content Preview</label>
			    <div id="preview" class="form-group mb-2"></div>
			  </div>
			  <div class="form-group mb-2">
			    <label for="author">Author</label>
			    <input id="author" class="form-control valid" value=""  >
			  </div>
			  <div class="form-group mb-2">
			    <label for="date">Date Created</label>
			    <input id="date" type="date" class="form-control valid" value:ignore  >
			  </div>
			  <div class="form-check mb-2">
			    <input id="isPublished" type="checkbox" class="form-check-input valid" checked=""  >
			    <label for="isPublished">Publish</label>
			  </div>
			  <button id="submit" type="submit" class="btn btn-primary">Create</button>
			</form>
			""";

		SetupMocks();
		RegisterServices();

		// Act
		IRenderedComponent<Create> cut = ComponentUnderTest();

		// Assert
		cut.MarkupMatches(expectedHtml);
	}

	[Fact]
	public void Create_With_ValidInput_Should_SaveNewBlog_Test()
	{
		// Arrange
		_expectedPost = BlogPostCreator.GetNewBlogPost();

		SetupMocks();
		RegisterServices();

		// Act
		IRenderedComponent<Create> cut = ComponentUnderTest();

		cut.Find("#title").Change(_expectedPost.Title);
		cut.Find("#url").Change(_expectedPost.Url);
		cut.Find("#description").Change(_expectedPost.Description);
		cut.Find("#content").Change(_expectedPost.Content);
		cut.Find("#author").Change(_expectedPost.Author);
		cut.Find("#date").Change(DateTime.Now);
		cut.Find("#submit").Click();

		// Assert
		_blogServiceMock
			.Verify(x =>
				x.CreateNewBlogPost(It.IsAny<BlogPost>()), Times.Once);

		var navMan = Services.GetRequiredService<FakeNavigationManager>();

		navMan.Uri.Should().NotBeNull();
		navMan.Uri.Should().Be($"http://localhost/posts/{_expectedPost.Url}");
	}

	[Fact]
	public void Create_With_InValidInput_Should_ShowValidationErrors_Test()
	{
		// Arrange
		const string expectedHtml =
			"""
			<h3>Create a New Blog Post</h3>
			<form >
			  <ul class="validation-errors">
			    <li class="validation-message">The Url field is required.</li>
			    <li class="validation-message">The Title field is required.</li>
			    <li class="validation-message">The Description field is required.</li>
			    <li class="validation-message">The Content field is required.</li>
			    <li class="validation-message">The Author field is required.</li>
			  </ul>
			  <div class="form-group mb-2">
			    <label for="title">Title</label>
			    <input id="title" aria-invalid="true" class="form-control invalid" value=""  >
			    <div class="validation-message">The Title field is required.</div>
			  </div>
			  <div class="form-group mb-2">
			    <label for="url">Url</label>
			    <input id="url" aria-invalid="true" class="form-control invalid" value=""  >
			    <div class="validation-message">The Url field is required.</div>
			  </div>
			  <div class="form-control-file mb-2">
			    <label for="image">Image</label>
			    <input id="image" type="file" >
			  </div>
			  <div class="form-group mb-2">
			    <label for="description">Description</label>
			    <textarea id="description" aria-invalid="true" class="form-control invalid" value=""  ></textarea>
			    <div class="validation-message">The Description field is required.</div>
			  </div>
			  <div class="form-group mb-2">
			    <label for="content">Content</label>
			    <textarea id="content" aria-invalid="true" class="form-control invalid" value=""  ></textarea>
			    <div class="validation-message">The Content field is required.</div>
			  </div>
			  <div class="form-group mb-2">
			    <label for="preview">Content Preview</label>
			    <div id="preview" class="form-group mb-2"></div>
			  </div>
			  <div class="form-group mb-2">
			    <label for="author">Author</label>
			    <input id="author" aria-invalid="true" class="form-control invalid" value=""  >
			    <div class="validation-message">The Author field is required.</div>
			  </div>
			  <div class="form-group mb-2">
			    <label for="date">Date Created</label>
			    <input id="date" type="date" class="form-control valid" value:ignore  >
			  </div>
			  <div class="form-check mb-2">
			    <input id="isPublished" type="checkbox" class="form-check-input valid" checked=""  >
			    <label for="isPublished">Publish</label>
			  </div>
			  <button id="submit" type="submit" class="btn btn-primary">Create</button>
			</form>
			""";

		SetupMocks();
		RegisterServices();

		// Act
		IRenderedComponent<Create> cut = ComponentUnderTest();

		cut.Find("#submit").Click();

		// Assert
		cut.MarkupMatches(expectedHtml);
	}

	private void RegisterServices()
	{
		Services.AddSingleton(_blogServiceMock.Object);
	}

	private void SetupMocks()
	{
		_blogServiceMock.Setup(m => m.CreateNewBlogPost(It.IsAny<BlogPost>())).ReturnsAsync(_expectedPost);
	}
}