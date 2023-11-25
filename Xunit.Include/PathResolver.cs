// Copyright (C) 2020 Serhii Kuzmychov (ku3mich@gmail.com)
// Licensed under the terms of the MIT license. See LICENCE for details.

using System.Diagnostics.CodeAnalysis;

namespace Xunit;

public class PathResolver : IPathResolver
{
    private readonly string Root;

    public PathResolver() : this(BaseDirectory) { }

    public PathResolver(string root)
    {
        Root = root;
    }

    public string Resolve(string? relative = null)
    {
        string p = relative ?? string.Empty;
        if (Path.IsPathRooted(p))
            throw new ArgumentException("path should be a relative path");

        var combined = Path.Combine(Root, p);

        return combined;
    }

    #region statics

    [NotNull] private static readonly string CurrentDomainBaseDirectory;

    private static readonly string BaseDirectory = Path.GetDirectoryName(CurrentDomainBaseDirectory) ?? string.Empty;

    public static readonly IPathResolver Instance = new PathResolver();


    static PathResolver()
    {
        CurrentDomainBaseDirectory = AppDomain.CurrentDomain.BaseDirectory ?? string.Empty;
    }

    #endregion
}

