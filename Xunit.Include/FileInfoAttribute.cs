// Copyright (C) 2020 Serhii Kuzmychov (ku3mich@gmail.com)
// Licensed under the terms of the MIT license. See LICENCE for details.

using System.Reflection;
using Xunit.Sdk;

namespace Xunit.Include;

public class FileInfoAttribute : DataAttribute
{
    private readonly string[] FileNames;

    public FileInfoAttribute(params string[] fileNames)
    {
        FileNames = fileNames;
    }

    public override IEnumerable<object[]> GetData(MethodInfo testMethod)
    {
        object[] prms = FileNames
            .Select(s => new FileInfo(PathResolver.Instance.Resolve(s)))
            .Cast<object>()
            .ToArray();

        yield return prms;
    }
}

