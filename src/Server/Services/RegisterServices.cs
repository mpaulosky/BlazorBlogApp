// ============================================
// Copyright (c) 2023. All rights reserved.
// File Name :     RegisterServices.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : BlazorBlogApp
// Project Name :  BlazorBlog.Server
// =============================================

using System.Diagnostics.CodeAnalysis;

namespace BlazorBlog.Server.Services;

/// <summary>
///   IServiceCollectionExtensions
/// </summary>
[ExcludeFromCodeCoverage]
public static partial class ServiceCollectionExtensions
{
	/// <summary>
	///   Register DI Collections
	/// </summary>
	/// <param name="services">IServiceCollection</param>
	/// <returns>IServiceCollection</returns>
	public static IServiceCollection RegisterServices(this IServiceCollection services)
	{
		services.AddSingleton<IMongoDbContextFactory, MongoDbContextFactory>();
		services.AddSingleton<IBlogPostRepository, BlogPostRepository>();

		return services;
	}
}