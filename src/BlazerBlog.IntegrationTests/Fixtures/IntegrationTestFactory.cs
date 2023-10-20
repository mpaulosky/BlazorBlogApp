using BlazorBlog.Server;
using BlazorBlog.Shared.Database;

namespace BlazerBlog.IntegrationTests.Fixtures;

[Collection("Test collection")]
[ExcludeFromCodeCoverage]
[UsedImplicitly]
public class IntegrationTestFactory : WebApplicationFactory<IAppMarker>, IAsyncLifetime
{
	private readonly string _databaseName;

	private readonly MongoDbContainer _mongoDbContainer;

	public IntegrationTestFactory()
	{
		_mongoDbContainer = new MongoDbBuilder().Build();

		_databaseName = $"test_{Guid.NewGuid():N}";
	}

	private IDatabaseSettings? DbConfig { get; set; }

	public IMongoDbContextFactory? DbContext { get; set; }

	public async Task InitializeAsync()
	{
		await _mongoDbContainer.StartAsync();

		string? connString = _mongoDbContainer.GetConnectionString();
		string dbName = _databaseName;

		DbConfig = new DatabaseSettings(connString, dbName) { ConnectionStrings = connString, DatabaseName = dbName };
	}

	public new async Task DisposeAsync()
	{
		await DbContext!.Client.DropDatabaseAsync(_databaseName);
		await _mongoDbContainer.DisposeAsync().ConfigureAwait(false);
	}

	protected override void ConfigureWebHost(IWebHostBuilder builder)
	{
		builder.ConfigureTestServices(services =>
		{
			ServiceDescriptor? dbConnectionDescriptor = services.SingleOrDefault(
				d => d.ServiceType ==
				     typeof(IMongoDbContextFactory));

			services.Remove(dbConnectionDescriptor!);

			ServiceDescriptor? dbSettings = services.SingleOrDefault(
				d => d.ServiceType ==
				     typeof(IDatabaseSettings));

			services.Remove(dbSettings!);

			services.AddSingleton<IDatabaseSettings>(_ => DbConfig!);

			services.AddSingleton<IMongoDbContextFactory>(_ =>
				new MongoDbContextFactory(DbConfig!));

			using ServiceProvider serviceProvider = services.BuildServiceProvider();

			DbContext = serviceProvider.GetRequiredService<IMongoDbContextFactory>();
		});

		builder.UseEnvironment("Development");
	}

	public async Task ResetCollectionAsync(string? collection)
	{
		if (!string.IsNullOrWhiteSpace(collection))
		{
			await DbContext!.Client.GetDatabase(_databaseName).DropCollectionAsync(collection);
		}
	}
}