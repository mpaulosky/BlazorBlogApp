﻿// ============================================
// Copyright (c) 2023. All rights reserved.
// File Name :     RegisterConnections.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : BlazorBlogApp
// Project Name :  BlazorBlog.Server
// =============================================

namespace BlazorBlog.Server.Services;

public static partial class ServiceCollectionExtensions
{
	public static IServiceCollection RegisterConnections(this IServiceCollection services, ConfigurationManager config)
	{
		IConfigurationSection section = config.GetSection("MongoDbSettings");
		ArgumentNullException.ThrowIfNull(section);
		DatabaseSettings mongoSettings = section.Get<DatabaseSettings>()!;
		services.AddSingleton<IDatabaseSettings>(mongoSettings);

		return services;
	}
}