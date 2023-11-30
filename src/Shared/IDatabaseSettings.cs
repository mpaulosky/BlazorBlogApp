// ============================================
// Copyright (c) 2023. All rights reserved.
// File Name :     IDatabaseSettings.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : BlazorBlogApp
// Project Name :  BlazorBlog.Shared
// =============================================

namespace BlazorBlog.Shared;

/// <summary>
/// Specifies the IDatabaseSettings interface.
/// </summary>
public interface IDatabaseSettings
{
	/// <summary>
	/// Gets or sets the connection string for the database.
	/// </summary>
	string ConnectionStrings { get; set; }

	/// <summary>
	/// Gets or sets the name of the database.
	/// </summary>
	string DatabaseName { get; set; }
}