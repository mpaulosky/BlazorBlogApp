namespace BlazorBlog.Client.Shared;

[ExcludeFromCodeCoverage]
public class GivenNaveMenuComponent : TestContext
{
	private IRenderedComponent<NavMenu> ComponentUnderTest()
	{
		IRenderedComponent<NavMenu> component = RenderComponent<NavMenu>();

		return component;
	}

	[Fact]
	public void NavMenuOnLoad_Test()
	{
		// Arrange
		const string expected =
			"""
			<nav class="navbar navbar-expand-sm navbar-light bg-light" >
				<div class="container-fluid" >
						<a class="navbar-brand" href="#" ><span ><img height="15" width="15" src="/icon-192.png" alt="Blazor Img" ></span>Blazor Blog</a>
						<button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarNavAltMarkup" aria-controls="navbarNavAltMarkup" aria-expanded="false" aria-label="Toggle navigation" ><span class="navbar-toggler-icon" ></span></button>
						<div class="collapse navbar-collapse" id="navbarNavAltMarkup" >
							<div class="navbar-nav" >
								<a class="nav-link active" aria-current="page" href="#" ><span class="oi oi-home" aria-hidden="true" ></span>Home</a>
								<a class="nav-link" href="create" ><span class="oi oi-plus" aria-hidden="true" ></span>Create</a>
							</div>
						</div>
				</div>
			</nav>
			""";

		// Act
		var cut = ComponentUnderTest();

		// Assert
		cut.MarkupMatches(expected);
	}
}