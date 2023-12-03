// Copyright (C) 2020 Serhii Kuzmychov (ku3mich@gmail.com)
// Licensed under the terms of the MIT license. See LICENCE for details.

using System.Reflection;
using Xunit.Sdk;

namespace Xunit.Include;

public class ContentsOfFileAttribute : DataAttribute
{
    private readonly string[] FileNames;

    public ContentsOfFileAttribute(params string[] fileNames)
    {
        FileNames = fileNames;
    }

    public override IEnumerable<object[]> GetData(MethodInfo testMethod)
    {
        object[] prms = FileNames
            .Select(s => new ContentsOfFile(s))
            .Cast<object>()
            .ToArray();

        yield return prms;
    }
}
