// ============================================
// Copyright (c) 2023. All rights reserved.
// File Name :     DataBaseSettings.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : BlazorBlogApp
// Project Name :  BlazorBlog.Shared
// =============================================

namespace BlazorBlog.Shared;

/// <summary>
///   DatabaseSettings class
/// </summary>
public class DatabaseSettings : IDatabaseSettings
{
	/// <summary>
	///   Default constructor for DatabaseSettings
	/// </summary>
	public DatabaseSettings()
	{
	}

	/// <summary>
	///   Constructor for DatabaseSettings with connectionStrings and databaseName parameters
	/// </summary>
	/// <param name="connectionStrings">The connection string</param>
	/// <param name="databaseName">The database name</param>
	public DatabaseSettings(string connectionStrings, string databaseName)
	{
		ConnectionStrings = connectionStrings;
		DatabaseName = databaseName;
	}

	/// <summary>
	///   The connection string for database
	/// </summary>
	public string ConnectionStrings { get; set; } = null!;

	/// <summary>
	///   The name of the database
	/// </summary>
	public string DatabaseName { get; set; } = null!;
}