// ============================================
// Copyright (c) 2023. All rights reserved.
// File Name :     ServicesExtensions.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : BlazorBlogApp
// Project Name :  BlazorBlog.Server
// =============================================

using System.Diagnostics.CodeAnalysis;

namespace BlazorBlog.Server.Services;

[ExcludeFromCodeCoverage]
public static class ServicesExtensions
{
	public static void ConfigureServices(this WebApplicationBuilder builder, ConfigurationManager config)
	{
		// Add services to the container.

		builder.Services.RegisterConnections(config);

		builder.Services.RegisterServices();

		builder.Services.AddControllersWithViews();

		builder.Services.AddRazorPages();
	}
}